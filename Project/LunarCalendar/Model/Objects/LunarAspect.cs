namespace Objects
{
    // Liskov Substitution Principle - солнечные и лунные затмения хотим выделить среди остальных аспектов
    // при этом мы можем рассматривать их наравне с остальными аспектами
    public class LunarAspect
    {
        public DateTime ExactTime { get; set; }
        public AstroObject AstroObject { get; set; }
        public AspectType Type { get; set; }

        public LunarAspect(DateTime exactTime, AstroObject astroObject, AspectType type)
        {
            ExactTime = exactTime;
            AstroObject = astroObject;
            Type = type;
        }
    }

    public class Eclipse : LunarAspect
    {
        public Eclipse(DateTime exactTime, AspectType type) 
            : base(exactTime, AstroObject.Sun, type)
        {
        }
    }
}
