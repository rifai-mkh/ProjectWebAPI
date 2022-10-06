/*using Microsoft.EntityFrameworkCore;
using MyBackend.Models;

namespace MyBackend.DAL
{
    public class StudentEF : IStudent
    {
        private AppDbContext _dbcontext;
        public StudentEF(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        void IStudent.Delete(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Student> IStudent.GetAll()
        {
            throw new NotImplementedException();
        }

        Student IStudent.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Student IStudent.Insert(Student student)
        {
            throw new NotImplementedException();
        }

        Student IStudent.Update(Student student)
        {
            throw new NotImplementedException();
        }


        //menambahkan student ke course
       public void AddStudentToCourse(int studentId, int courseID)
        {
            try
            {
                var student = _dbcontext.Students.FirstOrDefault(s => s.Id == studentId);
                var course = _dbcontext.Courses.FirstOrDefault(b => b.CourseID == courseID);
                if (student != null && course != null)
                {
                    //battle.Samurais = new List<Samurai>();
                    course.Students.Add(student);
                    _dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AddStudentToCourse(int studentId, int courseID)
        {
            var ambilproduk = _dbcontext.Students.FirstOrDefault(s => s.Id == studentId);
            var ambilkatalog = _dbcontext.Courses.FirstOrDefault(s => s.CourseID == courseID);

            ambilkatalog.Students.Add(ambilproduk);
            //katalogg.Produks.Add(produkk);

            await _dbcontext.SaveChangesAsync();
        }*/

        /*void IStudent.AddStudentToCourse(int studentId, int courseID)
        {
            throw new NotImplementedException();
        }
    }

    
}*/
