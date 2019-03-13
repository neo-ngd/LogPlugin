using System;
using System.Threading;

namespace Neo.Plugins
{
	public class LogBackend: Plugin, ILogPlugin
    {
		internal LogQueue logs;
		internal string backend;
		internal int cachecount;
		internal bool running;
		internal Thread sendThread;
		public LogBackend() 
		{
			this.cachecount = Settings.Default.CacheCount;
			logs = new LogQueue(this.cachecount);
			this.backend = Settings.Default.Backend;
			this.running = true;
			this.sendThread = new Thread(this.Send);
			this.sendThread.IsBackground = true;
			this.sendThread.Start();
		}
        public override void Configure()
        {
            Settings.Load(GetConfiguration());
        }
        void ILogPlugin.Log(string source, LogLevel level, string message) 
		{
			DateTime now = DateTime.Now;
			string line = $"[{now:yyyy-MM-dd HH:mm:ss}]<{source}>: {message}";
			this.logs.EnQueue(line);
		}
		void Send() 
		{
			while (this.running) {
				bool re = this.logs.DeQueue(out string log);
				if (re) {
					Backend.Send(log, this.backend);
				}
			}
		}
		~ LogBackend()
		{
			this.running = false;
			this.sendThread.Join();
		}
    }

}
