using System;
using System.Collections.Generic;

namespace DepartmentAPI.Models
{
    public partial class Department
    {
        public int Deptid { get; set; }
        public string Deptname { get; set; } = null!;
    }
}
