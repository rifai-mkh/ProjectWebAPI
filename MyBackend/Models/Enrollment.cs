namespace MyBackend.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int CourseID { get; set; }
        public int StudentId { get; set; }
        //public Grade? Grade { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
