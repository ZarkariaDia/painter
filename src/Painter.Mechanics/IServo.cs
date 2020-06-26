using System.Threading.Tasks;
using Painter.Core;

namespace Painter.Mechanics
{
    public interface IServo
    {
        Angle CurrentAngle { get; }
        Task RotateAsync(Angle angle);
    }
}