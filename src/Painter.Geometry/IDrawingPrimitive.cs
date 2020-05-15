using System.Collections.Generic;

namespace Painter.Core
{
    public interface IDrawingPrimitive
    {
        IEnumerable<Position> GetPositionSequence(int step);
    }
}