using Calculator;

namespace TestProject
{
    internal class Test_TimeCalculator
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1_GetJulDay()
        {
            var utcDate = new DateTime(1977, 8, 1);

            var expected = 2443356.5;
            var actual = TimeCalculator.GetJulDay(utcDate);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test1_FromJulDay()
        {
            var julday = 2443356.5;

            var expected = new DateTime(1977, 8, 1);
            var actual = TimeCalculator.FromJulDay(julday);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
