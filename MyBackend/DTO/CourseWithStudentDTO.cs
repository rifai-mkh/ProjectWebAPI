namespace MyBackend.DTO
{
    public class CourseWithStudentDTO
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public List<StudentReadDTO> Students { get; set; }
    }
}
