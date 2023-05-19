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

        public string GetDayInfoRus(DateTime Date, int UTC)
        {
            DayInformation dayInfo = GetDayInformation(Date.AddHours(-UTC));
            StringBuilder sb = new();
            sb.AppendLine($"{dayInfo.Input.DateUTC.AddHours(UTC):D} UTC {(UTC >= 0 ? "+" : "")}{UTC}");
            sb.AppendLine($"Луна в знаке: {GetSign(dayInfo)}");
            sb.AppendLine($"Фаза Луны: {GetPhase(dayInfo)}");
            sb.AppendLine($"");
            sb.AppendLine($"Ингрессия Луны: {GetIngression(dayInfo, UTC)}");
            sb.AppendLine($"");
            sb.AppendLine($"Луна без курса (септенер): {GetLBK(dayInfo.LBKSeptener, UTC)}");
            sb.AppendLine($"Луна без курса (с высшими планетами): {GetLBK(dayInfo.LBKAll, UTC)}");
            sb.AppendLine($"");
            sb.AppendLine($"Аспекты Луны с планетами:\n{GetAspects(dayInfo, UTC)}");

            return sb.ToString();
        }

        private string GetSign(DayInformation dayInfo)
        {
            return $"{RussianTranslator.ToRussian(dayInfo.LunarPosition.StartSign)}" +
                (dayInfo.LunarPosition.EndSign != dayInfo.LunarPosition.StartSign ? $", {RussianTranslator.ToRussian(dayInfo.LunarPosition.EndSign)}" : "");
        }

        private string GetPhase(DayInformation dayInfo)
        {
            return (dayInfo.LunarPosition.StartPhase == dayInfo.LunarPosition.EndPhase) ? 
               RussianTranslator.ToRussianPeriod(dayInfo.LunarPosition.EndPhase) : 
               RussianTranslator.ToRussianExact(dayInfo.LunarPosition.EndPhase);
        }

        private string GetIngression(DayInformation dayInfo, int UTC)
        {
            return $"{(dayInfo.LunarPosition.LunarIngression == null ? '-' : $"+\n знак {RussianTranslator.ToRussian(dayInfo.LunarPosition.EndSign)}\n время {((DateTime)dayInfo.LunarPosition.LunarIngression).AddHours(UTC):t}")}";
        }

        private string GetLBK(List<LBK> LBK, int UTC)
        {
            if (LBK.Count == 0) 
            {
                return "-";
            }
            if (LBK.Count == 1)
            {
                return $"{LBK[0].From.AddHours(UTC):t}-{LBK[0].To.AddHours(UTC):t}";
            }
            if (LBK.Count == 2)
            {
                return $"{LBK[0].From.AddHours(UTC):t}-{LBK[0].To.AddHours(UTC):t}, {LBK[1].From.AddHours(UTC):t}-{LBK[1].To.AddHours(UTC):t}";
            }
            throw new Exception("Unknown LBK");
        }

        private string GetAspects(DayInformation dayInfo, int UTC) 
        {
            StringBuilder sb = new();
            foreach (var aspect in dayInfo.LunarAspects)
            {
                sb.AppendLine($"{RussianTranslator.ToRussian(AstroObject.Moon)} " +
                    $"{RussianTranslator.ToRussian(aspect.Type)} " +
                    $"{RussianTranslator.ToRussian(aspect.AstroObject)} " +
                    $"{aspect.ExactTime.AddHours(UTC):t} ({aspect.MoonPosition.Degrees}° " +
                    $"{RussianTranslator.ToRussian(aspect.MoonInZodiac)}-" +
                    $"{RussianTranslator.ToRussian(aspect.PlanetInZodiac)})");
            }
            return sb.ToString();
        }
    }
}
