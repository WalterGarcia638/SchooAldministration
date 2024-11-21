using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace SchoolSystemApi.Model
{
    public class StudentGradeDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ForeignKey("Grade")]
        public int GradeId { get; set; }
        public string Section { get; set; }
        public Student Student { get; set; }
        public Grade Grade {  get; set; }    
    }
}
