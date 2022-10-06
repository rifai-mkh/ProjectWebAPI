namespace MyBackend.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstMidName { get; set; }
        public string LastName { get; set; }

        public List<Course> Courses { get; set; } = new List<Course>();
        public DateTime EnrollmentDate { get; set; } = DateTime.Today;

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
