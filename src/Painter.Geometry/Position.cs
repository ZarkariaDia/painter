using System;

namespace Painter.Core
{
    public struct Position
    {
        public Position(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }

        public double Y { get; }

        public bool IsReachable => !double.IsInfinity(X) && !double.IsInfinity(Y);
    }
}