using AutoMapper;

namespace ScraperConsoleApp.Mapper
{
    public class MapperProfile : Profile
    {
        public  MapperProfile() 
        {
            CreateMap<Dto._Links, Models._Links>();

            CreateMap<Dto.Country, Models.Country>();
            CreateMap<Dto.Country1, Models.Country1>();
            CreateMap<Dto.Dvdcountry, Models.Dvdcountry>();
            CreateMap<Dto.Externals, Models.Externals>();
            CreateMap<Dto.Image, Models.Image>();
            CreateMap<Dto.Previousepisode, Models.Previousepisode>();
            CreateMap<Dto.Network, Models.Network>();
            CreateMap<Dto.Nextepisode, Models.Nextepisode>();
            CreateMap<Dto.Rating, Models.Rating>();
            CreateMap<Dto.Schedule, Models.Schedule>();
            CreateMap<Dto.Self, Models.Self>();
            CreateMap<Dto.Webchannel, Models.Webchannel>();
            CreateMap<Dto.Cast, Models.Cast>();
            CreateMap<Dto.Person, Models.Person>();
            CreateMap<Dto.Character, Models.Character>();


            CreateMap<Dto.Show, Models.Show>();
        }
    }
}
