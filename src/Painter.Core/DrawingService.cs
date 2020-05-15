namespace Painter.Core
{
    public class DrawingService : IDrawingService
    {
        private readonly IDrawingMechanism drawingMechanism;

        public DrawingService(IDrawingMechanism drawingMechanism)
        {
            this.drawingMechanism = drawingMechanism;
        }

        public void Draw(params IDrawingPrimitive[] drawingPrimitives)
        {
            
        }
    }
}