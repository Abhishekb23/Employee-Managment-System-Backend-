using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class SalaryModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Month is required")]
        [Range(1, 12, ErrorMessage = "Select correct month.")]
        public int Month { get; set; }

        [Required(ErrorMessage = "CreatedOn Date is required")]
        public DateTime CreatedOn { get; set; }

        [Required(ErrorMessage = "Employee Id is required")]
        public int EmployeeId { get; set; }
    }
}
