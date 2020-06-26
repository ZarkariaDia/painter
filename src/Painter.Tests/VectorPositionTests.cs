using FluentAssertions;
using FluentAssertions.Common;
using NUnit.Framework;
using Painter.Geometry;

namespace Painter.Tests
{
    [TestFixture]
    internal class VectorPositionTests
    {
        [TestCase(3, 4, 5)]
        [TestCase(-3, 4, 5)]
        [TestCase(-3, -4, 5)]
        [TestCase(3, -4, 5)]
        [TestCase(double.PositiveInfinity, 5, double.PositiveInfinity)]
        [TestCase(double.NegativeInfinity, 5, double.PositiveInfinity)]
        [TestCase(5,double.PositiveInfinity, double.PositiveInfinity)]
        [TestCase(5, double.NegativeInfinity, double.PositiveInfinity)]
        public void Test_length_in_meters_correctness(double x, double y, double length)
        {
            VectorPosition.FromMeters(x, y).MetersLength.IsSameOrEqualTo(length);
        }

        [TestCase(3, 4, 5)]
        [TestCase(-3, 4, 5)]
        [TestCase(-3, -4, 5)]
        [TestCase(3, -4, 5)]
        [TestCase(double.PositiveInfinity, 5, double.PositiveInfinity)]
        [TestCase(double.NegativeInfinity, 5, double.PositiveInfinity)]
        [TestCase(5,double.PositiveInfinity, double.PositiveInfinity)]
        [TestCase(5, double.NegativeInfinity, double.PositiveInfinity)]
        public void Test_length_in_centimeters_correctness(double x, double y, double length)
        {
            VectorPosition.FromCentimeters(x, y).CentimetersLength.IsSameOrEqualTo(length);
        }

        [TestCase(3, 4, 5)]
        [TestCase(-3, 4, 5)]
        [TestCase(-3, -4, 5)]
        [TestCase(3, -4, 5)]
        [TestCase(double.PositiveInfinity, 5, double.PositiveInfinity)]
        [TestCase(double.NegativeInfinity, 5, double.PositiveInfinity)]
        [TestCase(5,double.PositiveInfinity, double.PositiveInfinity)]
        [TestCase(5, double.NegativeInfinity, double.PositiveInfinity)]
        public void Test_length_in_millimeters_correctness(double x, double y, double length)
        {
            VectorPosition.FromMillimeters(x, y).MillimetersLength.IsSameOrEqualTo(length);
        }

        [TestCase(3, 4, 5)]
        [TestCase(-3, 4, 5)]
        [TestCase(-3, -4, 5)]
        [TestCase(3, -4, 5)]
        [TestCase(double.PositiveInfinity, 5, double.PositiveInfinity)]
        [TestCase(double.NegativeInfinity, 5, double.PositiveInfinity)]
        [TestCase(5,double.PositiveInfinity, double.PositiveInfinity)]
        [TestCase(5, double.NegativeInfinity, double.PositiveInfinity)]
        public void Test_length_relationships(double metersX, double metersY, double metersLength)
        {
            var position = VectorPosition.FromMeters(metersX, metersY);

            position.MetersLength.IsSameOrEqualTo(metersLength);
            position.CentimetersLength.IsSameOrEqualTo(metersLength * 100);
            position.MillimetersLength.IsSameOrEqualTo(metersLength * 1000);
        }

        [TestCase(3, 4, true)]
        [TestCase(-3, 4, true)]
        [TestCase(-3, -4, true)]
        [TestCase(3, -4, true)]
        [TestCase(double.PositiveInfinity, 5, false)]
        [TestCase(double.NegativeInfinity, 5, false)]
        [TestCase(5, double.PositiveInfinity, false)]
        [TestCase(5, double.NegativeInfinity, false)]
        public void Test_reachability(double metersX, double metersY, bool isReachable)
        {
            var position = VectorPosition.FromMeters(metersX, metersY);

            position.IsReachable.Should().Be(isReachable);
        }
    }
}
