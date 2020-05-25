using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using NUnitTest.Entities;
using NUnitTest.Handlers;
using NUnitTest.Payloads;
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
            _conveyor = _serviceProvider.GetService<IConveyor>();
        }

        [Test]
        public void ServicesAreAvailableTest()
        {
            _conveyor ??= _serviceProvider.GetService<IConveyor>();
            Assert.NotNull(_conveyor);

            var someHandler = _serviceProvider.GetService<ChangeNameHandler>();
            Assert.NotNull(someHandler);
        }

        [Test]
        public async Task ChangeEntityTest()
        {

            var entity = new TestEntity();

            var payload = new ChangeTestEntityPayload()
            {
                Name = "User 1",
                Description = "Description 1"
            };

            var conveyor = _serviceProvider.GetService<IConveyor>();

            Assert.NotNull(conveyor);
            var store = new SimpleEntitiesStore(conveyor);

            await store.ChangeEntity(entity, payload);

            Assert.NotNull(entity.Name);
            Assert.NotNull(entity.Description);

            Assert.Null(entity.Timestamp);
            Assert.NotNull(entity.Id);
            await store.AfterChangeEntity(entity, payload);

            Assert.NotNull(entity.Timestamp);
        }
    }
}