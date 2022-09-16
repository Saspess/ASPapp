using Application.Common.Interfaces.Repositories;

namespace Application.Common.Interfaces.UOW
{
    public interface IUnitOfWork
    {
        IAddressRepository AddressRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IOrganizationRepository OrganizationRepository { get; }
        IPositionRepository PositionRepository { get; }
    }
}
