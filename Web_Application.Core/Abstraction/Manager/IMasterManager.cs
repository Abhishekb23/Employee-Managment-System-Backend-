using Core.Models;
using WebApplication.Entities;

namespace Core.Abstraction.Manager
{
    public interface IMasterManager
    {
       
        Task SeedDepartmentsAsync();
        Task SeedStatesAsync();
        Task SeedCitiesAsync();
        Task<CityModel> CreateCityAsync(CityModel city);
        Task<IEnumerable<CityModel>> GetCitiesAsync();
        Task<List<CityModel>> GetCityListByStateIdAsync(int stateId);
        Task<IEnumerable<DepartmentModel>> GetDepartmentsAsync();
        Task<IEnumerable<State>?> GetStateListAsync();
        Task<IEnumerable<string>?> GetCityWithNoEmployeeAsync();
        Task<IEnumerable<string>?> GetDepartmentWithNoEmployeeAsync();
    }
}
