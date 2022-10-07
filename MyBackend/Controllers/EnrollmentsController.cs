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
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollment _enrollment;
        private readonly IEnrollment _enrollmentDAL;
        private readonly IMapper _mapper;
        public EnrollmentsController(IEnrollment enrollment, IMapper mapper, IEnrollment enrollmentDAL)
        {
            _enrollment = enrollment;
            _mapper = mapper;
            _enrollmentDAL = enrollmentDAL;
        }
        private AppDbContext _dbcontext;

        /*[HttpPost]
        public IActionResult Enrollment(EnrollmentAddDTO enrollmentDto)
        {
            try
            {
                _enrollment.Enrollment(enrollmentDto.StudentId, enrollmentDto.CourseID);
                return Ok($"StudentID {enrollmentDto.StudentId} berhasil dittambahkan ke Course {enrollmentDto.CourseID}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        /*[HttpPost]
        public async Task<ActionResult> Post(EnrollmentAddDTO enrollmentAddDTO)
        {
            try
            {
                var newenroll = _mapper.Map<Enrollment>(enrollmentAddDTO);
                var result = await _enrollmentDAL.Insert(newenroll);
                var courseDTO = _mapper.Map<EnrollmentAddDTO>(result);
                return CreatedAtAction("Get", new { id = enrollmentAddDTO.EnrollmentId }, courseDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        [HttpPost("AddEnrollment")]
        public IActionResult AddEnrollment(EnrollmentAddDTO enrollmentAddDTO)
        {
            try
            {
                _enrollment.AddEnrollment(enrollmentAddDTO.EnrollmentId, enrollmentAddDTO.StudentId, enrollmentAddDTO.CourseID);
                return Ok($"Student Id {enrollmentAddDTO.StudentId} berhasil ditambahkan ke course {enrollmentAddDTO.CourseID}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
