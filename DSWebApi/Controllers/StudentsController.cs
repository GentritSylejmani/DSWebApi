using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using DSWebApi.DTO;
using DSWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace DSWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [FormatFilter]
    //[Produces("application/json")]
    //[Produces("application/xml")]
    public class StudentsController : ControllerBase
    {
        private readonly dsDBContext _context;
        private readonly IMapper _mapper;

        public StudentsController(dsDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //GET api/Students
        [HttpGet]
        public ActionResult<IEnumerable<StudentReadDTO>> GetAllStudents()
        {
            var students = _context.Students.ToList();
            if (students.Count != 0)
            {
                return Ok(_mapper.Map<IEnumerable<StudentReadDTO>>(students));
            }

            return Content("Nuk ka asnje student te regjistruar!"); 
        }

        //GET api/Students/{index}
        [HttpGet("{index}",Name="GetStudentByIndex")]
        public ActionResult<StudentReadDTO> GetStudentByIndex(string index)
        {
            Student student = _context.Students.Where(s => s.Index == index).FirstOrDefault();

            if (student != null)
            {
                return Ok(_mapper.Map<StudentReadDTO>(student));

            }
            else return Content($"Studenti me index : {index} nuk egziston");
        }

        //POST api/Students
        [HttpPost]
        public ActionResult<StudentReadDTO> AddNewStudent(StudentCreateDTO newStudentCreateDTO)
        {
            newStudentCreateDTO.Department.ToString();

            var student = _mapper.Map<Student>(newStudentCreateDTO);

            bool indexExists = false;
            if (student.Index == null || student.Index == "")
            {


                string year = DateTime.Now.Year.ToString();
                year = year.Substring(year.Length - 2);

                var freshmanStudents = _context.Students.Where(x => x.Index.StartsWith(year)).ToList();

                int latestIndex = 0;

                int tempIndex = 0;

                switch (student.Department)
                {
                    case "Shkenca kompjuterike":
                        {
                            if (freshmanStudents.Count == 0)
                            {
                                student.Index = year + "0001K";
                                break;
                            }

                            foreach (var existingStudent in freshmanStudents)
                            {
                                existingStudent.Index = existingStudent.Index.Remove(existingStudent.Index.Length - 1, 1);
                                tempIndex = Convert.ToInt32(existingStudent.Index);
                                if (tempIndex > latestIndex)
                                {
                                    latestIndex = tempIndex;
                                }
                            }
                            latestIndex += 1;
                            student.Index = latestIndex.ToString() + "K";
                            break;
                        }
                    case "Ekonomi":
                        {
                            if (freshmanStudents.Count == 0)
                            {
                                student.Index = year + "0001E";
                                break;
                            }
                            foreach (var existingStudent in freshmanStudents)
                            {
                                tempIndex = Convert.ToInt32(existingStudent.Index.Substring(existingStudent.Index.Length - 1));
                                if (tempIndex > latestIndex)
                                {
                                    latestIndex = tempIndex;
                                }
                            }
                            latestIndex += 1;
                            student.Index = latestIndex.ToString() + "E";
                            break;
                        }
                }
            }
            else
            {     
                foreach(var registeredStudent in _context.Students)
                {
                    if(student.Index==registeredStudent.Index)
                    {
                        indexExists = true;
                        break;
                    }
                }
            }

            if(indexExists)
            {
                return Content($"Studenti me index:{student.Index} egziston. Ju lutem shkruani nje tjeter index");
            }

            _context.Students.Add(student);
            _context.SaveChanges();

            var studentReadDto = _mapper.Map<StudentReadDTO>(student);

            return CreatedAtRoute(nameof(GetStudentByIndex), new { Index = studentReadDto.Index }, student);

        }

    }
}
