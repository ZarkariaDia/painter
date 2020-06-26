using System.Threading.Tasks;
using Painter.Core;

namespace Painter.Arduino
{
    public interface IArduinoClient
    {
        Task EchoAsync();
        Task AttachServoAsync(int port);
        Task DetachServoAsync(int port);
        Task RotateServoAsync(int port, AngleSpan angle);
    }
}