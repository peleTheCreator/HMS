using AutoMapper;
using HotelManagementSystem.Entities;
using HotelManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Mapping
{
    public class MappingProfle : Profile
    {
        public MappingProfle()
        {
            CreateMap<RoomType, RoomTypeDto>();
            CreateMap<RoomTypeDto, Room>();
        }
    }
}
