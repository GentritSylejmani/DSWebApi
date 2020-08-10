using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DSWebApi.Models
{
    [XmlRoot("Student")]
    public partial class Student
    {   [XmlAttribute("Index")]
        public string Index { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Surname")]
        public string Surname { get; set; }
        [XmlAttribute("Birthdate")]
        public DateTime? Birthdate { get; set; }
        [XmlAttribute("Department")]
        public string Department { get; set; }
        [XmlAttribute("Status")]
        public string Status { get; set; }

        public string GenerateIndex(string department,int studentsNo)
        {
            string index = "";

            return index; 
        }

        public virtual Status StatusNavigation { get; set; }

    }
}
