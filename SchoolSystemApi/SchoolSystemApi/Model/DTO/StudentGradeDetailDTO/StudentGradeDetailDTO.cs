using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystemApi.Model.DTO.StudentGradeDetailDTO
{
    public class StudentGradeDetailDTO
    {
        public int StudentId { get; set; }
        public int GradeId { get; set; }
        public string Section { get; set; }
    }
}
