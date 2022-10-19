using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MyBackend.DAL;
using MyBackend.DTO;
using MyBackend.Models;

namespace MyBackend.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourse _courseDAL;
        private readonly ICourse _course;
        private readonly IMapper _mapper;
        private readonly IStudent _student;

        public CoursesController(ICourse courseDAL, IMapper mapper, ICourse course, IStudent student)
        {
            _courseDAL = courseDAL;
            _mapper = mapper;
            _course = course;
            _student = student;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseReadDTO>> Get()
        {
            var allcourse = await _courseDAL.GetAll();
            var listCourseReadDto = _mapper.Map<IEnumerable<CourseReadDTO>>(allcourse);
            return listCourseReadDto;
        }        

        [HttpGet("GetBy{courseID}")]
        public async Task<CourseReadDTO> Get(int courseID)
        {
            var result = await _courseDAL.GetById(courseID);
            var courseReadDto = _mapper.Map<CourseReadDTO>(result);
            return courseReadDto;
        }

        

        [HttpGet("ByTitle")]
        public IEnumerable<CourseReadDTO> GetByTitle(string title)
        {
            var results = _courseDAL.GetByTitle(title);
            var listCourseReadDto = _mapper.Map<IEnumerable<CourseReadDTO>>(results);
            return listCourseReadDto;
        }            

        //Query untuk menampilkan Semua Student beserta dengan Semua Course yang diambil
        [HttpGet("StudentsWithCourses")]
        public IEnumerable<StudentWithCourseDTO> GetCourseWithCourse()
        {
            var results = _student.GetAllWithCourse();
            var listStudentWithCourseDto = _mapper.Map<IEnumerable<StudentWithCourseDTO>>(results);
            return listStudentWithCourseDto;
        }


        [HttpPost]
        public async Task<ActionResult> Post(CourseCreateDTO courseCreateDTO)
        {
            try
            {
                var newcourse = _mapper.Map<Course>(courseCreateDTO);
                var result = await _courseDAL.Insert(newcourse);
                var courseDTO = _mapper.Map<CourseReadDTO>(result);
                return CreatedAtAction("Get", new { id = courseCreateDTO.CourseID }, courseDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddExistingStudentToCourse")]
        public IActionResult AddStudentToCourse(AddStudentToCourseDTO addStudentToCourseDTO)
        {
            try
            {
                _course.AddStudentToCourse(addStudentToCourseDTO.StudentId, addStudentToCourseDTO.CourseID);
                return Ok($"Student Id {addStudentToCourseDTO.StudentId} berhasil ditambahkan ke course {addStudentToCourseDTO.CourseID}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*[HttpPost("AddNewStudentToCourse")]
        public IActionResult AddNewStudentToCourse(AddStudentToCourseDTO addStudentToCourseDTO)
        {
            try
            {
                _course.AddStudentToCourse(addStudentToCourseDTO.StudentId, addStudentToCourseDTO.CourseID);
                return Ok($"Student Id {addStudentToCourseDTO.StudentId} berhasil ditambahkan ke course {addStudentToCourseDTO.CourseID}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        [HttpPost("RemoveCourseFromStudent")]
        public IActionResult RemoveCourseFromStudent(AddStudentToCourseDTO studentCourseDto)
        {
            try
            {
                _student.RemoveCourseFromStudent(studentCourseDto.StudentId, studentCourseDto.CourseID);
                return Ok($"Remove course {studentCourseDto.CourseID} from Student {studentCourseDto.StudentId} sukses.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("WithCourse/{studentId}")]
        public StudentWithCourseDTO GetStudentWithCourse(int studentId)
        {
            var students = _student.GetStudentWithCourse(studentId);
            var samuraiWithBattleDto = _mapper.Map<StudentWithCourseDTO>(students);
            return samuraiWithBattleDto;
        }

        [HttpGet("WithStudent/{courseID}")]
        public CourseWithStudentDTO GetCourseWithStudent(int courseID)
        {
            var courses = _student.GetCourseWithStudent(courseID);
            var samuraiWithBattleDto = _mapper.Map<CourseWithStudentDTO>(courses);
            return samuraiWithBattleDto;
        }
        /*[HttpPost("AddEnrollment")]
        public IActionResult AddEnrollment(EnrollmentAddDTO enrollmentDTO)
        {
            try
            {
                _course.AddEnrollment(enrollmentDTO.StudentId, enrollmentDTO.CourseID, enrollmentDTO.EnrollmentID, enrollmentDTO.Grade);
                return Ok($"Student Id {enrollmentDTO.StudentId} berhasil ditambahkan ke course {enrollmentDTO.CourseID}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        [HttpDelete("{courseID}")]
        public async Task<ActionResult> Delete(int courseID)
        {
            try
            {
                await _courseDAL.Delete(courseID);
                return Ok($"Data dengan course ID {courseID} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        

    }
}
