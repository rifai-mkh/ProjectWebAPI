using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBackend.DTO;
using MyBackend.Models;
using System.Data.SqlClient;

namespace MyBackend.DAL
{
    public class StudentDAL : IStudent
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _dbcontext;
        public StudentDAL(IConfiguration config, AppDbContext dbcontext)
        {
            _config = config;
            _dbcontext = dbcontext;
        }

        public IEnumerable<Student> GetAll()
        {
            var results = _dbcontext.Students.OrderBy(s => s.LastName).ToList();
            return results;
        }

        public Student GetById(int Id)
        {
            try
            {
                var result = _dbcontext.Students.FirstOrDefault(s => s.Id == Id);
                /*var result = (from s in _dbcontext.students
                              where s.ID==id
                              select s).FirstOrDefault():*/
                return result;
            }
            catch
            {
                throw new Exception($"Data Student {Id} tidak ditemukan");
            }
        }

        public IEnumerable<Student> GetByfirstMidName(string firstmidname)
        {
            var results = _dbcontext.Students.
                Where(s => s.FirstMidName.Contains(firstmidname)).OrderBy(s => s.FirstMidName);
            return results;
        }

        public IEnumerable<Student> GetByLastName(string lastname)
        {
            var results = _dbcontext.Students.
                Where(s => s.LastName.Contains(lastname)).OrderBy(s => s.LastName);
            return results;
        }


        public Student Insert(Student student)
        {
            try
            {
                _dbcontext.Students.Add(student);
                _dbcontext.SaveChanges();
                return student;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*public async Task<Student> Insert(Student student)
        {
            try
            {
                _dbcontext.Students.Add(student);
                await _dbcontext.SaveChangesAsync();
                return student;

            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }*/

        public Student GetStudentWithCourse(int studentId)
        {
            var result = _dbcontext.Students.Include(s => s.Courses)
                .FirstOrDefault(s => s.Id == studentId);
            if (result == null)
                throw new Exception($"student id {studentId} tidak ditemukan");

            return result;
        }

        public Course GetCourseWithStudent(int courseID)
        {
            var result = _dbcontext.Courses.Include(s => s.Students)
                .FirstOrDefault(s => s.CourseID == courseID);
            if (result == null)
                throw new Exception($"course id {courseID} tidak ditemukan");

            return result;
        }

        public Student Update(Student student)
        {
            try
            {
                var studentUpdate = GetById(student.Id);
                if (studentUpdate == null)
                {
                    throw new Exception($"Data student id {student.Id} tidak ditemukan");
                }

                studentUpdate.LastName = student.LastName;
                studentUpdate.FirstMidName = student.FirstMidName;
                _dbcontext.SaveChanges();

                return student;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        

        public void Delete(int id)
        {
            var deleteStudent = GetById(id);
            if (deleteStudent == null)
                throw new Exception($"Data student dengan id {id} tidak ditemukan");
            try
            {
                _dbcontext.Remove(deleteStudent);
                _dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }       


        public IEnumerable<Student> GetAllWithCourse()
        {
            var results = _dbcontext.Students.Include(s => s.Courses);
            return results;
        }

        public void RemoveCourseFromStudent(int studentId, int courseID)
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
        }
    }
}
