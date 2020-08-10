using System;
using System.Collections.Generic;

namespace DSWebApi.Models
{
    public partial class Status
    {
        public Status()
        {
            Students = new HashSet<Student>();
        }

        public string Status1 { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
