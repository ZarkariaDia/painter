namespace Painter.Arduino
{
    public class DetachServoRequest : ArduinoRequest
    {
        public DetachServoRequest(int port) : base(ArduinoRequestKind.DetachServo, port) {}
    }
}