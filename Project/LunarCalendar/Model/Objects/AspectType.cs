using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public enum AspectType
    {
        Conjunction,
        Opposition,
        Square,
        Trine,
        Sextile,
    }

    public static class AspectTypeCalc
    {
        public static AspectType? GetAspectType(double angle, double eps)
        {
            if (IsConjunction(angle, eps))
                return AspectType.Conjunction;
            if (IsOpposition(angle, eps))
                return AspectType.Opposition;
            if (IsSquare(angle, eps))
                return AspectType.Square;
            if (IsTrine(angle, eps))
                return AspectType.Trine;
            if (IsSextile(angle, eps))
                return AspectType.Sextile;
            return null;
        }

        private static bool IsConjunction(double angle, double eps)
        {
            return Math.Abs(0 - angle) < eps;
        }

        private static bool IsOpposition(double angle, double eps)
        {
            return Math.Abs(180 - angle) < eps;
        }

        private static bool IsSquare(double angle, double eps)
        {
            return Math.Abs(90 - angle) < eps || Math.Abs(270 - angle) < eps;
        }

        private static bool IsTrine(double angle, double eps)
        {
            return Math.Abs(120 - angle) < eps || Math.Abs(240 - angle) < eps;
        }

        private static bool IsSextile(double angle, double eps)
        {
            return Math.Abs(60 - angle) < eps || Math.Abs(300 - angle) < eps;
        }
    }
}
