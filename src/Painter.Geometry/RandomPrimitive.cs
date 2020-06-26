using System;
using System.Collections.Generic;

namespace Painter.Geometry
{
    public class RandomPrimitive : IDrawingPrimitive
    {
        private readonly int count;
        private readonly Random random = new Random();

        public RandomPrimitive(int count)
        {
            this.count = count;
        }

        public IEnumerable<VectorPosition> GetPositionSequence(int step)
        {
            var iteration = count;
            while (count < 0 || iteration > 0)
            {
                yield return VectorPosition.FromMillimeters(random.Next(0, 100), random.Next(0, 100));
                if (iteration > 0)
                    iteration--;
            }
        }
    }
}