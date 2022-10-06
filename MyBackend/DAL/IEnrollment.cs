using MyBackend.Models;

namespace MyBackend.DAL
{
    public interface IEnrollment : ICrud<Enrollment>
    {
        public void Enrollment(int StudentId, int CourseID);
    }
}
