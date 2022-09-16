using Application.Common.Interfaces.Services;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IoC
{
    public static class ServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IDepartmentService, DepartmentSevice>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IPositionService, PositionService>();
        }
    }
}
