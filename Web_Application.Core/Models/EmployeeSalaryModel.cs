namespace Core.Models
{
    public class EmployeeSalaryModel
    {
        public int EmployeeId { get; set; }
        public int SalaryId { get; set; }
        public decimal Amount { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public DateTime EmployeeDOB { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string CityName { get; set; } = string.Empty;

    }
}
