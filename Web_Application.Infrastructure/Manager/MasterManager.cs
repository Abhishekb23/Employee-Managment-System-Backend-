using Core.Abstraction.Manager;
using Core.Abstraction.Repositories;
using Core.Models;
using WebApplication.Entities;

namespace Infrastructure.Manager
{
    public class MasterManager : IMasterManager
    {
        private readonly IMasterRepository _masterRepository;

        public MasterManager(IMasterRepository masterRepository)
        {
            _masterRepository = masterRepository;
        }

        public async Task SeedDepartmentsAsync()
        {
            List<DepartmentModel> departments = new()
            {
                new() { Name = "Human Resources" },
                new() { Name = "Finance" },
                new() { Name = "Marketing" },
                new() { Name = "IT" },
                new() { Name = "Sales" },
                new() { Name = "Customer Service" },
                new() { Name = "Research and Development" },
                new() { Name = "Legal" },
                new() { Name = "Operations" },
                new() { Name = "Procurement" }
            };
            var departmentList = departments.Select(dep => new Department { Name = dep.Name }).ToList();

            await _masterRepository.SeedDepartmentsAsync(departmentList);
            await _masterRepository.SaveChangesAsync();
        }
        public async Task SeedCitiesAsync()
        {
            List<City> cities = new()
{
    new() { Name = "Visakhapatnam", StateId = 1 },
    new() { Name = "Vijayawada", StateId = 1 },
    new() { Name = "Guntur", StateId = 1 },
    new() { Name = "Itanagar", StateId = 2 },
    new() { Name = "Tawang", StateId = 2 },
    new() { Name = "Naharlagun", StateId = 2 },
    new() { Name = "Guwahati", StateId = 3 },
    new() { Name = "Silchar", StateId = 3 },
    new() { Name = "Dibrugarh", StateId = 3 },
    new() { Name = "Patna", StateId = 4 },
    new() { Name = "Gaya", StateId = 4 },
    new() { Name = "Bhagalpur", StateId = 4 },
    new() { Name = "Raipur", StateId = 5 },
    new() { Name = "Bilaspur", StateId = 5 },
    new() { Name = "Durg", StateId = 5 },
    new() { Name = "Panaji", StateId = 6 },
    new() { Name = "Vasco da Gama", StateId = 6 },
    new() { Name = "Margao", StateId = 6 },
    new() { Name = "Ahmedabad", StateId = 7 },
    new() { Name = "Surat", StateId = 7 },
    new() { Name = "Vadodara", StateId = 7 },
    new() { Name = "Chandigarh", StateId = 8 },
    new() { Name = "Faridabad", StateId = 8 },
    new() { Name = "Gurugram", StateId = 8 },
    new() { Name = "Shimla", StateId = 9 },
    new() { Name = "Kullu", StateId = 9 },
    new() { Name = "Manali", StateId = 9 },
    new() { Name = "Ranchi", StateId = 10 },
    new() { Name = "Jamshedpur", StateId = 10 },
    new() { Name = "Dhanbad", StateId = 10 },
    new() { Name = "Bengaluru", StateId = 11 },
    new() { Name = "Mysuru", StateId = 11 },
    new() { Name = "Mangaluru", StateId = 11 },
    new() { Name = "Kochi", StateId = 12 },
    new() { Name = "Thiruvananthapuram", StateId = 12 },
    new() { Name = "Kozhikode", StateId = 12 },
    new() { Name = "Indore", StateId = 13 },
    new() { Name = "Bhopal", StateId = 13 },
    new() { Name = "Gwalior", StateId = 13 },
    new() { Name = "Mumbai", StateId = 14 },
    new() { Name = "Pune", StateId = 14 },
    new() { Name = "Nagpur", StateId = 14 },
    new() { Name = "Imphal", StateId = 15 },
    new() { Name = "Shillong", StateId = 16 },
    new() { Name = "Aizawl", StateId = 17 },
    new() { Name = "Kohima", StateId = 18 },
    new() { Name = "Dimapur", StateId = 18 },
    new() { Name = "Mokokchung", StateId = 18 },
    new() { Name = "Bhubaneswar", StateId = 19 },
    new() { Name = "Cuttack", StateId = 19 },
    new() { Name = "Rourkela", StateId = 19 },
    new() { Name = "Ludhiana", StateId = 20 },
    new() { Name = "Amritsar", StateId = 20 },
    new() { Name = "Jalandhar", StateId = 20 },
    new() { Name = "Jaipur", StateId = 21 },
    new() { Name = "Udaipur", StateId = 21 },
    new() { Name = "Jodhpur", StateId = 21 },
    new() { Name = "Gangtok", StateId = 22 },
    new() { Name = "Namchi", StateId = 22 },
    new() { Name = "Mangan", StateId = 22 },
    new() { Name = "Chennai", StateId = 23 },
    new() { Name = "Coimbatore", StateId = 23 },
    new() { Name = "Madurai", StateId = 23 },
    new() { Name = "Hyderabad", StateId = 24 },
    new() { Name = "Warangal", StateId = 24 },
    new() { Name = "Khammam", StateId = 24 },
    new() { Name = "Agartala", StateId = 25 },
    new() { Name = "Lucknow", StateId = 26 },
    new() { Name = "Dehradun", StateId = 27 },
    new() { Name = "Haridwar", StateId = 27 },
    new() { Name = "Kolkata", StateId = 28 },
    new() { Name = "Siliguri", StateId = 28 },
    new() { Name = "Durgapur", StateId = 28 }
};


            await _masterRepository.SeedCitiesAsync(cities);
            await _masterRepository.SaveChangesAsync();
        }

        public async Task SeedStatesAsync()
        {
            List<State> states = new List<State>
            {
                new State { Name = "Andhra Pradesh" },
                new State { Name = "Arunachal Pradesh" },
                new State { Name = "Assam" },
                new State { Name = "Bihar" },
                new State { Name = "Chhattisgarh" },
                new State { Name = "Goa" },
                new State { Name = "Gujarat" },
                new State { Name = "Haryana" },
                new State { Name = "Himachal Pradesh" },
                new State { Name = "Jharkhand" },
                new State { Name = "Karnataka" },
                new State { Name = "Kerala" },
                new State { Name = "Madhya Pradesh" },
                new State { Name = "Maharashtra" },
                new State { Name = "Manipur" },
                new State { Name = "Meghalaya" },
                new State { Name = "Mizoram" },
                new State { Name = "Nagaland" },
                new State { Name = "Odisha" },
                new State { Name = "Punjab" },
                new State { Name = "Rajasthan" },
                new State { Name = "Sikkim" },
                new State { Name = "Tamil Nadu" },
                new State { Name = "Telangana" },
                new State { Name = "Tripura" },
                new State { Name = "Uttar Pradesh" },
                new State { Name = "Uttarakhand" },
                new State { Name = "West Bengal" },
                new State { Name = "Andaman and Nicobar Islands" },
                new State { Name = "Chandigarh" },
                new State { Name = "Dadra and Nagar Haveli and Daman and Diu" },
                new State { Name = "Lakshadweep" },
                new State { Name = "Delhi" },
                new State { Name = "Puducherry" }
            };


            await _masterRepository.SeedStatesAsync(states);
            await _masterRepository.SaveChangesAsync();
        }
        public async Task<CityModel> CreateCityAsync(CityModel city)
        {
            var city1 = await _masterRepository.CreateCityAsync(new City
            {
                Name = city.Name,
                StateId = city.StateId,
            });
            return new CityModel { Id = city1.Id, Name = city1.Name, StateId = city1.StateId, };
        }
        public async Task<IEnumerable<CityModel>> GetCitiesAsync()
        {
            return await _masterRepository.GetCityListAsync();
        }

        public async Task<List<CityModel>> GetCityListByStateIdAsync(int stateId)
        {
            return await _masterRepository.GetCityByStateIdAsync(stateId);
        }

        public async Task<IEnumerable<DepartmentModel>> GetDepartmentsAsync()
        {
            return await _masterRepository.GetDepartmentListAsync();

        }

        public async Task<IEnumerable<State>?> GetStateListAsync()
        {
            return await _masterRepository.GetStateListAsync();
        }

        public async Task<IEnumerable<string>?> GetCityWithNoEmployeeAsync()
        {
            return await _masterRepository.GetCityWithNoEmployeeAsync();
        }

        public async Task<IEnumerable<string>?> GetDepartmentWithNoEmployeeAsync()
        {
            return await _masterRepository.GetDepartmentWithNoEmployeeAsync();
        }

    }
}