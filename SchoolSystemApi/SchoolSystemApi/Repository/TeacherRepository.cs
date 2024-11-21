using SchoolSystemApi.Data;
using SchoolSystemApi.Model;
using SchoolSystemApi.Repository.IRepository;

namespace SchoolSystemApi.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _db;
        public TeacherRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public ICollection<Teacher> GetTeachers()
        {
            return _db.Teacher.OrderBy(b => b.Id).ToList();
        }

        public bool CreateTeacher(Teacher Teacher)
        {
            _db.Teacher.Add(Teacher);
            return Save();
        }

        public bool DeleteTeacher(Teacher Teacher)
        {
            _db.Teacher.Remove(Teacher);
            return Save();
        }

        public bool ExistTeacher(string name)
        {
            bool value = _db.Teacher.Any(b => b.FirstName.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool ExistTeacher(int id)
        {
            return _db.Teacher.Any(brand => brand.Id == id);
        }

        public Teacher GetTeacher(int id)
        {
            return _db.Teacher.FirstOrDefault(b => b.Id == id);
        }

        public Teacher GetTeacherByName(string name)
        {
            return _db.Teacher.FirstOrDefault(b => b.FirstName == name);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateTeacher(Teacher Teacher)
        {
            _db.Teacher.Update(Teacher);
            return Save();
        }
    }
}
