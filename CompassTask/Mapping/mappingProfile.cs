using AutoMapper;
using CompassTask.DTOS;
using CompassTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompassTask.Mapping
{
    public class mappingProfile:Profile
    {
        public mappingProfile()
        {
            CreateMap<UserAddDto,User >();
            CreateMap<UserEditDto, User>();
            CreateMap<User, UserListDto>();
        }
    }
}
