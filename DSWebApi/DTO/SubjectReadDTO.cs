using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWebApi.DTO
{
    public class SubjectReadDTO
    {
        public string Name { get; set; }
        public int? Semester { get; set; }
        public string Department { get; set; }
        public string ProfessorId { get; set; }
    }
}
