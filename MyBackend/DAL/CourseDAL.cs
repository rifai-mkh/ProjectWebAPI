using MyBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBackend.DAL
{
    public class CourseDAL : ICourse
    {
        private readonly AppDbContext _dbcontext;
        
        public CourseDAL(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            
        }


        Task ICourse.AddCourseExisting(int courseID, string title, int credits)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int courseID)
        {
            try
            {
                var delete = await _dbcontext.Courses.FirstOrDefaultAsync(s => s.CourseID == courseID);
                if (delete == null)
                    throw new Exception($"Data dengan Course id {courseID} tidak ditemukan");
                _dbcontext.Courses.Remove(delete);
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

        }

        Task ICourse.DeleteKCourseProduk(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            var allcourse = await _dbcontext.Courses.OrderBy(q => q.CourseID).ToListAsync();
            return allcourse;
        }

        public IEnumerable<Course> GetByTitle(string title)
        {
            var bytitle = _dbcontext.Courses.Where(c => c.Title.Contains(title));
            return bytitle;
        }


        public async Task<Course> GetById(int courseID)
        {
            var result = _dbcontext.Courses.FirstOrDefault(s => s.CourseID == courseID);
            
            if (result == null)
                throw new Exception($"Data Course Id {courseID} tidak ditemukan");
            return result;

        }



        public async Task<Course> Insert(Course obj)
        {

            try
            {
                _dbcontext.Courses.Add(obj);
                await _dbcontext.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }       


        Task<Course> ICrud<Course>.Update(Course obj)
        {
            throw new NotImplementedException();
        }

        //implemen dan method untuk add student to course
        public void AddStudentToCourse(int studentId, int courseID)
        {
            try
            {
                var student = _dbcontext.Students.FirstOrDefault(s => s.Id == studentId);
                var course = _dbcontext.Courses.FirstOrDefault(b => b.CourseID == courseID);
                if (student != null && course != null)
                {
                    course.Students.Add(student);
                    _dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Student>> GetByStudentId(int studentId)
        {
            throw new NotImplementedException();
        }

        public void AddEnrollment(int enrollmentID, int studentId, int courseID, string grade)
        {
            try
            {
                var enrollment = _dbcontext.Enrollments.FirstOrDefault(c => c.EnrollmentId== enrollmentID);
                var student = _dbcontext.Students.FirstOrDefault(s => s.Id == studentId);
                var course = _dbcontext.Courses.FirstOrDefault(b => b.CourseID == courseID);
                if (student != null && course != null)
                {
                    course.Enrollments.Add(enrollment);
                    _dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Course> GetBy(int id)
        {
            var result = _dbcontext.Courses.FirstOrDefault(s => s.CourseID == id);

            if (result == null)
                throw new Exception($"Data Course Id {id} tidak ditemukan");
            return result;
        }

        /*public void RemoveCourseFromStudent(int studentId, int courseID)
        {
            try
            {
                var battleWithSamurai = _dbcontext.Courses.Include(b => b.Students.Where(s => s.Id == studentId))
                .FirstOrDefault(s => s.CourseID == courseID);
                var student = battleWithSamurai.Students[0];
                battleWithSamurai.Students.Remove(student);
                _dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }*/



        /*public async Task<Course> GetCourseWithStudent(int courseID)
        {
            var result = _dbcontext.Courses.Include(s => s.Students)
                .FirstOrDefault(s => s.CourseID == courseID);
            if (result == null)
                throw new Exception($"samurai id {courseID} tidak ditemukan");

            return result;
        }*/
    }
}