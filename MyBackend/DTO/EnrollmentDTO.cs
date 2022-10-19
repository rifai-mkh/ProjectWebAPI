namespace MyBackend.DTO
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class EnrollmentDTO
    {
        public int EnrollmentId { get; set; }
        public int CourseID { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }
    }
}
