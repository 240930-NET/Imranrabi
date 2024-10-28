// FishingSpotsTracker.TESTS/Controllers/SpotsControllerTests.cs

using Xunit;
using System.Threading.Tasks;
using FishingSpotsTracker.Controllers;
using FishingSpotsTracker.Data;
using Microsoft.AspNetCore.Mvc;
using FishingSpotsTracker.Dtos;
using Microsoft.EntityFrameworkCore;
using FishingSpotsTracker.Models;

namespace FishingSpotsTracker.TESTS.Controllers
{
    public class SpotsControllerTests
    {
        private readonly SpotsController _controller;
        private readonly ApplicationDBContext _context;

        public SpotsControllerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;
            _context = new ApplicationDBContext(options);
            _controller = new SpotsController(_context);
        }

        [Fact]
        public async Task GetSpots_ReturnsOkResult()
        {
            var result = _controller.GetAllSpots();
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetSpotById_ReturnsNotFoundResult()
        {
            var result = _controller.GetSpotById(999);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PostSpot_ReturnsCreatedResponse()
        {
            var spotDto = new Dtos.Spot.CreateSpotRequestDto{ Name = "Test Spot", WaterBodyType = "Lake", Latitude = 33.456892, Longitude = -112.073896 };

            var result = _controller.CreateSpot(spotDto);

            Assert.IsType<CreatedAtActionResult>(result.Result);
        }
    }
}
