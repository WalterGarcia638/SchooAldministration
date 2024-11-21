using SchoolSystemApi.Model;

namespace SchoolSystemApi.Repository.IRepository
{
    public interface IGradeRepository
    {
        ICollection<Grade> GetGrades();
        Grade GetGrade(int id);
        Grade GetGradeByName(string name);
        bool ExistGrade(string name);
        bool ExistGrade(int id);
        bool CreateGrade(Grade Grade);
        bool UpdateGrade(Grade Grade);
        bool DeleteGrade(Grade Grade);
        bool Save();
    }
}
