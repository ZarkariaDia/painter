namespace Painter.Core
{
    public interface IDrawingMechanism
    {
        void MoveTo(Position position);
        void Up();
        void Down();
    }
}