using AutoMapper;
using GlobalInsightsTribune.Application.DTOs;
using GlobalInsightsTribune.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalInsightsTribune.Application.Mappings
{
    public class DTOToDomainMappingProfile: Profile
    {
        public DTOToDomainMappingProfile()
        {
            CreateMap<UserDTO, User>();
        }
    }
}
