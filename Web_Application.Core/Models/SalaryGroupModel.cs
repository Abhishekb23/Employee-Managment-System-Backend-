

namespace Core.Models
{
   public class SalaryGroupModel
    {
        public int Year { get; set; }
        public decimal TotalSalary { get; set; }
        public List<EmployeeSalaryModel> MonthlySalary { get; set; } = new();
    }
}
