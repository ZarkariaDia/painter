﻿using System.Collections.Generic;

namespace Painter.Geometry
{
    public class LinePrimitive : IDrawingPrimitive
    {
        private readonly Position @from;
        private readonly Position to;

        public LinePrimitive(Position from, Position to)
        {
            this.@from = @from;
            this.to = to;
        }

        public IEnumerable<Position> GetPositionSequence(int step)
        {
            yield return @from;
            yield return to;
        }
    }
}