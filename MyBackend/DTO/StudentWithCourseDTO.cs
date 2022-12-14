namespace MyBackend.DTO
{
    public class StudentWithCourseDTO
    {
        public int Id { get; set; }
        public string FirstMidName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public List<CourseReadDTO> Courses { get; set; }
    }
}
