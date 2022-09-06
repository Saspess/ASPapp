using Application.Common.Interfaces.Repositories;
using Application.Services.Common;
using AutoMapper;
using Application.Dtos.Position;
using Domain.Entities;
using Application.Common.Interfaces.Services;

namespace Application.Services
{
    public class PositionService : BaseService, IPositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(IMapper mapper, IPositionRepository positionRepository) : base(mapper) => _positionRepository = positionRepository;

        public async Task<IEnumerable<PositionDto>> GetAllAsync()
        {
            var positions = await _positionRepository.GetAllAsync();
            var positionsDtos = mapper.Map<IEnumerable<PositionDto>>(positions);

            return positionsDtos;
        }

        public async Task<PositionDto> GetByIdAsync(int id)
        {
            var position = await _positionRepository.GetByIdAsync(id);
            var positionDto = mapper.Map<PositionDto>(position);

            return positionDto;
        }

        public async Task CreateAsync(PositionForCreateDto positionForCreateDto)
        {
            var position = mapper.Map<Position>(positionForCreateDto);

            await _positionRepository.CreateAsync(position);
        }

        public async Task UpdateAsync(PositionForUpdateDto positionForUpdateDto)
        {
            var position = mapper.Map<Position>(positionForUpdateDto);

            await _positionRepository.UpdateAsync(position);
        }

        public async Task DeleteAsync(int id) => await _positionRepository.DeleteAsync(id);
    }
}
