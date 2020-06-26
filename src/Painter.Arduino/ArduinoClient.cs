using System.Threading.Tasks;
using Painter.Core;

namespace Painter.Arduino
{
    public class ArduinoClient : IArduinoClient
    {
        private readonly IArduinoValidator validator;
        private readonly IMessenger<ArduinoRequest, bool> messenger;
        private readonly ArduinoConfiguration configuration;

        public ArduinoClient(IArduinoValidator validator, IMessenger<ArduinoRequest, bool> messenger, ArduinoConfiguration configuration)
        {
            this.validator = validator;
            this.messenger = messenger;
            this.configuration = configuration;
        }

        public Task EchoAsync()
        {
            var request = new EchoRequest();
            validator.ValidateRequest(request, configuration).EnsureSuccess();
            return messenger.SendRequestAsync(request);
        }

        public Task AttachServoAsync(int port)
        {
            var request = new AttachServoRequest(port);
            validator.ValidateRequest(request, configuration).EnsureSuccess();
            return messenger.SendRequestAsync(request);
        }

        public Task DetachServoAsync(int port)
        {
            var request = new DetachServoRequest(port);
            validator.ValidateRequest(request, configuration).EnsureSuccess();
            return messenger.SendRequestAsync(request);
        }

        public Task RotateServoAsync(int port, AngleSpan angle)
        {
            var request = new RotateServoRequest(port, angle);
            validator.ValidateRequest(request, configuration).EnsureSuccess();
            return messenger.SendRequestAsync(request);
        }
    }
}