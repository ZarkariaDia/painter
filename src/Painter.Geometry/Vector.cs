namespace Painter.Core
{
    public struct Vector
    {
        private Position position;

        public Vector(double x, double y)
        {
            position = new Position(x, y);
        }

        public double X => position.X;

        public double Y => position.Y;

        public bool IsReachable => position.IsReachable;
    }
}