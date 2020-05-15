using System.Threading.Tasks;

namespace Painter.Core
{
    public class DrawingService : IDrawingService
    {
        private readonly IDrawingMechanism drawingMechanism;

        public DrawingService(IDrawingMechanism drawingMechanism)
        {
            this.drawingMechanism = drawingMechanism;
        }

        public async Task DrawAsync(params IDrawingPrimitive[] drawingPrimitives)
        {
            Position? lastPosition = null;
            foreach (var currentPrimitive in drawingPrimitives)
            {
                foreach (var position in currentPrimitive.GetPositionSequence(1))
                {
                    await drawingMechanism.MoveToAsync(position);
                    await Task.Delay(100);
                }
            }
        }
    }
}