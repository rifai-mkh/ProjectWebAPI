using MyBackend.Models;

namespace MyBackend.DAL
{
    public interface IEnrollment : ICrud<Enrollment>
    {
        public void AddEnrollment(int EnrollmentId, int StudentId, int CourseID);
    }
}
