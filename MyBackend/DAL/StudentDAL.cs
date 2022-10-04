using Microsoft.EntityFrameworkCore;
using MyBackend.Models;
using System.Data.SqlClient;

namespace MyBackend.DAL
{
    public class StudentDAL : IStudent
    {
        private readonly IConfiguration _config;
        public StudentDAL(IConfiguration config)
        {
            _config = config;
        }
        private string GetConn()
        {
            return _config.GetConnectionString("StudentConnection");
        }

        public IEnumerable<Student> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConn()))
            {
                List<Student> listStudent = new List<Student>();
                string strSql = @"select * from Students order by Id asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        listStudent.Add(new Student()
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            FirstMidName = dr["FirstMidName"].ToString(),
                            LastName = dr["LastName"].ToString()
                        });
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();

                return listStudent;
            }

        }

        public Student GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConn()))
            {
                Student student = new Student();
                string strSql = @"select * from Students where Id=@Id";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    student.Id = Convert.ToInt32(dr["Id"]);
                    student.FirstMidName = dr["FirstMidName"].ToString();
                    student.LastName = dr["LastName"].ToString();
                }

                dr.Close();
                cmd.Dispose();
                conn.Close();

                return student;
            }

        }

        /*public IEnumerable<Student> GetByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConn()))
            {
                List<Student> listStudent = new List<Student>();
                string strSql = @"select * from Students 
                                  where Name like @FirstMidName or @LastName
                                  order by FirstMidName asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@Name", "%" + name + "%");
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        listStudent.Add(new Student()
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            FirstMidName = dr["Name"].ToString()
                        });
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();

                return listStudent;
            }
        }*/

        public Student Insert(Student student)
        {
            using (SqlConnection conn = new SqlConnection(GetConn()))
            {
                string strSql = @"insert into Students(FirstMidName, LastName) values(@FirstMidName, @LastName);select @@identity";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@FirstMidName", student.FirstMidName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                try
                {
                    conn.Open();
                    int idNum = Convert.ToInt32(cmd.ExecuteScalar());
                    student.Id = idNum;
                    return student;
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

        }

        /*public async Task<Student> Insert(Student obj)
        {
            try
            {
                _context.Students.Add(obj);
                await _context.SaveChangesAsync();
                return obj;

            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }*/


        public Student Update(Student student)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConn()))
            {
                string strSql = @"delete from Students where Id=@Id";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                try
                {
                    conn.Open();
                    int status = cmd.ExecuteNonQuery();
                    if (status != 1)
                        throw new Exception($"Gagal delete data dengan id {id}");
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }

        }

        public IEnumerable<Student> GetByLastName(string lastname)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetByFirstMidName(string firstmidname)
        {
            throw new NotImplementedException();
        }
    }
}
