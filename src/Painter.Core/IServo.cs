using System.Threading.Tasks;

namespace Painter.Core
{
    public interface IServo
    {
        Task RotateAsync(Angle angle);
    }
}