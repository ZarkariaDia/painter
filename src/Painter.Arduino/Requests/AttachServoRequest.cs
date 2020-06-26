namespace Painter.Arduino
{
    public class AttachServoRequest : ArduinoRequest
    {
        public AttachServoRequest(int port) : base(ArduinoRequestKind.AttachServo, port) {}
    }
}