using System.Collections.Generic;
using System.Threading.Tasks;

namespace Painter.Arduino
{
    public class SerialPortMessenger<TRequest, TResponse> : IMessenger<TRequest, TResponse>
    {
        private readonly Queue<(TaskCompletionSource<TResponse>, TRequest)> queue;
        public SerialPortMessenger(int queueSize)
        {
            queue = new Queue<(TaskCompletionSource<TResponse>, TRequest)>(queueSize);
        }

        public Task<TResponse> SendRequestAsync(TRequest request)
        {
            var tcs = new TaskCompletionSource<TResponse>();
            //TODO: should be blocking;
            queue.Enqueue((tcs, request));
            return tcs.Task;
        }

        private void Routine()
        {
            while (true)
            {
                //...
            }
        }
    }
}