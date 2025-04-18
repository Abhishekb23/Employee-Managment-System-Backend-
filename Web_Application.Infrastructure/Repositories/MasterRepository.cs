using Core.Abstraction.Repositories;
using Core.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication.Entities;

namespace Infrastructure.Manager
{
    public class MasterRepository : IMasterRepository
    {
        private readonly AppDbContext _context;
        public MasterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task SeedDepartmentsAsync(IEnumerable<Department> departments)
        {
            await _context.Departments.AddRangeAsync(departments);
        }

        public async Task SeedStatesAsync(IEnumerable<State> states)
        {
            await _context.States.AddRangeAsync(states);
        }

        public async Task SeedCitiesAsync(IEnumerable<City> cities)
        {
            await _context.Cities.AddRangeAsync(cities);
        }

        public async Task<City> CreateCityAsync(City city)
        {
            await _context.Cities.AddAsync(city);
            await SaveChangesAsync();
            return city;
        }
        public async Task<List<CityModel>> GetCityListAsync()
        {
            return await _context.Cities.Select(city => new CityModel
            {
                Id = city.Id,
                Name = city.Name,
            }).ToListAsync();
        }

        public async Task<List<CityModel>> GetCityByStateIdAsync(int stateId)
        {
            return await _context.Cities.Where(city => city.StateId == stateId).Select(city => new CityModel
            {
                Id = city.Id,
                Name = city.Name,
                StateId = city.StateId,
            }).ToListAsync();
        }

        public async Task<List<State>?> GetStateListAsync()
        {
            return await _context.States.ToListAsync();
        }

        public async Task<List<DepartmentModel>?> GetDepartmentListAsync()
        {
            return await _context.Departments.Select(department => new DepartmentModel
            {
                Id = department.Id,
                Name = department.Name
            }).ToListAsync();
        }

        public async Task<List<string>?> GetDepartmentWithNoEmployeeAsync()
        {
            return await _context.Departments.Where(department => !_context.Employees
                        .Select(employee => employee.DepartmentId).Distinct()
                        .Contains(department.Id)).Select(department => department.Name).ToListAsync();
        }

        public async Task<List<string>?> GetCityWithNoEmployeeAsync()
        {
            return await _context.Cities.Where(c => !_context.Employees
                        .Select(e => e.CityId).Distinct().Contains(c.Id))
                        .Select(c => c.Name).ToListAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(int departmentId)
        {
            return await _context.Departments.FindAsync(departmentId);
        }

        public async Task<City?> GetCityByIdAsync(int cityId)
        {
            return await _context.Cities.FindAsync(cityId);
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}