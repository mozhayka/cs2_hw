using Objects;

namespace Calculator
{
    public interface ILBKCalculator
    {
        public List<LBK> FindAllLBK(CalculationParameters parameters, bool septener);
    }
}
