// FishingSpotsTracker.TESTS/Data/ApplicationDbContextTests.cs

using Xunit;
using FishingSpotsTracker.Data;
using FishingSpotsTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;   
using Microsoft.EntityFrameworkCore.InMemory;
using System;

namespace FishingSpotsTracker.TESTS.Data
{
    public class ApplicationDbContextTests
    {
        private readonly DbContextOptions<ApplicationDBContext> _options;

        public ApplicationDbContextTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public async Task CanAddFishCatchToDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            using var context = new ApplicationDBContext(options);
            var fishCatch = new FishCatch { WeightInPounds = 3.5, LengthInInches = 25 };

            // Act
            context.FishCatches.Add(fishCatch);
            await context.SaveChangesAsync();

            // Assert
            Assert.Single(context.FishCatches);
        }

        [Fact]
        public async Task AddSpot_ShouldSaveToDatabase()
        {
            // Arrange
            using var context = new ApplicationDBContext(_options);
            var spot = new Spot
            {
                Name = "Test Spot",
                WaterBodyType = "Lake",
                Latitude = 33.456892,
                Longitude = -112.073896
            };

            // Act
            context.Spots.Add(spot);
            await context.SaveChangesAsync();

            // Assert
            var savedSpot = await context.Spots.FirstOrDefaultAsync();
            Assert.NotNull(savedSpot);
            Assert.Equal("Test Spot", savedSpot.Name);
        }

        [Fact]
        public async Task AddFishCatch_WithValidSpot_ShouldSaveToDatabase()
        {
            // Arrange
            using var context = new ApplicationDBContext(_options);
            var spot = new Spot
            {
                Name = "Test Spot",
                WaterBodyType = "Lake",
                Latitude = 33.456892,
                Longitude = -112.073896
            };
            context.Spots.Add(spot);
            await context.SaveChangesAsync();

            var fishCatch = new FishCatch
            {
                Notes = "Bass",
                WeightInPounds = 2.5,
                LengthInInches = 30.0,
                CatchDate = DateTime.Now,
            };

            // Act
            context.FishCatches.Add(fishCatch);
            await context.SaveChangesAsync();

            // Assert
            var savedCatch = await context.FishCatches
                .FirstOrDefaultAsync();
                
            Assert.NotNull(savedCatch);
            Assert.Equal("Bass", savedCatch.Notes);
        }
    }
}
