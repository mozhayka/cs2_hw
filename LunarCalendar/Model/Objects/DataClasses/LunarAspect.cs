namespace Objects
{
    // Liskov Substitution Principle - солнечные и лунные затмения хотим выделить среди остальных аспектов
    // при этом мы можем рассматривать их наравне с остальными аспектами
    public class LunarAspect
    {
        public DateTime ExactTime { get; set; }
        public AstroObject AstroObject { get; set; }
        public AspectType Type { get; set; }
        public Zodiac MoonInZodiac { get; set; }
        public Zodiac PlanetInZodiac { get; set; }
        public DMS MoonPosition { get; set; }

        public LunarAspect(DateTime exactTime, AstroObject astroObject, AspectType type, Zodiac moonInZodiac, Zodiac planetInZodiac, DMS moonPosition)
        {
            ExactTime = exactTime;
            AstroObject = astroObject;
            Type = type;
            MoonInZodiac = moonInZodiac;
            PlanetInZodiac = planetInZodiac;
            MoonPosition = moonPosition;
        }
    }

    public class Eclipse : LunarAspect
    {
        public Eclipse(DateTime exactTime, AspectType type, Zodiac moonInZodiac, Zodiac planetInZodiac, DMS moonPosition) 
            : base(exactTime, AstroObject.Sun, type, moonInZodiac, planetInZodiac, moonPosition)
        {
        }
    }
}
