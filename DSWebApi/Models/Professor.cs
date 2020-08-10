using System;
using System.Collections.Generic;

namespace DSWebApi.Models
{
    public partial class Professor
    {
        public Professor()
        {
            Subjects = new HashSet<Subject>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
