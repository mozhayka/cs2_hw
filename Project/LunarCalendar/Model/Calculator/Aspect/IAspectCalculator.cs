using Objects;

namespace Calculator
{
    public interface IAspectCalculator
    {
        public List<LunarAspect> FindLunarAspects(DateTime date, Coordinates coordinates, bool septener);
        public List<LunarAspect> FindLunarAspects(double jdFrom, double jdTo, Coordinates coordinates, bool septener);
    }
}
