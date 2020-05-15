using System.Threading.Tasks;

namespace Painter.Arduino
{
    public class ArduinoClient : IArduinoClient
    {
        private readonly IMessenger<int, int> messenger;

        public ArduinoClient(IMessenger<int, int> messenger)
        {
            this.messenger = messenger;
        }

        public Task RotateServoAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}