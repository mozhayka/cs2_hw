using Calculator;
using LunarCalendarVM;
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
                lbk => lbk.FindAllLBK(It.IsAny<CalculationParameters>(), It.IsAny<bool>()) == new List<LBK>());
            var parameters = new CalculationParameters(new DateTime(2023, 04, 20));
            // Act
            var lbk = stubLBK.FindAllLBK(parameters, true);

            // Assert
            Assert.That(lbk, Is.EqualTo(new List<LBK>()));
        }

        [Test]
        public void Test_Mock_DayInformationCalculator()
        {
            // Arrange
            var mockAspect = new Mock<IAspectCalculator>();
            var mockLBK = new Mock<ILBKCalculator>();
            var lunarLBK = new Mock<ILunarPositionCalculator>();
            var calculator = new DayInformationCalculator(mockAspect.Object, mockLBK.Object, lunarLBK.Object);

            var parameters = new CalculationParameters(new DateTime(2023, 04, 20));

            // Act
            calculator.Calculate(parameters);

            // Assert
            mockAspect.Verify(asp => asp.FindLunarAspects(parameters));
            mockLBK.Verify(lbk => lbk.FindAllLBK(parameters, true));
        }
    }
}
