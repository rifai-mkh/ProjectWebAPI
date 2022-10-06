using MyBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBackend.DAL;

namespace MyBackend.DAL
{
    public interface ICourse : ICrud<Course>
    {
        Task AddCourseExisting(int courseID, string title, int credits);

        Task DeleteKCourseProduk(int id);
        public void AddStudentToCourse(int studentId, int courseID);
        //public void RemoveCourseFromStudent(int studentId, int courseID);
        public void AddEnrollment(int enrollmentID, int studentId, int courseID, string grade);
        public IEnumerable<Course> GetByTitle(string title);
        //public Student GetCourseWithStudent(int courseID);
        //public IEnumerable<Student> GetByStudentId(int studentId);

    }
}