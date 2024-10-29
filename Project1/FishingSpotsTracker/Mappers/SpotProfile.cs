using AutoMapper;
using FishingSpotsTracker.Models;
using FishingSpotsTracker.Dtos.Spot;

namespace FishingSpotsTracker.Mappers
{
    public class SpotProfile : Profile
    {
        public SpotProfile()
        {
            CreateMap<Spot, SpotDto>();
            CreateMap<CreateSpotRequestDto, Spot>();
        }
    }
}