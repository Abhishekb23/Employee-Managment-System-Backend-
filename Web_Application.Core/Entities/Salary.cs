using System.ComponentModel.DataAnnotations;

namespace WebApplication.Entities
{
    public class Salary
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int Year { get; set; }
        [Range(1, 12, ErrorMessage = "Select correct month.")]
        public int Month { get; set; }
        public DateTime CreatedOn { get; set; }
        public int EmployeeId { get; set; }
       

    }
}
