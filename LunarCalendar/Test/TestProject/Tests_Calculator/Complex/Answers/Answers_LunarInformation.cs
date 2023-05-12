using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;

namespace TestProject.Tests_Calculator.Answers
{
    internal class Answers_LunarInformation
    {
        public static LunarInformation _2020_01_13 = new()
        {
            LunarIngression = new DateTime(2020, 01, 13, 17, 06, 00).AddHours(-3),

            StartPhase = LunarPhase.Full_Moon,
            EndPhase = LunarPhase.Full_Moon,

            StartSign = Zodiac.Leo,
            EndSign = Zodiac.Virgo,
        };


        public static LunarInformation _2020_05_13 = new()
        {
            LunarIngression = null,

            StartPhase = LunarPhase.Last_Quarter,
            EndPhase = LunarPhase.Last_Quarter,

            StartSign = Zodiac.Aquarius,
            EndSign = Zodiac.Aquarius,
        };

        public static LunarInformation _2021_02_19 = new()
        {
            LunarIngression = new DateTime(2021, 02, 19, 19, 03, 00).AddHours(-3),

            StartPhase = LunarPhase.First_Quarter,
            EndPhase = LunarPhase.First_Quarter,

            StartSign = Zodiac.Taurus,
            EndSign = Zodiac.Gemini,
        };

        public static void CompareLunarInformation(LunarInformation actual, LunarInformation expected)
        {
            Assert.Multiple(() =>
            {
                Assert.That(actual.LunarIngression, Is.EqualTo(expected.LunarIngression).Within(TimeSpan.FromMinutes(1)));

                Assert.That(actual.StartPhase, Is.EqualTo(expected.StartPhase));
                Assert.That(actual.EndPhase, Is.EqualTo(expected.EndPhase));

                Assert.That(actual.StartSign, Is.EqualTo(expected.StartSign));
                Assert.That(actual.EndSign, Is.EqualTo(expected.EndSign));
            });
        }
    }
}
