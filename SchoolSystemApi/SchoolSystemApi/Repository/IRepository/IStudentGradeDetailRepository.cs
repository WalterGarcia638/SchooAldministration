using SchoolSystemApi.Model;

namespace SchoolSystemApi.Repository.IRepository
{
    public interface IStudentGradeDetailRepository
    {
        ICollection<StudentGradeDetail> GetStudentGradeDetails();
        StudentGradeDetail GetStudentGradeDetail(int id);
        bool ExistStudentGradeDetail(int id);
        bool CreateStudentGradeDetail(StudentGradeDetail StudentGradeDetail);
        bool UpdateStudentGradeDetail(StudentGradeDetail StudentGradeDetail);
        bool DeleteStudentGradeDetail(StudentGradeDetail StudentGradeDetail);
        bool Save();
    }
}
