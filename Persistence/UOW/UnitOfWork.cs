using Application.Common.Interfaces.Contexts;
using Application.Common.Interfaces.Repositories;
using Persistence.Repositories;

namespace Persistence.UOW
{
    public class UnitOfWork
    {
        private readonly IApplicationDbContext _context;

        private IAddressRepository _addressRepository;
        private IDepartmentRepository _departmentRepository;
        private IEmployeeRepository _employeeRepository;
        private IOrganizationRepository _organizationRepository;
        private IPositionRepository _positionRepository;

        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IAddressRepository AddressRepository
        {
            get
            {
                return _addressRepository ??= new AddressRepository(_context);
            }
        }

        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                return _departmentRepository ??= new DepartmentRepository(_context);
            }
        }

        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                return _employeeRepository ??= new EmployeeRepository(_context);
            }
        }

        public IOrganizationRepository OrganizationRepository
        {
            get
            {
                return _organizationRepository ??= new OrganizationRepository(_context);
            }
        }

        public IPositionRepository PositionRepository
        {
            get
            {
                return _positionRepository ??= new PositionRepository(_context);
            }
        }
    }
}
