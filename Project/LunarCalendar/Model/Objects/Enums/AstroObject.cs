using System;

namespace Objects
{
    public enum AstroObject
    {
        Moon,
        Sun,
        Mercury,
        Venus,
        Mars,
        Jupiter,
        Saturn,
        Uranus,
        Neptune,
        Pluto,
    }

    public static class InterestingPlanets
    {
        public static readonly AstroObject[] All = (AstroObject[])Enum.GetValues(typeof(AstroObject));
        public static readonly AstroObject[] Septener = new AstroObject[] {
            AstroObject.Moon,
            AstroObject.Sun,
            AstroObject.Mercury,
            AstroObject.Venus,
            AstroObject.Mars,
            AstroObject.Jupiter,
            AstroObject.Saturn,
        };
    }
}
