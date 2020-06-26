using System;

namespace Painter.Core
{
    public struct AngleSpan
    {
        
    }

    public struct Angle
    {
        private Angle(double degrees)
        {
            
        }

        public static Angle FromDegrees(double degrees)
        {
            return new Angle(degrees);
        }

        public static Angle FromRadians()
        {
            return new Angle();
        }
    }
}
