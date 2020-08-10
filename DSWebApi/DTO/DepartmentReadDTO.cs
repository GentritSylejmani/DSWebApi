using DSWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWebApi.DTO
{
    public class DepartmentReadDTO
    {
        public string Name { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
