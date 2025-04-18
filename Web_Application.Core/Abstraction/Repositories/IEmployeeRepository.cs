using Core.Models;
using WebApplication.Entities;


namespace Core.Abstraction.Repositories
{
    public interface IEmployeeRepository
    {
        Task AddEmployeeAsync(Employee employee);
        Task<EmployeeDetailModel?> GetEmployeeDetailsAsync(int id);
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<Employee>?> GetEmployeesAsync();
        Task<IEnumerable<EmployeeModel?>> GetEmployeeByDepartmentIdAsync(int departmentId);
        Task<IEnumerable<BasicEmployeeModel>> GetEmployeeGettingPaidAsync();
        Task<IEnumerable<BasicEmployeeModel>> GetEmployeeNotGettingPaidAsync();
        Task<IEnumerable<CityEmployeeModel>> GetCityWiseEmployeesAsync();
        Task<IEnumerable<EmployeeStatusModel>?> GetWorkingEmployeesAsync();
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        Task SaveChangesAsync();

    }
}
