using System.Collections.Generic;

namespace Painter.Geometry
{
    public class LinePrimitive : IDrawingPrimitive
    {
        private readonly VectorPosition @from;
        private readonly VectorPosition to;

        public LinePrimitive(VectorPosition from, VectorPosition to)
        {
            this.@from = @from;
            this.to = to;
        }

        public IEnumerable<VectorPosition> GetPositionSequence(int step)
        {
            yield return @from;
            yield return to;
        }
    }
}