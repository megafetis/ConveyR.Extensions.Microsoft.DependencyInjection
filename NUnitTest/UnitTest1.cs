using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using NUnitTest.Handlers;
using ÑonveyoR;

namespace NUnitTest
{
    public class Tests
    {
        private ServiceProvider _serviceProvider;

        private IConveyor _conveyor;
        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddConveyorR(typeof(Tests).Assembly);
            _serviceProvider = services.BuildServiceProvider();
        }

        [Test]
        public void ServicesAreAvailableTest()
        {
            _conveyor = _serviceProvider.GetService<IConveyor>();
            Assert.NotNull(_conveyor);

            var someHandler = _serviceProvider.GetService<ChangeNameHandler>();
            Assert.NotNull(someHandler);
        }

        [Test]
        public void ServicesAreAvailableTest1()
        {

            Assert.NotNull(_conveyor);

        }
    }
}