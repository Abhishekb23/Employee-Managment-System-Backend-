using Core.Models;

namespace Core.Abstraction.Manager
{
    public interface ISalaryManager
    {
        Task CreateEmployeeSalaryAsync(SalaryModel salary);
        Task<IEnumerable<EmployeeSalaryModel>?> GetAllEmployeeSalaryAsync();
        Task<EmployeeSalaryModel?> GetEmployeeSalaryByIdAsync(int id);
        Task<IEnumerable<EmployeeSalaryModel>?> GetEmployeesHavingLessThan15kSalary();
        Task<IEnumerable<EmployeeSalaryModel>?> GetPreviousYearSalaryOfEmployeeAsync(int id, int year);
        Task<IEnumerable<SalaryGroupModel>?> GetEmployeeSalaryGroupedByYearAsync(int employeeId);
        Task UpdateEmployeeSalaryByIdAsync(int id, SalaryModel salary);
        Task DeleteEmployeeSalaryByIdAsync(int id);
    }
}
