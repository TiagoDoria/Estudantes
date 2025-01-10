using AutoMapper;
using Estudantes.DTOs;
using Estudantes.Models;

namespace Estudantes.Data
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            // Configuração de mapeamento geral
            CreateMap<StudentDTO, Student>()
                .ForMember(dest => dest.Address, opt => opt.Condition(src => src.Address != null)) // Mapeia Address apenas se ele não for nulo
                .ForPath(dest => dest.Address.City, opt => opt.Ignore()) // Ignora a recriação de City
                .ForPath(dest => dest.Address.City.State, opt => opt.Ignore()); // Ignora a recriação de State
            CreateMap<Student, StudentDTO>();

            CreateMap<AddressDTO, Address>().ReverseMap();
            CreateMap<CourseDTO, Course>().ReverseMap();
            CreateMap<EducationalInstitutionDTO, EducationalInstitution>().ReverseMap();
            CreateMap<StateDTO, State>().ReverseMap();
            CreateMap<CityDTO, City>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();
        }

        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile<Mapping>(); // Adiciona o perfil de mapeamento
            });
        }
    }
}
