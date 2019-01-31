using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeBackend.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public bool IsMarried { get; set; }
        public DateTime DOB { get; set; }
        public string EmpImage { get; set; }
        public Employee()
        {
            EmpId = Age = CountryId = StateId = 0;
            Name = Email = City = Gender = EmpImage = Mobile = ZipCode = string.Empty;
            DOB = new DateTime(1990, 01, 01);
            IsMarried = false;
        }
    }
}