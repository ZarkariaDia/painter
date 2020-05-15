using System.Threading.Tasks;

namespace Painter.Arduino
{
    public interface IArduinoClient
    {
        Task RotateServoAsync();
    }
}