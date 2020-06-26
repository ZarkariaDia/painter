namespace Painter.Arduino
{
    public enum ArduinoRequestKind : byte
    {
        Echo = 0,
        AttachServo = 1,
        DetachServo = 2,
        RotateServo = 3
    }
}