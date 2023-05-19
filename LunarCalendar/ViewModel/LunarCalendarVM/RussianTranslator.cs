using Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarCalendarVM
{
    internal class RussianTranslator
    {
        public static string ToRussian(AspectType asp)
        {
            return asp switch
            {
                AspectType.Conjunction => "Соединение",
                AspectType.Opposition => "Оппозиция",
                AspectType.Square => "Квадрат",
                AspectType.Trine => "Трин",
                AspectType.Sextile => "Секстиль",
                _ => throw new Exception("Unknown type"),
            };
        }

        public static string ToRussianExact(LunarPhase lp)
        {
            return lp switch
            {
                LunarPhase.New_Moon => "Новолуние",
                LunarPhase.First_Quarter => "1 четверть",
                LunarPhase.Full_Moon => "Полнолуние",
                LunarPhase.Last_Quarter => "3 четверть",
                _ => throw new Exception("Unknown phase"),
            };
        }

        public static string ToRussianPeriod(LunarPhase lp)
        {
            return lp switch
            {
                LunarPhase.New_Moon => "Растущая Луна после новолуния",
                LunarPhase.First_Quarter => "Растущая Луна после 1 четверти",
                LunarPhase.Full_Moon => "Убывающая Луна после полнолуния",
                LunarPhase.Last_Quarter => "Убывающая луна после 3 четверти",
                _ => throw new Exception("Unknown phase"),
            };
        }

        public static string ToRussian(Zodiac z)
        {
            return z switch
            {
                Zodiac.Aries => "Овен",
                Zodiac.Taurus => "Телец",
                Zodiac.Gemini => "Близнецы",

                Zodiac.Cancer => "Рак",
                Zodiac.Leo => "Лев",
                Zodiac.Virgo => "Дева",

                Zodiac.Libra => "Весы",
                Zodiac.Scorpio => "Скорпион",
                Zodiac.Sagittarius => "Стрелец",

                Zodiac.Capricornus => "Козирог",
                Zodiac.Aquarius => "Водолей",
                Zodiac.Pisces => "Рыбы",
                _ => throw new Exception("Unknown zodiac"),
            };
        }

        public static string ToRussian(AstroObject obj)
        {
            return obj switch
            {
                AstroObject.Moon => "Луна",
                AstroObject.Sun => "Солнце",
                AstroObject.Mercury => "Меркурий",
                AstroObject.Venus => "Венера",
                AstroObject.Mars => "Марс",
                AstroObject.Jupiter => "Юпитер",
                AstroObject.Saturn => "Сатурн",
                AstroObject.Uranus => "Уран",
                AstroObject.Neptune => "Нептун",
                AstroObject.Pluto => "Плутон",
                _ => throw new Exception("Unknown object"),
            };
        }

    }
}
