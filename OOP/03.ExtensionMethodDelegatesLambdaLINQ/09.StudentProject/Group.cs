using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.StudentProject
{
    class Group
    {
        public int GroupNumber { get; set; }
        public string DepartmentName { get; set; }

        public Group(int groupNumber, string departmentName)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = departmentName;
        }
    }
}
