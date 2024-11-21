namespace SchoolSystemApi.Model.DTO.StudentGradeDetailDTO
{
    public class UpdateStudentGradeDetailDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int GradeId { get; set; }
        public string Section { get; set; }
    }
}
