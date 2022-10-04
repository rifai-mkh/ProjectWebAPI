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


        Task<Course> ICrud<Course>.GetById(int id)
        {
            throw new NotImplementedException();
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

        /*public Course Insert(Course course)
        {
            using (SqlConnection conn = new SqlConnection(GetConn()))
            {
                string strSql = @"insert into Courses(Title, Credits) values(@Title, @Credits);select @@identity";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@Title", course.Title);
                cmd.Parameters.AddWithValue("@Credits", course.Credits);
                try
                {
                    conn.Open();
                    int idNum = Convert.ToInt32(cmd.ExecuteScalar());
                    course.courseID = idNum;
                    return course;
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Error: {sqlEx.Message}");
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }

        }*/


        Task<Course> ICrud<Course>.Update(Course obj)
        {
            throw new NotImplementedException();
        }
    }
}
