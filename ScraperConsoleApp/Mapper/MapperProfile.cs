using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScraperConsoleApp.Mapper
{
    public class MapperProfile : Profile
    {
        public  MapperProfile() 
        {
            CreateMap<Dto._Links, Model._Links>();

            CreateMap<Dto.Country, Model.Country>();
            CreateMap<Dto.Country1, Model.Country1>();
            CreateMap<Dto.Dvdcountry, Model.Dvdcountry>();
            CreateMap<Dto.Externals, Model.Externals>();
            CreateMap<Dto.Image, Model.Image>();
            CreateMap<Dto.Previousepisode, Model.Previousepisode>();
            CreateMap<Dto.Network, Model.Network>();
            CreateMap<Dto.Nextepisode, Model.Nextepisode>();
            CreateMap<Dto.Rating, Model.Rating>();
            CreateMap<Dto.Schedule, Model.Schedule>();
            CreateMap<Dto.Self, Model.Self>();
            CreateMap<Dto.Webchannel, Model.Webchannel>();
            

            CreateMap<Dto.Show, Model.Show>();
        }
    }
}
