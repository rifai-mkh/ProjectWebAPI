using MyBackend.Models;

namespace MyBackend.DAL
{
    public interface IStudent
    {
        public IEnumerable<Student> GetAll();
        public IEnumerable<Student> GetAllWithCourse();
        public Student GetStudentWithCourse(int studentId);
        public Course GetCourseWithStudent(int courseID);

        public Student GetById(int id);
        public IEnumerable<Student> GetByLastName(string lastname);
        public IEnumerable<Student> GetByfirstMidName(string firstmidname);
        public Student Insert(Student student);
        public Student Update(Student student);        
        public void Delete(int id);
        void RemoveCourseFromStudent(int studentId, int courseID);
    }
}
