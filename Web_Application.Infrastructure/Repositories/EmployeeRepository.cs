using Core.Abstraction.Repositories;
using Core.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication.Entities;

namespace Infrastructure.Manager
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(emp => emp.Id == id);
        }
        public async Task<EmployeeDetailModel?> GetEmployeeDetailsAsync(int id)
        {

            return await (from emp in _context.Employees
                          join dep in _context.Departments on emp.DepartmentId equals dep.Id
                          join city in _context.Cities on emp.CityId equals city.Id
                          join sal in _context.Salaries on emp.Id equals sal.EmployeeId
                           into empSal
                          from sal in empSal.DefaultIfEmpty()
                          where emp.Id == id
                          select new EmployeeDetailModel
                          {
                              Id = emp.Id,
                              Name = emp.Name,
                              Email = emp.Email,
                              Address = emp.Address,
                              Gender = emp.Gender,
                              Position = emp.Position,
                              Phone = emp.Phone,
                              CityId = city.Id,
                              CityName = city.Name,
                              DepartmentId = dep.Id,
                              DepartmentName = dep.Name,
                              Zip = emp.Zip,
                              DOB = emp.DOB,
                              DOJ = emp.DOJ,
                              Salary = sal != null ? sal.Amount:0

                          }).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Employee>?> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }
        public async Task<IEnumerable<CityEmployeeModel>> GetCityWiseEmployeesAsync()
        {
            var query = from e in _context.Employees
                        join c in _context.Cities on e.CityId equals c.Id
                        group new { e, c } by c.Name into g
                        select new CityEmployeeModel
                        {
                            CityName = g.Key,
                            EmployeeDetail = g.Select(x => new BasicEmployeeModel
                            {
                                Name = x.e.Name,
                                Email = x.e.Email,
                                Phone = x.e.Phone
                            }).ToList()
                        };

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<EmployeeStatusModel>?> GetWorkingEmployeesAsync()
        {
            return await _context.Employees.Where(emp => emp.DOL.Date > DateTime.UtcNow.Date)
                         .Select(emp => new EmployeeStatusModel
                         {
                             Id = emp.Id,
                             Name = emp.Name,
                             Email = emp.Email,
                             Status = "Active"
                         }).ToListAsync();
        }

        public async Task<IEnumerable<EmployeeModel?>> GetEmployeeByDepartmentIdAsync(int departmentId)
        {
            return await (_context.Employees.Where(emp => emp.DepartmentId == departmentId)
                         .Select(employee => new EmployeeModel
                         {
                             Id = employee.Id,
                             Name = employee.Name,
                             DOB = employee.DOB,
                             Email = employee.Email,
                             Phone = employee.Phone,
                             Address = employee.Address,
                             Zip = employee.Zip,
                             DOJ = employee.DOJ,
                             DOL = employee.DOL,
                             UpdatedOn = employee.UpdatedOn,
                             DepartmentId = employee.DepartmentId,
                             CityId = employee.CityId
                         }).ToListAsync());
        }

        public async Task<IEnumerable<BasicEmployeeModel>> GetEmployeeGettingPaidAsync()
        {
            return await (_context.Employees.Where(emp => _context.Salaries
                         .Any(salary => salary.EmployeeId == emp.Id))
                         .Select(employee => new BasicEmployeeModel
                         {
                             Name = employee.Name,
                             Email = employee.Email,
                             Phone = employee.Phone
                         }).ToListAsync());
        }

        public async Task<IEnumerable<BasicEmployeeModel>> GetEmployeeNotGettingPaidAsync()
        {
            return await (_context.Employees.Where(emp => !_context.Salaries
                         .Any(salary => salary.EmployeeId == emp.Id))
                         .Select(employee => new BasicEmployeeModel
                         {
                             Name = employee.Name,
                             Email = employee.Email,
                             Phone = employee.Phone
                         }).ToListAsync());
        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}