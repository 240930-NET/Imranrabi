using FishingSpotsTracker.Models;
using FishingSpotsTracker.Dtos.FishCatch;

namespace FishingSpotsTracker.Mappers;


public static class FishCatchMappers
{
    public static FishCatch ToFishCatchDto(this FishCatch fishCatch)
    {
        return new FishCatch
        {
            Id = fishCatch.Id,
            CatchDate = fishCatch.CatchDate,
            WeightInPounds = fishCatch.WeightInPounds,
            LengthInInches = fishCatch.LengthInInches,
            Lure = fishCatch.Lure,
            Notes = fishCatch.Notes
        };
    }

    public static FishCatch ToFishCatch(this CreateFishCatchRequestDto createFishCatchRequestDto)
    {
        return new FishCatch
        {
            CatchDate = createFishCatchRequestDto.CatchDate,
            WeightInPounds = createFishCatchRequestDto.WeightInPounds,
            LengthInInches = createFishCatchRequestDto.LengthInInches,
            Lure = createFishCatchRequestDto.Lure,
            Notes = createFishCatchRequestDto.Notes

        };
    }
}


