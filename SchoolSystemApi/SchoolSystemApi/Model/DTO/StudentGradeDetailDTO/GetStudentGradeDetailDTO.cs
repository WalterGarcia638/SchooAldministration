namespace SchoolSystemApi.Model.DTO.StudentGradeDetailDTO
{
    public class GetStudentGradeDetailDTO
    {
        public int StudentId { get; set; }
        public int GradeId { get; set; }
        public string Section { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string GradeName { get; set;}
    }
}
