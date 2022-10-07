using Microsoft.EntityFrameworkCore;
using MyBackend.DAL;
using MyBackend.DTO;
using MyBackend.Models;

namespace MyBackend.DAL
{
    public class EnrollmentDAL : IEnrollment
    {
        private AppDbContext _dbcontext;
       

        public EnrollmentDAL(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void AddEnrollment(int EnrollmentId, int StudentId, int CourseID)
        {
            try
            {
                var enrollment = _dbcontext.Enrollments.FirstOrDefault(c => c.EnrollmentId == EnrollmentId);
                var course = _dbcontext.Courses.FirstOrDefault(c => c.CourseID == CourseID);
                var student = _dbcontext.Students.FirstOrDefault(s => s.Id == StudentId);

                if (student != null && course != null)

                    //course.students.Add(student);
                    _dbcontext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Enrollment> GetCourseWithStudent(int courseID)
        {
            throw new NotImplementedException();
        }

        public async Task<Enrollment> Insert(Enrollment obj)
        {

            try
            {
                _dbcontext.Enrollments.Add(obj);
                await _dbcontext.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        Task ICrud<Enrollment>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        

        Task<IEnumerable<Enrollment>> ICrud<Enrollment>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Enrollment> ICrud<Enrollment>.GetBy(int id)
        {
            throw new NotImplementedException();
        }

        Task<Enrollment> ICrud<Enrollment>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        /*Task<Enrollment> ICrud<Enrollment>.Insert(Enrollment obj)
        {
            throw new NotImplementedException();
        }*/

        Task<Enrollment> ICrud<Enrollment>.Update(Enrollment obj)
        {
            throw new NotImplementedException();
        }
    }
}
