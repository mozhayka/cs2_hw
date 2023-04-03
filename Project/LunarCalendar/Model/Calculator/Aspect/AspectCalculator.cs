﻿using Calculator.Helper;
using Objects;

namespace Calculator
{
    // The Open-Closed Principle - AspectCalculator реализует поиск аспектов в сутках полным перебором
    // Можно реализовать более умный способ поиска, и тогда придется лишь изменить класс, реализующий интерфейс IAspectCalculator
    public class AspectsCalculator : IAspectCalculator
    {
        private IPlanetPositionCalculator calculator;

        public AspectsCalculator(IPlanetPositionCalculator calculator)
        {
            this.calculator = calculator;
        }

        public List<Aspect> FindAllAspects(DateTime day, Coordinates coorinates)
        {
            throw new NotImplementedException();
        }
    }
}
