using AutoMapper;
using SchoolSystemApi.Model;
using SchoolSystemApi.Model.DTO;
using SchoolSystemApi.Model.DTO.GradeDTO;
using SchoolSystemApi.Model.DTO.StudentGradeDetailDTO;
using SchoolSystemApi.Model.DTO.TeacherDTO;
using System.Runtime.InteropServices;

namespace SchoolSystemApi.Mapper
{
    public class SchoolSystemMapper : Profile
    {
        public  SchoolSystemMapper() 
        {
            //Studend
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Student, UpdateStudentDTO>().ReverseMap();
            CreateMap<Student, GetStudentsDTO>()
            .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name));

            //Teacher
            CreateMap<Teacher, TeacherDTO>().ReverseMap();
            CreateMap<Teacher, UpdateTeacherDTO>().ReverseMap();

            //Grade
            CreateMap<Grade, GradeDTO>().ReverseMap();
            CreateMap<Grade, UpdateGradeDTO>().ReverseMap();
            CreateMap<Grade, GetGradeDTO>()
                .ForMember(dest => dest.TeacherFirstName, opt => opt.MapFrom(src => src.Teacher.FirstName))
                .ForMember(dest => dest.TeacherLastName, opt => opt.MapFrom(src => src.Teacher.LastName));

            //StudentGradeDetails
            CreateMap<StudentGradeDetail, StudentGradeDetailDTO>().ReverseMap();
            CreateMap<StudentGradeDetail, UpdateStudentGradeDetailDTO>().ReverseMap();
            CreateMap<StudentGradeDetail, GetStudentGradeDetailDTO>()
                .ForMember(dest => dest.StudentFirstName, opt => opt.MapFrom(src => src.Student.FirstName))
                .ForMember(dest => dest.StudentLastName, opt => opt.MapFrom(src => src.Student.LastName))
                .ForMember(dest => dest.GradeName, opt => opt.MapFrom(src => src.Grade.Name));




        }

    }
}
