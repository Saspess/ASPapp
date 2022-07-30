using Domain.Entities;

namespace Application.Common.Interfaces.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<Employee?> GetByLastName(string lastName);
    }
}
