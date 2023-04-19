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

        public List<LBK> FindAllLBK(CalculationParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
