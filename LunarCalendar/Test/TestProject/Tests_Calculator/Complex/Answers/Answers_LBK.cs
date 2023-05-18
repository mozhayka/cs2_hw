using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;

namespace TestProject.Tests_Calculator.Answers
{
    internal class Answers_LBK
    {
        public static List<LBK> lbk_2020_01_13_septener = new()
        {
            new LBK(new DateTime(2020, 01, 13, 16, 42, 00).AddHours(-3), new DateTime(2020, 01, 13, 17, 06, 00).AddHours(-3)),
        };

        public static List<LBK> lbk_2020_01_13_all = new()
        {
            new LBK(new DateTime(2020, 01, 13, 16, 42, 00).AddHours(-3), new DateTime(2020, 01, 13, 17, 06, 00).AddHours(-3)),
        };


        public static List<LBK> lbk_2020_05_13_all = new()
        {
        };

        public static List<LBK> lbk_2020_05_13_septener = new()
        {
        };


        public static List<LBK> lbk_2021_02_19_all = new()
        {
            new LBK(new DateTime(2021, 02, 19, 10, 28, 00).AddHours(-3), new DateTime(2021, 02, 19, 19, 03, 00).AddHours(-3)),
        };

        public static List<LBK> lbk_2021_02_19_septener = new()
        {
            new LBK(new DateTime(2021, 02, 19, 03, 48, 00).AddHours(-3), new DateTime(2021, 02, 19, 19, 03, 00).AddHours(-3)),
        };

        public static void CompareLBK(List<LBK> actual, List<LBK> expected)
        {
            Assert.Multiple(() =>
            {
                Assert.That(actual, Has.Count.EqualTo(expected.Count));
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.That(actual[i].From, Is.EqualTo(expected[i].From).Within(TimeSpan.FromMinutes(1)));
                    Assert.That(actual[i].To, Is.EqualTo(expected[i].To).Within(TimeSpan.FromMinutes(1)));
                }
            });
        }
    }
}
