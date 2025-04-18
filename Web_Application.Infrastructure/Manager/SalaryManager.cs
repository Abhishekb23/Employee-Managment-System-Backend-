using Core.Abstraction.Manager;
using Core.Abstraction.Repositories;
using Core.Models;
using WebApplication.Entities;

namespace Infrastructure.Manager
{
    public class SalaryManager : ISalaryManager
    {
        private readonly ISalaryRepository _salaryRepository;
        public SalaryManager(ISalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }

        public async Task<IEnumerable<EmployeeSalaryModel>?> GetAllEmployeeSalaryAsync()
        {
            return await _salaryRepository.GetAllEmployeeSalaryAsync();
        }

        public async Task<EmployeeSalaryModel?> GetEmployeeSalaryByIdAsync(int id)
        {
            return await _salaryRepository.GetEmployeeSalaryByIdAsync(id);
        }

        public async Task<IEnumerable<EmployeeSalaryModel>?> GetEmployeesHavingLessThan15kSalary()
        {
            return await _salaryRepository.GetEmployeesWithSalaryBelow15kAsync();
        }

        public async Task<IEnumerable<EmployeeSalaryModel>?> GetPreviousYearSalaryOfEmployeeAsync(int id, int year)
        {
            return await _salaryRepository.GetPreviousYearSalaryOfEmployeeAsync(id, year);
        }

        public async Task<IEnumerable<SalaryGroupModel>?> GetEmployeeSalaryGroupedByYearAsync(int employeeId)
        {
            return await _salaryRepository.GetEmployeeSalaryGroupedByYearAsync(employeeId);
        }

        public async Task CreateEmployeeSalaryAsync(SalaryModel salaryModel)
        {
            var salary = new Salary
            {
                Amount = salaryModel.Amount,
                Year = salaryModel.Year,
                Month = salaryModel.Month,
                CreatedOn = salaryModel.CreatedOn,
                EmployeeId = salaryModel.EmployeeId
            };

            await _salaryRepository.CreateEmployeeSalaryAsync(salary);
            await _salaryRepository.SaveChangesAsync();
        }

        public async Task UpdateEmployeeSalaryByIdAsync(int id, SalaryModel salary)
        {
            var existingSalary = await _salaryRepository.GetSalaryByIdAsync(id);
            if (existingSalary == null) return;
            existingSalary.Amount = salary.Amount;
            existingSalary.Year = salary.Year;
            existingSalary.Month = salary.Month;
            existingSalary.CreatedOn = salary.CreatedOn;
            existingSalary.EmployeeId = salary.EmployeeId;

            _salaryRepository.UpdateSalary(existingSalary);
            await _salaryRepository.SaveChangesAsync();
        }

        public async Task DeleteEmployeeSalaryByIdAsync(int id)
        {
            var existingSalary = await _salaryRepository.GetSalaryByIdAsync(id);
            if (existingSalary == null) return;

            _salaryRepository.DeleteSalary(existingSalary);
            await _salaryRepository.SaveChangesAsync();
        }
    }
}