using Core.Abstraction.Manager;
using Core.Abstraction.Repositories;
using Core.Models;
using WebApplication.Entities;

namespace Infrastructure.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeDetailModel?> GetEmployeeDetailsAsync(int id)
        {
            return await _employeeRepository.GetEmployeeDetailsAsync(id);
        }

        public async Task<IEnumerable<CityEmployeeModel>> GetCityWiseEmployeesAsync()
        {
            return await _employeeRepository.GetCityWiseEmployeesAsync();
        }
        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task<IEnumerable<Employee>?> GetEmployeesAsync()
        {
            return await _employeeRepository.GetEmployeesAsync();
        }

        public async Task<IEnumerable<EmployeeStatusModel>?> GetWorkingEmployeesAsync()
        {
            return await _employeeRepository.GetWorkingEmployeesAsync();
        }

        public async Task<IEnumerable<EmployeeModel?>> GetEmployeeByDepartmentIdAsync(int departmentId)
        {
            return await _employeeRepository.GetEmployeeByDepartmentIdAsync(departmentId);
        }

        public async Task<IEnumerable<BasicEmployeeModel>> GetPaidEmployeesAsync()
        {
            return await _employeeRepository.GetEmployeeGettingPaidAsync();
        }

        public async Task<IEnumerable<BasicEmployeeModel>> GetNotPaidEmployeesAsync()
        {
            return await _employeeRepository.GetEmployeeNotGettingPaidAsync();
        }

        public async Task AddEmployeeAsync(EmployeeDetailModel employee)
        {
            await _employeeRepository.AddEmployeeAsync(new Employee
            {
                Name = employee.Name,
                DOB = employee.DOB,
                Email = employee.Email,
                Phone = employee.Phone,
                Address = employee.Address,
                Gender =employee.Gender,
                Position=employee.Position,
                Zip = employee.Zip,
                DOJ = employee.DOJ,
                DOL = employee.DOL,
                UpdatedOn = employee.UpdatedOn,
                DepartmentId = employee.DepartmentId,
                CityId = employee.CityId
            });

            await _employeeRepository.SaveChangesAsync();
        }
        public async Task UpdateEmployeeByAsync(int id, EmployeeModel employee)
        {
            var existingEmployee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (existingEmployee == null) return;

            existingEmployee.Name = employee.Name;
            existingEmployee.DOB = employee.DOB;
            existingEmployee.Email = employee.Email;
            existingEmployee.Phone = employee.Phone;
            existingEmployee.Address = employee.Address;
            existingEmployee.Zip = employee.Zip;
            existingEmployee.DOJ = employee.DOJ;
            existingEmployee.DOL = employee.DOL;
            existingEmployee.UpdatedOn = employee.UpdatedOn;
            existingEmployee.DepartmentId = employee.DepartmentId;
            existingEmployee.CityId = employee.CityId;

            _employeeRepository.UpdateEmployee(existingEmployee);
            await _employeeRepository.SaveChangesAsync();
        }

        public async Task DeleteEmployeeByAsync(int id)
        {
            var existingEmployee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (existingEmployee == null) return;

            _employeeRepository.DeleteEmployee(existingEmployee);
            await _employeeRepository.SaveChangesAsync();
        }

     
    }
}