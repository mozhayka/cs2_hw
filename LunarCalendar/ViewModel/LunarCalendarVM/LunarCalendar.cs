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

            var sign = $"{dayInfo.LunarPosition.StartSign}" + 
                (dayInfo.LunarPosition.EndSign != dayInfo.LunarPosition.StartSign ? $", {dayInfo.LunarPosition.EndSign}" : "");
            sb.AppendLine($"Луна в знаке: {sign}");

            var phase = $"{dayInfo.LunarPosition.StartPhase}" +
                (dayInfo.LunarPosition.EndPhase != dayInfo.LunarPosition.StartPhase ? $", {dayInfo.LunarPosition.EndPhase}" : "");
            sb.AppendLine($"Фаза Луны: {phase}");

            var ingression = $"{(dayInfo.LunarPosition.LunarIngression == null ? '-' : $"+\n знак {dayInfo.LunarPosition.EndSign}\n время {dayInfo.LunarPosition.LunarIngression}")}";
            sb.AppendLine($"Ингрессия Луны: {ingression}");
            return sb.ToString();
        }
    }
}
