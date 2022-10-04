using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBackend.DAL;
using MyBackend.DTO;
using MyBackend.Models;

namespace MyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourse _courseDAL;
        private readonly IMapper _mapper;
        public CoursesController(ICourse courseDAL, IMapper mapper)
        {
            _courseDAL = courseDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseReadDTO>> Get()
        {

            var results = await _courseDAL.GetAll();
            var allcourse = _mapper.Map<IEnumerable<CourseReadDTO>>(results);

            return allcourse;
        }



        /*[HttpGet]
        public IEnumerable<CourseReadDTO> GetAll()
        {
            var results = _course.GetAll();
            var listCourseReadDto = _mapper.Map<IEnumerable<CourseReadDTO>>(results);
            return listCourseReadDto;
        }

        [HttpGet("{courseid}")]
        public CourseReadDTO Get(int courseid)
        {
            var result = _course.GetById(courseid);
            var courseReadDto = _mapper.Map<CourseReadDTO>(result);
            return courseReadDto;
        }*/

        [HttpPost]
        public IActionResult Post(CourseCreateDTO courseCreateDto)
        {
            try
            {
                var course = _mapper.Map<Course>(courseCreateDto);
                var newCourse = _courseDAL.Insert(course);
                //var result = _mapper.Map<CourseCreateDTO>(newCourse);
                var courseReadDTO = _mapper.Map<CourseReadDTO>(newCourse);
                return CreatedAtAction("Get", new { id = courseCreateDto.CourseID }, courseCreateDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*[HttpPost]
        public IActionResult Post(CourseCreateDTO courseCreateDTO)
        {
            try
            {
                var course = _mapper.Map<Course>(courseCreateDTO);
                var newcourse = _courses.Insert(course);

                var courseReadDTO = _mapper.Map<CourseReadDTO>(newcourse);

                return CreatedAtAction("Get", new { id = courseCreateDTO.CourseID }, courseReadDTO);
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
