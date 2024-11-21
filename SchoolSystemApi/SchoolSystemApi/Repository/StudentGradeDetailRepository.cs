using Microsoft.EntityFrameworkCore;
using SchoolSystemApi.Data;
using SchoolSystemApi.Model;
using SchoolSystemApi.Repository.IRepository;

namespace SchoolSystemApi.Repository
{
    public class StudentGradeDetailRepository : IStudentGradeDetailRepository
    {
        private readonly ApplicationDbContext _db;
        public StudentGradeDetailRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public ICollection<StudentGradeDetail> GetStudentGradeDetails()
        {
            return _db.StudentGradeDetail
             .Include(s => s.Student)
             .Include(g => g.Grade)
             .OrderBy(b => b.Id)
             .ToList();
        }

        public bool CreateStudentGradeDetail(StudentGradeDetail StudentGradeDetail)
        {
            _db.StudentGradeDetail.Add(StudentGradeDetail);
            return Save();
        }

        public bool DeleteStudentGradeDetail(StudentGradeDetail StudentGradeDetail)
        {
            _db.StudentGradeDetail.Remove(StudentGradeDetail);
            return Save();
        }

        public bool ExistStudentGradeDetail(int id)
        {
            return _db.StudentGradeDetail.Any(brand => brand.Id == id);
        }

        public StudentGradeDetail GetStudentGradeDetail(int id)
        {
            return _db.StudentGradeDetail.FirstOrDefault(b => b.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateStudentGradeDetail(StudentGradeDetail StudentGradeDetail)
        {
            _db.StudentGradeDetail.Update(StudentGradeDetail);
            return Save();
        }
    }
}
