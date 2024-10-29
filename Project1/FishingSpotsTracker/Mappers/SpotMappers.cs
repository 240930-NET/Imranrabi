using System.Collections.Generic;
using FishingSpotsTracker.Models;
using FishingSpotsTracker.Dtos.Spot;


namespace FishingSpotsTracker.Mappers;

public static class SpotMappers
{
    public static Spot ToSpotDto(this Spot spot)
    {
        return new Spot
        {
            Id = spot.Id,
            Name = spot.Name,
            WaterBodyType = spot.WaterBodyType,
            Latitude = spot.Latitude,
            Longitude = spot.Longitude
        };
    }

    public static Spot ToSpot(this CreateSpotRequestDto createSpotRequestDto)
    {
        return new Spot
        {
            Name = createSpotRequestDto.Name,
            WaterBodyType = createSpotRequestDto.WaterBodyType,
            Latitude = createSpotRequestDto.Latitude,
            Longitude = createSpotRequestDto.Longitude

        };
    }
}

