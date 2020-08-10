using System;
using System.Collections.Generic;

namespace DSWebApi.Models
{
    public partial class Subject
    {
        public string Name { get; set; }
        public int? Semester { get; set; }
        public string Department { get; set; }
        public string ProfessorId { get; set; }

        public virtual Department DepartmentNavigation { get; set; }
        public virtual Professor Professor { get; set; }
    }
}
