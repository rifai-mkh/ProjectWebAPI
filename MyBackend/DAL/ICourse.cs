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
    }
}