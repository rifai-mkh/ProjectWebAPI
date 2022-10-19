namespace MyBackend.DTO
{
    public class EnrollmentEditDTO
    {
        public int EnrollmentId { get; set; }
        public int CourseID { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }
    }
}
