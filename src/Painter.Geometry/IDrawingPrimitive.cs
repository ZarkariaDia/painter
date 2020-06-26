using System.Collections.Generic;

namespace Painter.Geometry
{
    public interface IDrawingPrimitive
    {
        IEnumerable<Position> GetPositionSequence(int step);
    }
}