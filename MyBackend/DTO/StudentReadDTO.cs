namespace MyBackend.DTO
{
    public class StudentReadDTO
    {
        public int Id { get; set; }
        public string FirstMidName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public DateTime EnrollmentDate { get; set; }

    }
}
