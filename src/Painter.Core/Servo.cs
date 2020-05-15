using System.Threading.Tasks;
using Painter.Arduino;

namespace Painter.Core
{
    public class Servo : IServo
    {
        private readonly int port;
        private readonly IArduinoClient arduinoClient;
        private readonly int minAngle;
        private readonly int maxAngle;

        public Servo(int port, IArduinoClient arduinoClient, int minAngle, int maxAngle)
        {
            this.port = port;
            this.arduinoClient = arduinoClient;
            this.minAngle = minAngle;
            this.maxAngle = maxAngle;
        }

        public Task RotateAsync(Angle angle)
        {
            throw new System.NotImplementedException();
        }
    }
}