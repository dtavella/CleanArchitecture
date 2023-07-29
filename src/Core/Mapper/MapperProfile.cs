using AutoMapper;
using Core.Dtos;
using Core.Entities;

namespace Core.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Student, StudentAddDto>().ReverseMap();
            CreateMap<Student, StudentDto>()
                .ForMember(q => q.UserName, i => i.MapFrom(src => $"{src.Name}_{src.LastName}_{src.Id}"))
                .ReverseMap();
        }
    }
}
