using Application.Dtos.Position;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class PositionProfile : Profile
    {
        public PositionProfile()
        {
            CreateMap<Position, PositionDto>();

            CreateMap<PositionForCreateDto, Position>();

            CreateMap<PositionForUpdateDto, Position>();
        }
    }
}
