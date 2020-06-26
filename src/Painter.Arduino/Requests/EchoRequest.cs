namespace Painter.Arduino
{
    public class EchoRequest : ArduinoRequest
    {
        public EchoRequest() : base(ArduinoRequestKind.Echo) {}
    }
}