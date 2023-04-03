using Microsoft.Extensions.DependencyInjection;
using Moq;

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
            IServiceCollection services = new ServiceCollection()
                .AddTransient(c => new Mock<ICar>());

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
            IServiceCollection services = new ServiceCollection()
                .AddSingleton(c => new Mock<ICar>());

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
            IServiceCollection services = new ServiceCollection()
                .AddScoped(c => new Mock<ICar>());

            var ServiceProvider = services.BuildServiceProvider();

            using IServiceScope scope1 = ServiceProvider.CreateScope();
            using IServiceScope scope2 = ServiceProvider.CreateScope();

            // Arrange
            var car1 = ServiceProvider.GetRequiredService<Mock<ICar>>();
            var car2 = ServiceProvider.GetRequiredService<Mock<ICar>>();

            var car3 = scope1.ServiceProvider.GetRequiredService<Mock<ICar>>();
            var car4 = scope2.ServiceProvider.GetRequiredService<Mock<ICar>>();

            // Act
            car1.Object.Beep();
            car2.Object.Beep();
            car3.Object.Beep();

            // Assert
            car1.Verify(car => car.Beep(), Times.Exactly(2));
            car2.Verify(car => car.Beep(), Times.Exactly(2));

            car3.Verify(car => car.Beep(), Times.Once());
            car4.Verify(car => car.Beep(), Times.Never());
        }

        public interface ICar
        {
            public void Beep();
        }
    }
}
