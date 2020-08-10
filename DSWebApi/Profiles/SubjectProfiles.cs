﻿using AutoMapper;
using DSWebApi.DTO;
using DSWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWebApi.Profiles
{
    public class SubjectProfiles :Profile
    {
        public SubjectProfiles()
        {
            CreateMap<Subject, SubjectReadDTO>();
        }
    }
}
