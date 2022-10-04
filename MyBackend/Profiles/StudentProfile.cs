using AutoMapper;
using MyBackend.DTO;
using MyBackend.Models;

namespace MyBackend.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentReadDTO, Student>();
            CreateMap<Student, StudentReadDTO>();

            CreateMap<StudentCreateDTO, Student>();
            CreateMap<Student, StudentCreateDTO>();

            CreateMap<CourseCreateDTO, Course>();
            CreateMap<Course, CourseCreateDTO>();

            CreateMap<CourseReadDTO, Course>();
            CreateMap<Course, CourseReadDTO>();
        }
    }
}
