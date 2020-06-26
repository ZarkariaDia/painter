using System.Collections.Generic;

namespace Painter.Geometry
{
    public interface IDrawingPrimitive
    {
        IEnumerable<VectorPosition> GetPositionSequence(int step);
    }
}