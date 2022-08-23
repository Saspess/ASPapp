using Application.Models.Position;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class PositionProfile : Profile
    {
        public PositionProfile()
        {
            CreateMap<Position, PositionDto>();
        }
    }
}
