// FishingSpotsTracker.TESTS/Models/FishCatchTests.cs

using Xunit;
using FishingSpotsTracker.Models;
using System;

namespace FishingSpotsTracker.TESTS.Models
{
    public class FishCatchTests
    {
        [Fact]
        public void CanChangeFishCatchWeight()
        {
            // Arrange
            var fishCatch = new FishCatch { WeightInPounds = 2.0 };

            // Act
            fishCatch.WeightInPounds = 5.0;

            // Assert
            Assert.Equal(5.0, fishCatch.WeightInPounds);
        }

        [Fact]
        public void FishCatch_CreateInstance_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var expectedDate = DateTime.Now;
            
            // Act
            var fishCatch = new FishCatch
            {
                Id = 1,
                Notes = "Bass",
                WeightInPounds = 2.5,
                LengthInInches = 30.0,
                CatchDate = expectedDate,
            };

            // Assert
            Assert.Equal(1, fishCatch.Id);
            Assert.Equal("Bass", fishCatch.Notes);
            Assert.Equal(2.5, fishCatch.WeightInPounds);
            Assert.Equal(30.0, fishCatch.LengthInInches);
            Assert.Equal(expectedDate, fishCatch.CatchDate);

        }

        [Theory]
        [InlineData(-2.0)]
        [InlineData(-1.0)]
        public void FishCatch_InvalidWeight_ShouldThrowException(double invalidWeight)
        {
            // Arrange & Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new FishCatch 
            { 
                WeightInPounds = invalidWeight 
            });
            Assert.Contains("Weight must be positive", exception.Message);
        }
    }
}
