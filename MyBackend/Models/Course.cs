﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MyBackend.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();

        //public Student student { get; set; }
        //public int StudentId { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}