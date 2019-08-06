using System;
using System.Threading;
using System.IO;
using System.Reflection;

namespace Neo.Plugins
{
    public class LogPlugin : Plugin, ILogPlugin
    {
        internal LogQueue logs;
        internal string backend;
        internal int cachecount;
        internal bool running;
        internal bool sendConfiguration;
        internal Thread sendThread;
        public LogPlugin()
        {
            this.cachecount = Settings.Default.CacheCount;
            logs = new LogQueue(this.cachecount);
            this.backend = Settings.Default.Backend;
            this.running = true;
            this.sendConfiguration = true;
            this.sendThread = new Thread(this.Send);
            this.sendThread.IsBackground = true;
            Sender.SetFrom(Settings.Default.Name);
            this.sendThread.Start();
        }	
        public override void Configure()
        {
            Settings.Load(GetConfiguration());
        }
        public void sendAllConfiguration()
        {
            //protocol.json
            var protocolSetting = File.ReadAllText("protocol.json");
            string line = $"Protocol configuration: {protocolSetting}";
            this.logs.EnQueue(line);
            //plugin configuration
            foreach (var p in Neo.Plugins.Plugin.Plugins)
            {
                var configFile = p.ConfigFile;
				if (File.Exists(configFile)) {
					var configSetting = File.ReadAllText(configFile);
                	line = $"Plugin configuration, name: {p.Name}, config: {configSetting}";
                	this.logs.EnQueue(line);
				}
            }
            //node version
            var executing = Assembly.GetExecutingAssembly().GetName();
            var calling = Assembly.GetAssembly(typeof(Plugin)).GetName();
            var entry = Assembly.GetEntryAssembly().GetName();
            line = $"node version, {entry.Name}: {entry.Version}, {calling.Name}: {calling.Version}, {executing.Name}: {executing.Version}";
            this.logs.EnQueue(line);
        }
        void ILogPlugin.Log(string source, LogLevel level, string message)
        {
            if (source == "ConsensusService")
            {
                DateTime now = DateTime.Now;
                string line = $"[{now:yyyy-MM-dd HH:mm:ss}]<{source}>: {message}";
                this.logs.EnQueue(line);
            }
        }
        void Send()
        {
            while (this.running)
            {
                bool re = this.logs.DeQueue(out string log);
                if (re)
                {
                    Sender.Send(log, this.backend);
                    if (this.sendConfiguration)
                    {
                        sendAllConfiguration();
                        this.sendConfiguration = false;
                    }
                }
            }
        }
        ~LogPlugin()
        {
            this.running = false;
            this.sendThread.Join();
        }
    }

}
