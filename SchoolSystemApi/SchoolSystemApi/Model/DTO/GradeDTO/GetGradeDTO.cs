namespace SchoolSystemApi.Model.DTO.GradeDTO
{
    public class GetGradeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public string TeacherFirstName { get; set;}
        public string TeacherLastName { get; set; }
    }
}
