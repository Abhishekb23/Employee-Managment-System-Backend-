using Core.Models;
using WebApplication.Entities;

namespace Core.Abstraction.Manager
{
    public interface IEmployeeManager
    {
        Task AddEmployeeAsync(EmployeeDetailModel employeeModel);
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<Employee>?> GetEmployeesAsync();
        Task<EmployeeDetailModel?> GetEmployeeDetailsAsync(int id);
        Task<IEnumerable<EmployeeModel?>> GetEmployeeByDepartmentIdAsync(int departmentId);
        Task<IEnumerable<BasicEmployeeModel>> GetPaidEmployeesAsync();
        Task<IEnumerable<BasicEmployeeModel>> GetNotPaidEmployeesAsync();
        Task<IEnumerable<CityEmployeeModel>> GetCityWiseEmployeesAsync();
        Task<IEnumerable<EmployeeStatusModel>?> GetWorkingEmployeesAsync();
        Task UpdateEmployeeByAsync(int id, EmployeeModel employee);
        Task DeleteEmployeeByAsync(int id);
    }
}
