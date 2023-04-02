using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
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
            mockAspect.Verify(lw => lw.FindAllAspects(date, coordinates));
            mockLBK.Verify(lw => lw.FindAllLBK(date, coordinates));
        }
    }
}
