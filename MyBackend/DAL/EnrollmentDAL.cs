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
         public async Task Delete(int id)
        {
            try
            {
                var delete = await _dbcontext.Enrollments.FirstOrDefaultAsync(s => s.EnrollmentId == id);
                if (delete == null)
                    throw new Exception($"Data dengan id {id} tidak ditemukan");
                _dbcontext.Enrollments.Remove(delete);
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<Enrollment>> GetAll()
        {
            var results = await _dbcontext.Enrollments.OrderBy(s => s.EnrollmentId).ToListAsync();
            return results;
        }


        public async Task<Enrollment> GetById(int id)
        {
            var result = await _dbcontext.Enrollments.Include(s => s.Course).Include(s => s.Student).FirstOrDefaultAsync(s => s.EnrollmentId == id);
            if (result == null) throw new Exception($"Data dengan id {id} tidak ditemukan");
            return result;
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentStudentCourses()
        {
            var results = await _dbcontext.Enrollments.Include(s => s.Course).Include(s => s.Student).ToListAsync();
            return results;
        }


        public async Task<Enrollment> Insert(Enrollment obj)
        {
            try
            {
                //obj.CourseID = obj.Course.CourseID;
                //obj.StudentID = await _context.Students.Select(n => n.value = ID).ToListAsync();
                _dbcontext.Enrollments.Add(obj);
                //List<AppContext> students = _context.Students.Select(n =>
                //new AppContext
                //{
                //    Value = n.ID,
                //    Text = n.FirstMidName
                //}).ToList();
                
                await _dbcontext.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

        }

        public async Task<Enrollment> InsertEnrollment(Enrollment obj, int studentId, int courseID)
        {


            obj.StudentId = studentId;
            obj.CourseID = courseID;

            _dbcontext.Enrollments.Add(obj);
            await _dbcontext.SaveChangesAsync();
            
            return obj;


        }

        public async Task<IEnumerable<Enrollment>> Pagging(int skip, int take)
        {
            var results = await _dbcontext.Enrollments.Include(s => s.Course).Include(s => s.Student)
               .Skip(skip).Take(take).ToArrayAsync();
            return results;
        }

        public async Task<Enrollment> Update(Enrollment obj)
        {
            try
            {
                var update = await _dbcontext.Enrollments.FirstOrDefaultAsync(s => s.EnrollmentId == obj.EnrollmentId);
                if (update == null)
                    throw new Exception($"Data dengan id {obj.EnrollmentId} tidak ditemukan");

                update.CourseID = obj.CourseID;
                update.StudentId = obj.StudentId;
                update.Grade = obj.Grade;
               
                await _dbcontext.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        
    }
}
