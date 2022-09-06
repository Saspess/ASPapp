using Application.Dtos.Position;

namespace Application.Common.Interfaces.Services
{
    public interface IPositionService
    {
        Task<IEnumerable<PositionDto>> GetAllAsync();
        Task<PositionDto> GetByIdAsync(int id);
        Task CreateAsync(PositionForCreateDto positionForCreateDto);
        Task UpdateAsync(PositionForUpdateDto positionForUpdateDto);
        Task DeleteAsync(int id);
    }
}
