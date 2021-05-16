using AutoMapper;
using FilmsProject.BusinessLogicLayer.DTOs;
using FilmsProject.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsProject.API.AutoMapperProfiles
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Country, CountryDTO>()
                .ReverseMap();

            CreateMap<Participant, ParticipantDTO>()
                .ReverseMap();
        }
    }
}
