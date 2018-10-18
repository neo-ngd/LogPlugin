using System.Collections.Concurrent;

namespace Neo.Plugins
{
	internal class LogQueue
    {
        internal ConcurrentQueue<string> que;
        internal int length { get; }
        public LogQueue(int l)
        {
            this.que = new ConcurrentQueue<string>();
            this.length = l;
        }
        public LogQueue()
        {
            this.que = new ConcurrentQueue<string>();
            this.length = 512;
        }

        public void EnQueue(string log)
        {

            while (this.length <= this.que.Count)
            {
                this.que.TryDequeue(out string str);
            }
            this.que.Enqueue(log);
        }
        public bool DeQueue(out string log)
        {
            return this.que.TryDequeue(out log);
        }
        public int Count()
        {
            return this.que.Count;
        }
    }
}
