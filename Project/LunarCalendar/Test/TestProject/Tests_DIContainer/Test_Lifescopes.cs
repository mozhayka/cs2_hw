using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Objects;

namespace TestProject.Tests_DIContainer
{
    public class Test_Lifescopes
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Transient()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient(c => new Mock<ICar>());

            var ServiceProvider = services.BuildServiceProvider();

            // Arrange
            var car1 = ServiceProvider.GetRequiredService<Mock<ICar>>();
            var car2 = ServiceProvider.GetRequiredService<Mock<ICar>>();

            // Act
            car1.Object.Beep();

            // Assert
            car1.Verify(car => car.Beep(), Times.Once());
            car2.Verify(car => car.Beep(), Times.Never());
        }

        [Test]
        public void Test_Singleton()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton(c => new Mock<ICar>());

            var ServiceProvider = services.BuildServiceProvider();

            // Arrange
            var car1 = ServiceProvider.GetRequiredService<Mock<ICar>>();
            var car2 = ServiceProvider.GetRequiredService<Mock<ICar>>();

            // Act
            car1.Object.Beep();

            // Assert
            car1.Verify(car => car.Beep(), Times.Once());
            car2.Verify(car => car.Beep(), Times.Once());
        }

        [Test]
        public void Test_Scoped()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped(c => new Mock<ICar>());

            var ServiceProvider = services.BuildServiceProvider();

            using (IServiceScope newScope = ServiceProvider.CreateScope())
            {
                // Arrange
                var car1 = ServiceProvider.GetRequiredService<Mock<ICar>>();
                var car2 = ServiceProvider.GetRequiredService<Mock<ICar>>();

                using (IServiceScope newScope2 = ServiceProvider.CreateScope())
                {
                    var car3 = ServiceProvider.GetRequiredService<Mock<ICar>>();
                    var car4 = ServiceProvider.GetRequiredService<Mock<ICar>>();

                    // Act
                    car1.Object.Beep();

                    // Assert
                    car1.Verify(car => car.Beep(), Times.Once());
                    car2.Verify(car => car.Beep(), Times.Once());

                    car3.Verify(car => car.Beep(), Times.Never());
                    car4.Verify(car => car.Beep(), Times.Never());
                }
            }
        }

        public interface ICar
        {
            public void Beep();
        }
    }
}
