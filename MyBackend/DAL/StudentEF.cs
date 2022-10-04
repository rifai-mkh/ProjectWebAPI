/*using Microsoft.EntityFrameworkCore;
using MyBackend.Models;

namespace MyBackend.DAL
{
    public class StudentEF : IStudent
    {
        private AppDbContext _dbContext;
        public StudentEF(AppDbContext dbContext)
        {
            _dbContext = dbContext;
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
    }
}
*/