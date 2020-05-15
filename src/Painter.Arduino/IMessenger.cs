using System;
using System.Threading.Tasks;

namespace Painter.Arduino
{
    public interface IMessenger<in TRequest, TResponse>
    {
        Task<TResponse> SendRequestAsync(TRequest request);
    }
}
