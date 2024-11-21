using SchoolSystemApi.Model;

namespace SchoolSystemApi.Repository.IRepository
{
    public interface ITeacherRepository
    {
        ICollection<Teacher> GetTeachers();
        Teacher GetTeacher(int id);
        Teacher GetTeacherByName(string name);
        bool ExistTeacher(string name);
        bool ExistTeacher(int id);
        bool CreateTeacher(Teacher Teacher);
        bool UpdateTeacher(Teacher Teacher);
        bool DeleteTeacher(Teacher Teacher);
        bool Save();
    }
}
