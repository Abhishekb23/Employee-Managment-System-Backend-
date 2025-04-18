
using WebApplication.Entities;

namespace Core.Models
{
    public class EmployeeDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public int Zip { get; set; }
        public DateTime DOJ { get; set; }
        public DateTime DOL { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int DepartmentId { get; set; }
        public int CityId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string CityName { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        //public string Remark { get; set; } = string.Empty;
    }
}
