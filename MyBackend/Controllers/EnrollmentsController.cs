﻿using AutoMapper;
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

        [HttpGet]
        public async Task<IEnumerable<EnrollmentDTO>> Get()
        {

            var results = await _enrollmentDAL.GetAll();
            var DTO = _mapper.Map<IEnumerable<EnrollmentDTO>>(results);

            return DTO;
        }

        [HttpGet("{id}")]
        public async Task<EnrollmentStudentCourseDTO> GetById(int id)
        {

            var result = await _enrollmentDAL.GetById(id);
            if (result == null) throw new Exception($"data {id} tidak ditemukan");
            var DTO = _mapper.Map<EnrollmentStudentCourseDTO>(result);

            return DTO;
        }

        [HttpGet("WithStudentAndCourse")]
        public async Task<IEnumerable<EnrollmentStudentCourseDTO>> GetEnrollmentStudentCourses()
        {
            var results = await _enrollmentDAL.GetEnrollmentStudentCourses();
            var DTO = _mapper.Map<IEnumerable<EnrollmentStudentCourseDTO>>(results);
            return DTO;
        }

       

        [HttpGet("Pagging")]
        public async Task<IEnumerable<EnrollmentStudentCourseDTO>> Pagging(int skip, int take)
        {

            var results = await _enrollmentDAL.Pagging(skip, take);
            var DTO = _mapper.Map<IEnumerable<EnrollmentStudentCourseDTO>>(results);

            return DTO;
        }


        [HttpPost("InsertEnrollment")]

        public async Task<ActionResult> Post(EnrollmentCreateDTO CreateDto, int studenID, int courseID)
        {
            try
            {
                var newcourse = _mapper.Map<Enrollment>(CreateDto);
                var result = await _enrollmentDAL.InsertEnrollment(newcourse, studenID, courseID);
                var Dto = _mapper.Map<EnrollmentDTO>(result);



                //return CreatedAtAction(nameof(GetById), new { id = result.CourseID + 1 }, Dto);
                return CreatedAtAction("Get", new { id = result.EnrollmentId }, Dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(EnrollmentDTO enrollment)
        {
            try
            {
                var newElement = _mapper.Map<Enrollment>(enrollment);
                var result = await _enrollmentDAL.Insert(newElement);
                var Dto = _mapper.Map<EnrollmentDTO>(result);

                return CreatedAtAction("Get", new { id = result.EnrollmentId }, Dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(EnrollmentEditDTO enrollmentDto)
        {
            try
            {
                var update = _mapper.Map<Enrollment>(enrollmentDto);
                var result = await _enrollmentDAL.Update(update);
                var DTO = _mapper.Map<EnrollmentDTO>(result);
                return Ok(enrollmentDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _enrollmentDAL.Delete(id);
                return Ok($"Data dengan id {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
