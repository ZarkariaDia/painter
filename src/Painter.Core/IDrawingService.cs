using System.Threading.Tasks;

namespace Painter.Core
{
    public interface IDrawingService
    {
        Task DrawAsync(params IDrawingPrimitive[] drawingPrimitives);
    }
}