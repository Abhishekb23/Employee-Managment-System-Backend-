using Core.Models;
using WebApplication.Entities;

namespace Core.Abstraction.Repositories
{
    public interface ISalaryRepository
    {
        Task CreateEmployeeSalaryAsync(Salary salary);
        Task<Salary?> GetSalaryByIdAsync(int id);
        Task<IEnumerable<EmployeeSalaryModel>> GetAllEmployeeSalaryAsync();
        Task<EmployeeSalaryModel?> GetEmployeeSalaryByIdAsync(int id);
        Task<IEnumerable<EmployeeSalaryModel>> GetEmployeesWithSalaryBelow15kAsync();
        Task<IEnumerable<EmployeeSalaryModel>?> GetPreviousYearSalaryOfEmployeeAsync(int id, int year);
        Task<IEnumerable<SalaryGroupModel>?> GetEmployeeSalaryGroupedByYearAsync(int employeeId);
        void UpdateSalary(Salary salary);
        void DeleteSalary(Salary salary);
        Task SaveChangesAsync();
    }

}

