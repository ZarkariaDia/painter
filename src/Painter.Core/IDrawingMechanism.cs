using System.Threading.Tasks;

namespace Painter.Core
{
    public interface IDrawingMechanism
    {
        Task MoveToAsync(Position position);
        Task UpAsync();
        Task DownAsync();
    }
}