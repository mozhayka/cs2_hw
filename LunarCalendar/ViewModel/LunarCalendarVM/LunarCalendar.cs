using Calculator;
using Objects;
using System.Text;

namespace LunarCalendarVM
{
    public class LunarCalendar : ILunarCalendar
    {
        private readonly IDayInformationCalculator Calculator;

        public LunarCalendar(IDayInformationCalculator calculator)
        {
            Calculator = calculator;
        }

        public DayInformation GetDayInformation(DateTime Date)
        {
            var parameters = new CalculationParameters(Date);
            var dayInfo = Calculator.Calculate(parameters);
            return dayInfo;
        }

        public string InfoToString(DayInformation dayInfo)
        {
            StringBuilder sb = new();
            sb.AppendLine($"{dayInfo.Input.DateUTC}");
            sb.AppendLine($"Луна в знаке: {GetSign(dayInfo)}");
            sb.AppendLine($"Фаза Луны: {GetPhase(dayInfo)}");
            sb.AppendLine($"Ингрессия Луны: {GetIngression(dayInfo)}");

            return sb.ToString();
        }

        private string GetSign(DayInformation dayInfo)
        {
            return $"{RussianTranslator.ToRussian(dayInfo.LunarPosition.StartSign)}" +
                (dayInfo.LunarPosition.EndSign != dayInfo.LunarPosition.StartSign ? $", {RussianTranslator.ToRussian(dayInfo.LunarPosition.EndSign)}" : "");
        }

        private string GetPhase(DayInformation dayInfo)
        {
            return $"{RussianTranslator.ToRussian(dayInfo.LunarPosition.StartPhase)}" +
                (dayInfo.LunarPosition.EndPhase != dayInfo.LunarPosition.StartPhase ? $", {RussianTranslator.ToRussian(dayInfo.LunarPosition.EndPhase)}" : "");
        }

        private string GetIngression(DayInformation dayInfo)
        {
            return $"{(dayInfo.LunarPosition.LunarIngression == null ? '-' : $"+\n знак {RussianTranslator.ToRussian(dayInfo.LunarPosition.EndSign)}\n время {dayInfo.LunarPosition.LunarIngression}")}";
        }
    }
}
