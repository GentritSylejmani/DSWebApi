using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DSWebApi.DTO;
using DSWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace DSWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly dsDBContext _context;
        private readonly IMapper _mapper;

        public DepartmentsController(dsDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        //GET api/Departments
        [HttpGet]
        public ActionResult<DepartmentReadDTO> GetAllDepartments()
        {
            var departments = _context.Departments.ToList();
            if(departments.Count !=0)
            {
                return Ok(_mapper.Map<IEnumerable<DepartmentReadDTO>>(departments));
            }

            return Content("Nuk ka asnje departament!");
        }
    }
}
