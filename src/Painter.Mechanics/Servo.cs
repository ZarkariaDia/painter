using System.Threading.Tasks;
using Painter.Arduino;
using Painter.Core;

namespace Painter.Mechanics
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

        public Angle CurrentAngle { get; }

        public Task RotateAsync(Angle angle)
        {
            throw new System.NotImplementedException();
        }
    }

    public class ServoConfiguration
    {
        public int Port { get; set; }

        public Angle MinAngle { get; set; }
        public Angle MaxAngle { get; set; }
    }
}