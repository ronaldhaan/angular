using Microsoft.AspNetCore.Mvc;
using System;
using Tour.Heroes.Api;
using Tour.Heroes.Api.Controllers;
using Tour.Heroes.Api.Models.Entities;
using Tour.Heroes.Api.Models.MutateModels;
using Tour.Heroes.Api.Models.RequestModels;
using Xunit;

namespace Tour.Heroes.XUnit
{
    public class MetaHumansControllerUnitTest
    {
        private readonly HeroDbContext _context;
        private Guid id;

        public MetaHumansControllerUnitTest()
        {
            var factory = new HeroDbContextFactory();
            _context = factory.CreateDbContext(null);
        }

        [Fact]
        public void ATestGetAll()
        {
            MetaHumansController controller = new MetaHumansController(_context, null);
            CollectionRequestModel collection = new CollectionRequestModel();
            IActionResult a = controller.Get(collection);

            OkObjectResult ok = a as OkObjectResult;

            Assert.NotNull(ok);
            Assert.Equal(200, ok.StatusCode);
        }

        [Fact]
        public async void BTestCreate()
        {
            Guid id = Guid.NewGuid();
            this.id = id;
            MetaHuman mutateModel = new MetaHuman
            {
                Id = id,
                Name = "TestMeta",
                Description = "This is a meta created by the unit test",
                AlterEgo = "Unit test",
                Status = 0
            };

            MetaHumansController controller = new MetaHumansController(_context, null);
            CollectionRequestModel collection = new CollectionRequestModel()
            {
                Name = "s",
                Skip = 1
            };

            IActionResult result = await controller.Post(mutateModel);

            OkObjectResult ok = result as OkObjectResult;

            Assert.NotNull(ok);
            Assert.Equal(200, ok.StatusCode);
        }

        [Fact]
        public async void CTestGetOne()
        {
            MetaHumansController controller = new MetaHumansController(_context, null);
            IActionResult result = await controller.Get(this.id);

            OkObjectResult ok = result as OkObjectResult;

            Assert.NotNull(ok);
            Assert.Equal(200, ok.StatusCode);
        }

        [Fact]
        public async void DTestPut()
        {
            MetaHumanMutateModel mutateModel = new MetaHumanMutateModel
            {
                Name = "TestMetaUpdated",
                Description = "This is a meta created by the unit test",
                AlterEgo = "Unit test",
                Status = 0
            };

            MetaHumansController controller = new MetaHumansController(_context, null);
            IActionResult result = await controller.Put(this.id, mutateModel);

            OkObjectResult ok = result as OkObjectResult;

            Assert.NotNull(ok);
            Assert.Equal(200, ok.StatusCode);
        }

        [Fact]
        public async void ETestDelete()
        {
            MetaHumansController controller = new MetaHumansController(_context, null);
            IActionResult result = await controller.Delete(this.id);

            OkObjectResult ok = result as OkObjectResult;

            Assert.NotNull(ok);
            Assert.Equal(200, ok.StatusCode);
            this.id = Guid.Empty;

            Assert.NotNull(ok);
            Assert.Equal(200, ok.StatusCode);
        }
    }
}
