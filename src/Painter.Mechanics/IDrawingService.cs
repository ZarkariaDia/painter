using System.Threading.Tasks;
using Painter.Geometry;

namespace Painter.Mechanics
{
    public interface IDrawingService
    {
        Task DrawAsync(params IDrawingPrimitive[] drawingPrimitives);
    }
}