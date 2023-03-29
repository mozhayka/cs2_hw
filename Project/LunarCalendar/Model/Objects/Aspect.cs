namespace Objects
{
    // Liskov Substitution Principle - солнечные и лунные затмения хотим выделить среди остальных аспектов
    // при этом мы можем рассматривать их наравне с остальными аспектами
    public class Aspect
    {
        public DateTime ExactTime { get; set; }
        public AstroObject AstroObject1 { get; set; }
        public AstroObject AstroObject2 { get; set; }
    }

    public class Eclipse : Aspect
    {

    }
}
