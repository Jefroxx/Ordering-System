using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDPOrderingSystem.Code.Employee
{
    public class EmployeeInformation
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
    }
}
