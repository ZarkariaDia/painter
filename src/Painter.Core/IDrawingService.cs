namespace Painter.Core
{
    public interface IDrawingService
    {
        void Draw(params IDrawingPrimitive[] drawingPrimitives);
    }
}