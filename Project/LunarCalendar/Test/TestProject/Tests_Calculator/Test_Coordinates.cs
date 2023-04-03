using Objects;

namespace TestProject
{
    internal class Test_Coordinates
    {
        [Test]
        public void Test1_CoordinatesFromDMS()
        {
            var longitude = new DMS(131, 54, 0);

            var expected = 131.9;
            var actual = longitude.ToDegrees();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test2_CoordinatesFromDMS()
        {
            var latitude = new DMS(43, 8, 0);

            var expected = 43.133333333333333;
            var actual = latitude.ToDegrees();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
