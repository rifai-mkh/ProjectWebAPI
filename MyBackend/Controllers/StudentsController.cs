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
    public class StudentsController : ControllerBase
    {
        private readonly IStudent _student;
        private readonly IMapper _mapper;
        public StudentsController(IStudent student, IMapper mapper)
        {
            _student = student;
            _mapper = mapper;   
        }

        [HttpGet]
        public IEnumerable<StudentReadDTO> Get()
        {
            var results = _student.GetAll();
            var lstStudentReadDto = _mapper.Map<IEnumerable<StudentReadDTO>>(results);
            return lstStudentReadDto;
        }

        [HttpGet("{id}")]
        public StudentReadDTO Get(int id)
        {
            var result = _student.GetById(id);
            var studentReadDto = _mapper.Map<StudentReadDTO>(result);
            return studentReadDto;
        }

        /*[HttpGet("ByName")]
        public IEnumerable<StudentReadDTO> GetByName(string name)
        {
            var result = _student.GetByName(name);
            var listStudentReadDto = _mapper.Map<IEnumerable<StudentReadDTO>>(result);
            return listStudentReadDto;
        }*/

        [HttpPost]
        public IActionResult Post(StudentCreateDTO studentDto)
        {
            try
            {
                var student = _mapper.Map<Student>(studentDto);
                var newStudent = _student.Insert(student);
                var studentReadDto = _mapper.Map<StudentReadDTO>(newStudent);
                return CreatedAtAction("Get", new { id = studentReadDto.Id }, studentReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*[HttpPut]
        public IActionResult Put(Student student)
        {
            try
            {
                var editStudent = _student.Update(student);
                return Ok(editStudent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _student.Delete(id);
                return Ok($"Delete id {id} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}