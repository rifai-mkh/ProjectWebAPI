namespace MyBackend.DTO
{
    public class EnrollmentStudentCourseDTO
    {
        public int EnrollmentId { get; set; }
        public int CourseID { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }
        public CourseDTO Course { get; set; }

        public StudentDTO Student { get; set; }

    }
}
