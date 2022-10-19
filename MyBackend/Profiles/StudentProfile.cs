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

            CreateMap<StudentUpdateDTO, Student>();
            CreateMap<Student, StudentUpdateDTO>();

            CreateMap<CourseCreateDTO, Course>();
            CreateMap<Course, CourseCreateDTO>();

            CreateMap<CourseReadDTO, Course>();
            CreateMap<Course, CourseReadDTO>();

            CreateMap<AddStudentToCourseDTO, Course>();
            CreateMap<Course, AddStudentToCourseDTO>();

            CreateMap<Student, StudentWithCourseDTO>();
            CreateMap<StudentWithCourseDTO, Student>();

            CreateMap<Course, StudentWithCourseDTO>();
            CreateMap<StudentWithCourseDTO, Course>();

            CreateMap<EnrollmentAddDTO, Enrollment>();
            CreateMap<Enrollment, EnrollmentAddDTO>();

            CreateMap<EnrollmentGetDTO, Enrollment>();
            CreateMap<Enrollment, EnrollmentGetDTO>();

            CreateMap<StudentWithCourseDTO, Student>();
            CreateMap<Student, StudentWithCourseDTO>();

            CreateMap<StudentWithCourseDTO, Course>();
            CreateMap<Course, StudentWithCourseDTO>();

            CreateMap<CourseWithStudentDTO, Course>();
            CreateMap<Course, CourseWithStudentDTO>();

            //mapping Enrollment
            CreateMap<EnrollmentDTO, Enrollment>();
            CreateMap<Enrollment, EnrollmentDTO>();
            CreateMap<EnrollmentCreateDTO, Enrollment>();
            CreateMap<Enrollment, EnrollmentCreateDTO>();
            CreateMap<EnrollmentEditDTO, Enrollment>();
            CreateMap<Enrollment, EnrollmentEditDTO>();

  
        }
    }
}
