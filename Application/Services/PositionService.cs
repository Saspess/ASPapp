using Application.Common.Exceptions;
using Application.Common.Interfaces.Services;
using Application.Common.Interfaces.UOW;
using Application.Dtos.Position;
using Application.Services.Common;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class PositionService : BaseService, IPositionService
    {
        public PositionService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IEnumerable<PositionDto>> GetAllAsync()
        {
            var positions = await unitOfWork.PositionRepository.GetAllAsync();
            var positionsDtos = mapper.Map<IEnumerable<PositionDto>>(positions);

            return positionsDtos;
        }

        public async Task<PositionDto> GetByIdAsync(int id)
        {
            var position = await unitOfWork.PositionRepository.GetByIdAsync(id);
            var positionDto = mapper.Map<PositionDto>(position);

            return positionDto;
        }

        public async Task CreateAsync(PositionForCreateDto positionForCreateDto)
        {
            if (positionForCreateDto == null)
            {
                throw new ArgumentNullException(nameof(positionForCreateDto));
            }

            var position = mapper.Map<Position>(positionForCreateDto);

            await unitOfWork.PositionRepository.CreateAsync(position);
        }

        public async Task UpdateAsync(PositionForUpdateDto positionForUpdateDto)
        {
            if (positionForUpdateDto == null)
            {
                throw new ArgumentNullException(nameof(positionForUpdateDto));
            }

            var checkPosition = await unitOfWork.PositionRepository.GetByIdAsync(positionForUpdateDto.Id) 
                ?? throw new NotFoundException("Position was not found");

            var position = mapper.Map<Position>(positionForUpdateDto);

            await unitOfWork.PositionRepository.UpdateAsync(position);
        }

        public async Task DeleteAsync(int id)
        {
            var checkPosition = await unitOfWork.PositionRepository.GetByIdAsync(id) 
                ?? throw new NotFoundException("Position was not found");

            await unitOfWork.PositionRepository.DeleteAsync(id);
        }
    }
}
