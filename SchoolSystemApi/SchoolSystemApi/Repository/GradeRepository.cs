using Microsoft.EntityFrameworkCore;
using SchoolSystemApi.Data;
using SchoolSystemApi.Model;
using SchoolSystemApi.Repository.IRepository;

namespace SchoolSystemApi.Repository
{
    public class GradeRepository : IGradeRepository
    {
        private readonly ApplicationDbContext _db;
        public GradeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public ICollection<Grade> GetGrades()
        {
            return _db.Grade
                    .Include(g => g.Teacher)
                    .OrderBy(b => b.Id)
                    .ToList();
        }

        public bool CreateGrade(Grade Grade)
        {
            _db.Grade.Add(Grade);
            return Save();
        }

        public bool DeleteGrade(Grade Grade)
        {
            _db.Grade.Remove(Grade);
            return Save();
        }

        public bool ExistGrade(string name)
        {
            bool value = _db.Grade.Any(b => b.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool ExistGrade(int id)
        {
            return _db.Grade.Any(brand => brand.Id == id);
        }

        public Grade GetGrade(int id)
        {
            return _db.Grade.FirstOrDefault(b => b.Id == id);
        }

        public Grade GetGradeByName(string name)
        {
            return _db.Grade.FirstOrDefault(b => b.Name == name);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateGrade(Grade Grade)
        {
            _db.Grade.Update(Grade);
            return Save();
        }
    }
}

