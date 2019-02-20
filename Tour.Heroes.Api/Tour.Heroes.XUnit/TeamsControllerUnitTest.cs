using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tour.Heroes.Api;
using Tour.Heroes.Api.Controllers;
using Tour.Heroes.Api.Models.Entities;
using Tour.Heroes.Api.Models.MutateModels;
using Tour.Heroes.Api.Models.RequestModels;
using Xunit;


namespace Tour.Heroes.XUnit
{
    [Collection("Sequential")]
    public class TeamsControllerUnitTest
    {
        private const string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TourOfHeroesDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private readonly HeroDbContext _context;
        private Guid id = new Guid("{b33bdac6-b84f-4e66-9d4f-b398aac317c0}");

        public TeamsControllerUnitTest()
        {
            var factory = new HeroDbContextFactory();
            _context = factory.CreateDbContextByConnectionString(connString);
        }

        [Fact]
        public async Task Test0All()
        {
            Test1GetAll();
            await Test2Create();
            await Test3GetOne();
            await Test4Put();
            await Test5Delete();
        }

        [Fact]
        public void Test1GetAll()
        {
            TeamsController controller = new TeamsController(_context, null);
            CollectionRequestModel collection = new CollectionRequestModel();
            IActionResult a = controller.Get(collection);

            OkObjectResult ok = a as OkObjectResult;

            Assert.NotNull(ok);
            Assert.Equal(200, ok.StatusCode);
        }

        [Fact]
        public async Task Test2Create()
        {
            Team team = new Team
            {
                Id = this.id,
                Name = "TestTeam",
                Description = "This is a Team created by the unit test"
            };

            TeamsController controller = new TeamsController(_context, null);
            IActionResult result = await controller.Post(team);

            OkObjectResult ok = result as OkObjectResult;

            Assert.NotNull(ok);
            Assert.Equal(200, ok.StatusCode);
        }

        [Fact]
        public async Task Test3GetOne()
        {
            TeamsController controller = new TeamsController(_context, null);
            IActionResult result = await controller.Get(this.id);

            OkObjectResult ok = result as OkObjectResult;

            Assert.NotNull(ok);
            Assert.Equal(200, ok.StatusCode);
        }

        [Fact]
        public async Task Test4Put()
        {
            TeamMutateModel mutateModel = new TeamMutateModel
            {
                Name = "TestMetaUpdated",
                Description = "This is a meta created by the unit test"
            };

            TeamsController controller = new TeamsController(_context, null);
            IActionResult result = await controller.Put(this.id, mutateModel);

            NoContentResult ok = result as NoContentResult;

            Assert.NotNull(ok);
            Assert.Equal(204, ok.StatusCode);
        }

        [Fact]
        public async Task Test5Delete()
        {
            TeamsController controller = new TeamsController(_context, null);
            IActionResult result = await controller.Delete(this.id);

            OkObjectResult ok = result as OkObjectResult;

            Assert.NotNull(ok);
            Assert.Equal(200, ok.StatusCode);
        }
    }
}