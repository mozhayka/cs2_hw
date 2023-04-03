using Calculator;
using Moq;
using NUnit.Framework.Internal;
using Objects;

namespace TestProject
{
    internal class TestMoq_DayInformationCalculator
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Stub_LBKCalculator()
        {
            // Arrange
            var stubLBK = Mock.Of<ILBKCalculator>(
                lbk => lbk.FindAllLBK(It.IsAny<DateTime>(), It.IsAny<Coordinates>()) == new List<LBK>());

            // Act
            var lbk = stubLBK.FindAllLBK(new DateTime(), new Coordinates(0, 0));

            // Assert
            Assert.That(lbk, Is.EqualTo(new List<LBK>()));
        }

        [Test]
        public void Test_Mock_DayInformationCalculator()
        {
            // Arrange
            var mockAspect = new Mock<IAspectCalculator>();
            var mockLBK = new Mock<ILBKCalculator>();
            var calculator = new DayInformationCalculator(mockAspect.Object, mockLBK.Object);

            var date = new DateTime(2023, 4, 2);
            var coordinates = new Coordinates(100, 100);

            // Act
            calculator.Calculate(date, coordinates);

            // Assert
            mockAspect.Verify(asp => asp.FindAllAspects(date, coordinates));
            mockLBK.Verify(lbk => lbk.FindAllLBK(date, coordinates));
        }
    }
}
