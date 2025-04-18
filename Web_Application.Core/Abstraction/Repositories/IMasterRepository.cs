using Core.Models;
using WebApplication.Entities;

namespace Core.Abstraction.Repositories
{
    public interface IMasterRepository
    {
        Task SeedDepartmentsAsync(IEnumerable<Department> departments);
        Task SeedStatesAsync(IEnumerable<State> states);
        Task SeedCitiesAsync(IEnumerable<City> cities);
        Task<City> CreateCityAsync(City city);
        Task<List<CityModel>> GetCityListAsync();
        Task<List<CityModel>> GetCityByStateIdAsync(int stateId);
        Task<List<DepartmentModel>?> GetDepartmentListAsync();
        Task<List<string>?> GetCityWithNoEmployeeAsync();
        Task<City?> GetCityByIdAsync(int cityId);
        Task<List<string>?> GetDepartmentWithNoEmployeeAsync();
        Task<Department?> GetDepartmentByIdAsync(int departmentId);
        Task<List<State>?> GetStateListAsync();
        Task SaveChangesAsync();

    }
}
