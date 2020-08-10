using System;
using System.Collections.Generic;

namespace DSWebApi.Models
{
    public partial class Department
    {
        public Department()
        {
            Subjects = new HashSet<Subject>();
        }

        public string Name { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
