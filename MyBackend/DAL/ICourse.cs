using MyBackend.Models;

namespace MyBackend.DAL
{
    public interface ICourse : ICrud<Course>
    {
        Task AddCourseExisting(int courseID, string title, int credits);
        Task DeleteKCourseProduk(int id);

        public void AddStudentToCourse(int studentId, int courseID);
        public void AddEnrollment(int enrollmentID, int studentId, int courseID, string grade);
        public IEnumerable<Course> GetByTitle(string title);
        Task<IEnumerable<Course>> Pagging(int skip, int take);

    }
}