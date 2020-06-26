using System.Linq;
using System.Threading.Tasks;
using Painter.Geometry;

namespace Painter.Mechanics
{
    public class CombinedDrawingMechanism : IDrawingMechanism
    {
        private readonly IDrawingMechanism[] drawingMechanisms;

        public CombinedDrawingMechanism(IDrawingMechanism[] drawingMechanisms)
        {
            this.drawingMechanisms = drawingMechanisms;
        }

        public Task MoveToAsync(VectorPosition position)
        {
            return Task.WhenAll(drawingMechanisms.Select(m => m.MoveToAsync(position)));
        }

        public Task UpAsync()
        {
            return Task.WhenAll(drawingMechanisms.Select(m => m.UpAsync()));
        }

        public Task DownAsync()
        {
            return Task.WhenAll(drawingMechanisms.Select(m => m.DownAsync()));
        }
    }
}