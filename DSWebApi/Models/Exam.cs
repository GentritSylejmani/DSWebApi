using System;
using System.Collections.Generic;

namespace DSWebApi.Models
{
    public partial class Exam
    {
        public string StudentId { get; set; }
        public string Subject { get; set; }
        public string ProfessorId { get; set; }
        public decimal? Points { get; set; }
        public int? Grade { get; set; }

        public virtual Professor Professor { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subject SubjectNavigation { get; set; }
    }
}
