using Calculator.Helper;
using Objects;

namespace Calculator
{
    public class LBKCalculator : ILBKCalculator
    {
        private IPlanetPositionCalculator calculator;

        public LBKCalculator(IPlanetPositionCalculator calculator)
        {
            this.calculator = calculator;
        }

        public List<LBK> FindAllLBK(DateTime day, Coordinates coordinates)
        {
            throw new NotImplementedException();
        }
    }
}
