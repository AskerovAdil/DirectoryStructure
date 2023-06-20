using AutoMapper;
using DataAccess.Entities;
using DirectoryAPI.Models;

namespace DirectoryAPI.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CatalogItemDto, CatalogItem>();
        }
    }
}
