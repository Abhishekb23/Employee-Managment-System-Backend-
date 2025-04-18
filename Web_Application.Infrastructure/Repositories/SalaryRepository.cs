using Core.Abstraction.Repositories;
using Core.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication.Entities;

namespace Infrastructure.Manager
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly AppDbContext _context;

        public SalaryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateEmployeeSalaryAsync(Salary salary)
        {
            await _context.Salaries.AddAsync(salary);
        }

        public async Task<Salary?> GetSalaryByIdAsync(int id)
        {
            return await _context.Salaries.FindAsync(id);
        }

        public async Task<IEnumerable<EmployeeSalaryModel>> GetAllEmployeeSalaryAsync()
        {
            return await (from sal in _context.Salaries
                          join emp in _context.Employees on sal.EmployeeId equals emp.Id
                          join dept in _context.Departments on emp.DepartmentId equals dept.Id
                          join city in _context.Cities on emp.CityId equals city.Id
                          select new EmployeeSalaryModel
                          {
                              SalaryId = sal.Id,
                              Amount = sal.Amount,
                              Year = sal.Year,
                              Month = sal.Month,
                              EmployeeId = emp.Id,
                              EmployeeName = emp.Name,
                              EmployeeDOB = emp.DOB,
                              DepartmentName = dept.Name,
                              CityName = city.Name
                          }).ToListAsync();
        }

        public async Task<EmployeeSalaryModel?> GetEmployeeSalaryByIdAsync(int id)
        {
            return await (from sal in _context.Salaries
                          join emp in _context.Employees on sal.EmployeeId equals emp.Id
                          join dept in _context.Departments on emp.DepartmentId equals dept.Id
                          where sal.Id == id
                          select new EmployeeSalaryModel
                          {
                              SalaryId = sal.Id,
                              Amount = sal.Amount,
                              Year = sal.Year,
                              Month = sal.Month,
                              EmployeeId = emp.Id,
                              EmployeeName = emp.Name,
                              EmployeeDOB = emp.DOB,
                              DepartmentName = dept.Name
                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<EmployeeSalaryModel>?> GetPreviousYearSalaryOfEmployeeAsync(int id, int year)
        {
            return await (from salary in _context.Salaries
                          join employee in _context.Employees on salary.EmployeeId equals employee.Id
                          join department in _context.Departments on employee.DepartmentId equals department.Id
                          where salary.Year == year && employee.Id == id
                          select new EmployeeSalaryModel
                          {
                              SalaryId = salary.Id,
                              Amount = salary.Amount,
                              Year = salary.Year,
                              Month = salary.Month,
                              EmployeeId = employee.Id,
                              EmployeeName = employee.Name,
                              EmployeeDOB = employee.DOB,
                              DepartmentName = department.Name
                          }).ToListAsync();
        }

        public async Task<IEnumerable<EmployeeSalaryModel>> GetEmployeesWithSalaryBelow15kAsync()
        {
            return await (from sal in _context.Salaries
                          join emp in _context.Employees on sal.EmployeeId equals emp.Id
                          join dept in _context.Departments on emp.DepartmentId equals dept.Id
                          where sal.Amount < 15000
                          select new EmployeeSalaryModel
                          {
                              SalaryId = sal.Id,
                              Amount = sal.Amount,
                              Year = sal.Year,
                              Month = sal.Month,
                              EmployeeId = emp.Id,
                              EmployeeName = emp.Name,
                              EmployeeDOB = emp.DOB,
                              DepartmentName = dept.Name
                          }).ToListAsync();
        }

        public async Task<IEnumerable<SalaryGroupModel>?> GetEmployeeSalaryGroupedByYearAsync(int employeeId)
        {
            return await _context.Salaries.Where(salary => salary.EmployeeId == employeeId)
                         .GroupBy(salary => salary.Year).Select(group => new SalaryGroupModel
                         {
                             Year = group.Key,
                             TotalSalary = group.Sum(salary => salary.Amount),
                             MonthlySalary = group.Select(sal => new EmployeeSalaryModel
                             {
                                 SalaryId = sal.Id,
                                 Amount = sal.Amount,
                                 Year = sal.Year,
                                 Month = sal.Month,
                             }).ToList()
                         }).ToListAsync();
        }

        public void UpdateSalary(Salary salary)
        {
            _context.Salaries.Update(salary);
        }

        public void DeleteSalary(Salary salary)
        {
            _context.Salaries.Remove(salary);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}