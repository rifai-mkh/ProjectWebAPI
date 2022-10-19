﻿using MyBackend.Models;

namespace MyBackend.DAL
{
    public interface IEnrollment : ICrud<Enrollment>
    {
        Task<Enrollment> InsertEnrollment(Enrollment obj, int studentID, int courseID);
        Task<IEnumerable<Enrollment>> GetEnrollmentStudentCourses();

        Task<IEnumerable<Enrollment>> Pagging(int skip, int take);

    }
}
