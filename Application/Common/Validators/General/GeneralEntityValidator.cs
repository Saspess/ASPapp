using Application.Common.Interfaces.Validators;
using Application.Common.Validators.Entities;
using Domain.Entities;

namespace Application.Common.Validators.General
{
    public class GeneralEntityValidator
    {
        private IAddressValidator _addressValidator;
        private IDepartmentValidator _departmentValidator;
        private IEmployeeValidator _employeeValidator;
        private IOrganizationValidator _organizationValidator;
        private IPositionValidator _positionValidator;



        public GeneralEntityValidator()
        {
            _addressValidator = new AddressValidator();
            _departmentValidator = new DepartmentValidator();
            _employeeValidator = new EmployeeValidator();
            _organizationValidator = new OrganizationValidator();
            _positionValidator = new PositionValidator();
        }

        public bool ValidateEntity(Address address)
        {
            var result = _addressValidator.Validate(address);
            if (result.IsValid)
            {
                return true;
            }

            foreach (var error in result.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return false;
        }

        public bool ValidateEntity(Department department)
        {
            var result = _departmentValidator.Validate(department);
            if (result.IsValid)
            {
                return true;
            }

            foreach (var error in result.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return false;
        }

        public bool ValidateEntity(Employee employee)
        {
            var result = _employeeValidator.Validate(employee);
            if (result.IsValid)
            {
                return true;
            }

            foreach (var error in result.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return false;
        }

        public bool ValidateEntity(Organization organization)
        {
            var result = _organizationValidator.Validate(organization);
            if (result.IsValid)
            {
                return true;
            }

            foreach (var error in result.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return false;
        }

        public bool ValidateEntity(Position position)
        {
            var result = _positionValidator.Validate(position);
            if (result.IsValid)
            {
                return true;
            }

            foreach (var error in result.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return false;
        }
    }
}
