using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;

namespace TestProject.Tests_Calculator.Answers
{
    static class Answers_DayInformation
    {
        public static DayInformation _2020_01_13 = new
        (
            new CalculationParameters(new DateTime(2020, 01, 13).AddHours(-3)),
            Answers_LunarInformation._2020_01_13,
            Answers_LunarAspects.aspects_2020_01_13_all,

            Answers_LBK.lbk_2020_01_13_septener,
            Answers_LBK.lbk_2020_01_13_all
        );

        public static DayInformation _2020_05_13 = new
        (
            new CalculationParameters(new DateTime(2020, 05, 13).AddHours(-3)),
            Answers_LunarInformation._2020_05_13,
            Answers_LunarAspects.aspects_2020_05_13_all,

            Answers_LBK.lbk_2020_05_13_septener,
            Answers_LBK.lbk_2020_05_13_all
        );

        public static DayInformation _2021_02_19 = new
        (
            new CalculationParameters(new DateTime(2021, 02, 19).AddHours(-3)),
            Answers_LunarInformation._2021_02_19,
            Answers_LunarAspects.aspects_2021_02_19_all,

            Answers_LBK.lbk_2021_02_19_septener,
            Answers_LBK.lbk_2021_02_19_all
        );

        public static void CompareDayInformation(DayInformation actual, DayInformation expected)
        {
            Assert.Multiple(() =>
            {
                Assert.That(actual.Input.DateUTC, Is.EqualTo(expected.Input.DateUTC));
                Assert.That(actual.Input.Coordinates, Is.EqualTo(expected.Input.Coordinates));

                Answers_LunarInformation.CompareLunarInformation(actual.LunarPosition, expected.LunarPosition);
                Answers_LunarAspects.CompareLunarAspects(actual.LunarAspects, expected.LunarAspects);

                Answers_LBK.CompareLBK(actual.LBKSeptener, expected.LBKSeptener);
                Answers_LBK.CompareLBK(actual.LBKAll, expected.LBKAll);
            });
        }
    }
}
