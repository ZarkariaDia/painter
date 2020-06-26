using Painter.Core;

namespace Painter.Arduino
{
    public abstract class ArduinoRequest
    {
        protected ArduinoRequest(ArduinoRequestKind kind, int? port = null, AngleSpan? angle = null)
        {
            Kind = kind;
            Port = port;
            Angle = angle;
        }

        public ArduinoRequestKind Kind { get; }
        public int? Port { get; }
        public AngleSpan? Angle { get; }
    }
}