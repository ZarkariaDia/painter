using System.Threading.Tasks;
using Painter.Geometry;

namespace Painter.Mechanics
{
    public interface IDrawingMechanism
    {
        Task MoveToAsync(Position position);
        Task UpAsync();
        Task DownAsync();
    }
}