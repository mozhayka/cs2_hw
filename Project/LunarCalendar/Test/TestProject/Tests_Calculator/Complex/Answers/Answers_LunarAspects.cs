using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;

namespace TestProject.Tests_Calculator.Answers
{
    internal class Answers_LunarAspects
    {
        public static List<LunarAspect> aspects_2020_01_13_all = new()
        {
            new LunarAspect(new DateTime(2020, 01, 13, 16, 41, 00).AddHours(-3), AstroObject.Venus, AspectType.Opposition, Zodiac.Leo, Zodiac.Aquarius, new DMS(30, 0, 0)),
            new LunarAspect(new DateTime(2020, 01, 13, 21, 29, 00).AddHours(-3), AstroObject.Uranus, AspectType.Trine, Zodiac.Virgo, Zodiac.Taurus, new DMS(3, 0, 0)),
        };

        public static List<LunarAspect> aspects_2020_01_13_septener = new()
        {
            new LunarAspect(new DateTime(2020, 01, 13, 16, 41, 00).AddHours(-3), AstroObject.Venus, AspectType.Opposition, Zodiac.Leo, Zodiac.Aquarius, new DMS(30, 0, 0)),
        };


        public static List<LunarAspect> aspects_2020_05_13_all = new()
        {
            new LunarAspect(new DateTime(2020, 05, 13, 08, 51, 00).AddHours(-3), AstroObject.Uranus, AspectType.Square, Zodiac.Aquarius, Zodiac.Taurus, new DMS(08, 0, 0)),
        };

        public static List<LunarAspect> aspects_2020_05_13_septener = new()
        {
        };


        public static List<LunarAspect> aspects_2021_02_19_all = new()
        {
            new LunarAspect(new DateTime(2021, 02, 19, 02, 21, 00).AddHours(-3), AstroObject.Venus, AspectType.Square, Zodiac.Taurus, Zodiac.Aquarius, new DMS(22, 0, 0)),
            new LunarAspect(new DateTime(2021, 02, 19, 03, 48, 00).AddHours(-3), AstroObject.Mars, AspectType.Conjunction, Zodiac.Taurus, Zodiac.Taurus, new DMS(23, 0, 0)),
            new LunarAspect(new DateTime(2021, 02, 19, 10, 28, 00).AddHours(-3), AstroObject.Pluto, AspectType.Trine, Zodiac.Taurus, Zodiac.Capricornus, new DMS(26, 0, 0)),
            new LunarAspect(new DateTime(2021, 02, 19, 21, 47, 00).AddHours(-3), AstroObject.Sun, AspectType.Square, Zodiac.Gemini, Zodiac.Pisces, new DMS(02, 0, 0)),
        };

        public static List<LunarAspect> aspects_2021_02_19_septener = new()
        {
            new LunarAspect(new DateTime(2021, 02, 19, 02, 21, 00).AddHours(-3), AstroObject.Venus, AspectType.Square, Zodiac.Taurus, Zodiac.Aquarius, new DMS(22, 0, 0)),
            new LunarAspect(new DateTime(2021, 02, 19, 03, 48, 00).AddHours(-3), AstroObject.Mars, AspectType.Conjunction, Zodiac.Taurus, Zodiac.Taurus, new DMS(23, 0, 0)),
            new LunarAspect(new DateTime(2021, 02, 19, 21, 47, 00).AddHours(-3), AstroObject.Sun, AspectType.Square, Zodiac.Gemini, Zodiac.Pisces, new DMS(02, 0, 0)),
        };


        public static void CompareLunarAspects(List<LunarAspect> actual, List<LunarAspect> expected)
        {
            Assert.Multiple(() =>
            {
                Assert.That(actual, Has.Count.EqualTo(expected.Count));
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.That(actual[i].AstroObject, Is.EqualTo(expected[i].AstroObject));
                    Assert.That(actual[i].Type, Is.EqualTo(expected[i].Type));
                    Assert.That(actual[i].ExactTime, Is.EqualTo(expected[i].ExactTime).Within(TimeSpan.FromMinutes(1)));
                    Assert.That(actual[i].MoonInZodiac, Is.EqualTo(expected[i].MoonInZodiac));
                    Assert.That(actual[i].PlanetInZodiac, Is.EqualTo(expected[i].PlanetInZodiac));
                    Assert.That((actual[i].MoonPosition.RoundToDegrees() - 1) % 30 + 1, Is.EqualTo(expected[i].MoonPosition.Degrees));
                }
            });
        }
    }
}
