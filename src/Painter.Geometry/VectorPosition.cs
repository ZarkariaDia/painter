using System;
// ReSharper disable ConvertToAutoPropertyWhenPossible

namespace Painter.Geometry
{
    public struct VectorPosition
    {
        private readonly double x;
        private readonly double y;

        private VectorPosition(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double MetersX => x;
        public double MetersY => y;

        public double CentimetersX => MetersX * 100;
        public double CentimetersY => MetersY * 100;

        public double MillimetersX => CentimetersX * 10;
        public double MillimetersY => CentimetersY * 10;

        public double MetersLength => Length;
        public double CentimetersLength => MetersLength * 100;
        public double MillimetersLength => CentimetersLength * 10;

        private double Length => Math.Sqrt(x * x + y * y);

        public static VectorPosition FromMeters(double x, double y) => new VectorPosition(x, y);
        public static VectorPosition FromCentimeters(double x, double y) => FromMeters(x / 100, y / 100);
        public static VectorPosition FromMillimeters(double x, double y) => FromCentimeters(x / 10, y / 10);

        public bool IsReachable => !double.IsInfinity(CentimetersX) && !double.IsInfinity(CentimetersY);

        public static VectorPosition operator +(VectorPosition first, VectorPosition second) =>
            new VectorPosition(first.x + second.x, first.y + second.y);
        
        public static VectorPosition operator -(VectorPosition first, VectorPosition second) =>
            new VectorPosition(first.x - second.x, first.y - second.y);

        public static VectorPosition operator *(VectorPosition vectorPosition, double multiplier) =>
            new VectorPosition(vectorPosition.x * multiplier, vectorPosition.y * multiplier);
    }
}