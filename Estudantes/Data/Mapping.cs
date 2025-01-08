using AutoMapper;
using Estudantes.DTOs;
using Estudantes.Models;

namespace Estudantes.Data
{
    public class Mapping : Profile
    {
        public static MapperConfiguration RegisterMaps()
        {          
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<StudentDTO, Student>().ReverseMap();
                config.CreateMap<AddressDTO, Address>().ReverseMap();
                config.CreateMap<CourseDTO, Course>().ReverseMap();
                config.CreateMap<EducationalInstitutionDTO, EducationalInstitution>().ReverseMap();
                config.CreateMap<StateDTO, State>().ReverseMap();
                config.CreateMap<CityDTO, City>().ReverseMap();
                config.CreateMap<UserDTO, User>().ReverseMap();
            });
            return mappingConfig;
        }          
    }
}
