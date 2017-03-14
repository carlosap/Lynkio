using System.Collections.Concurrent;
namespace Lynkio.CoreFramework.Queue
{
    public class FixedQueue<T>
    {
        public ConcurrentQueue<T> Q = new ConcurrentQueue<T>();
        public int Limit { get; set; } = 10;
        public void Enqueue(T obj)
        {
            Q.Enqueue(obj);
            lock (this)
            {
                T overflow;
                while (Q.Count > Limit && Q.TryDequeue(out overflow)){}
            }
        }
    }
}
