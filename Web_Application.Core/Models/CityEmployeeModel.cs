using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CityEmployeeModel
    {
        public string CityName { get; set; } = string.Empty;
        public IEnumerable<BasicEmployeeModel> EmployeeDetail { get; set; } = new List<BasicEmployeeModel>();
    }
}
