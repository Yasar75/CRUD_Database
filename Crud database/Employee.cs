using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud_database
{
    public class Employee
    {
        public string Empid { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public int Age { get; set; }  

    }

    public class gender
    {
        public string Gender { get; set;}
    }
}