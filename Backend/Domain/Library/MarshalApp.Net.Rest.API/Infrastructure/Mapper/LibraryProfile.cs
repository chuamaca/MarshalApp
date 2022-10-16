using AutoMapper;
using MarshalApp.Net.Rest.Infrastructure.Data.Entities;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers;

namespace MarshalApp.Net.Rest.API.Infrastructure.Mapper
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge(src.DateOfDeath)));

            CreateMap<Book, BookDto>();
            CreateMap<AuthorForCreationDto, Author>();
            CreateMap<AuthorForCreationWithDateOfDeathDto, Author>();
            CreateMap<AuthorForUpdateDto, Author>();
            CreateMap<Author, AuthorForUpdateDto>();
            CreateMap<BookForCreationDto, Book>();
            CreateMap<BookForUpdateDto, Book>();
            CreateMap<Book, BookForUpdateDto>();

            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Collegecareer, opt => opt.MapFrom(src => src.Collegecareer))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));

            CreateMap<Grade, GradeDto>();
            CreateMap<StudentForCreationDto, Student>();
            //  CreateMap<EstudianteDto, Estudiante>();
            CreateMap<StudentForUpdateDto, Student>();
            CreateMap<Student, StudentForUpdateDto>();
            CreateMap<GradeForCreationDto, Grade>();
            CreateMap<GradeForUpdateDto, Grade>();
            CreateMap<Grade, GradeForUpdateDto>();
        }
    }
}
