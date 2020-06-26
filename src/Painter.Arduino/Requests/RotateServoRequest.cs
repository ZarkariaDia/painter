using Painter.Core;

namespace Painter.Arduino
{
    public class RotateServoRequest : ArduinoRequest
    {
        public RotateServoRequest(int port, AngleSpan angle) : base(ArduinoRequestKind.RotateServo, port, angle) {}
    }
}