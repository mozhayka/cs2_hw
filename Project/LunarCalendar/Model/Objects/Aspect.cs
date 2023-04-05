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

    // Liskov Substitution Principle - солнечные и лунные затмения хотим выделить среди остальных аспектов
    // при этом мы можем рассматривать их наравне с остальными аспектами
    public class Aspect
    {
        public DateTime ExactTime { get; set; }
        public AstroObject AstroObject1 { get; set; }
        public AstroObject AstroObject2 { get; set; }
        public AspectType Type { get; set; }

        public Aspect(DateTime exactTime, AstroObject astroObject1, AstroObject astroObject2, AspectType type)
        {
            ExactTime = exactTime;
            AstroObject1 = astroObject1;
            AstroObject2 = astroObject2;
            Type = type;
        }
    }

    public class Eclipse : Aspect
    {
        public Eclipse(DateTime exactTime, AstroObject astroObject1, AstroObject astroObject2, AspectType type) 
            : base(exactTime, astroObject1, astroObject2, type)
        {
        }
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
