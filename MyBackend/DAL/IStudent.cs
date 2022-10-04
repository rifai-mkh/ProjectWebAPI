using MyBackend.Models;

namespace MyBackend.DAL
{
    public interface IStudent
    {
        public IEnumerable<Student> GetAll();
        public Student GetById(int id);
        /*public IEnumerable<Student> GetByLastName(string lastname);
        public IEnumerable<Student> GetByFirstMidName(string firstmidname);*/
        public Student Insert(Student student);
        public Student Update(Student student);
        public void Delete(int id);
    }
}
