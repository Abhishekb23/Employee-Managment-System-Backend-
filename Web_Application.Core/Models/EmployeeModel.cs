using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Core.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(120, ErrorMessage = "Name should be 120 character only")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "DOB is required.")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; } = DateTime.UtcNow;
        [EmailAddress(ErrorMessage = "Pleae enter a valid email address")]
        [Required]
        public string Email { get; set; } = null!;
        [Phone]
        [Required]
        public string Phone { get; set; } = null!;
        [Required]
        [MaxLength(250, ErrorMessage = "Address is not more than 250 characters")]
        public string Address { get; set; } = string.Empty;
        [Range(100000, 999999, ErrorMessage = "Invalid Zip Code")]
        [Required]
        public int Zip { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DOJ { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DOL { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime UpdatedOn { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public int CityId { get; set; }
    }
}
