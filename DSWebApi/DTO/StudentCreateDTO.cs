using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DSWebApi.DTO
{
    public class StudentCreateDTO
    {
        [XmlAttribute("Index")]
        public string Index { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Surname")]
        public string Surname { get; set; }
        [XmlAttribute("Birthdate")]
        public DateTime Birthdate { get; set; }
        [XmlAttribute("Department")]
        public string Department { get; set; }
        [XmlAttribute("Status")]
        public string Status { get; set; }

    }
}
