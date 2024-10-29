// FishingSpotsTracker.TESTS/Mappers/SpotMapperTests.cs

using Xunit;
using FishingSpotsTracker.Models;
using AutoMapper;
using System.Collections.Generic;
using FishingSpotsTracker.Dtos.Spot;
using FishingSpotsTracker.Mappers;
using Microsoft.AspNetCore.Identity;


namespace FishingSpotsTracker.TESTS.Mappers
{
    public class SpotMapperTests
    {
        private readonly IMapper _mapper;

        public SpotMapperTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<SpotProfile>());
            _mapper = config.CreateMapper();
        }

        [Fact]
        public void Map_SpotToSpotDto_ShouldMapCorrectly()
        {
            // Arrange
            var spot = new Spot
            {
                Id = 1,
                Name = "Test Spot",
                WaterBodyType = "Lake",
                Latitude = 33.456892,
                Longitude = -112.073896
            };

            // Act
            var dto = _mapper.Map<Dtos.Spot.SpotDto>(spot);

            // Assert
            Assert.Equal(spot.Id, dto.Id);
            Assert.Equal(spot.Name, dto.Name);
            Assert.Equal(spot.WaterBodyType, dto.WaterBodyType);
            Assert.Equal(spot.Latitude, dto.Latitude);
            Assert.Equal(spot.Longitude, dto.Longitude);
        }

        [Fact]
        public void Map_CreateSpotDtoToSpot_ShouldMapCorrectly()
        {
            // Arrange
            var createDto = new Dtos.Spot.CreateSpotRequestDto
            {
                Name = "New Spot",
                WaterBodyType = "Lake",
                Latitude = 33.456892,
                Longitude = -112.073896
            };

            // Act
            var spot = _mapper.Map<Spot>(createDto);

            // Assert
            Assert.Equal(createDto.Name, spot.Name);
            Assert.Equal(createDto.WaterBodyType, spot.WaterBodyType);
            Assert.Equal(createDto.Latitude, spot.Latitude);
            Assert.Equal(createDto.Longitude, spot.Longitude);
        }
    }
}
