using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DSWebApi.DTO;
using DSWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly dsDBContext _context;
        private readonly IMapper _mapper;

        public SubjectsController(dsDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //GET api/Subjects
        [HttpGet]
        public ActionResult<SubjectReadDTO> GetAllSubjects()
        {
            var subjects = _context.Subjects.ToList();
            if(subjects.Count!=0)
            {
                return Ok(_mapper.Map<IEnumerable<SubjectReadDTO>>(subjects));
            }

            return Content("Nuk ka asnje lende te regjistruar ne sistem!");
        }
    }

    
}
