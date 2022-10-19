using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBackend.DAL;
using MyBackend.DTO;
using MyBackend.Models;


namespace MyBackend.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudent _students;
        private readonly IMapper _mapper;
        public StudentsController(IStudent students, IMapper mapper)
        {
            _students = students;
            _mapper = mapper;   
        }

        [HttpGet]
        public IEnumerable<StudentReadDTO> Get()
        {
            var EnrollmentDate = DateTime.Today;
            string strToday = EnrollmentDate.ToString();
            var results = _students.GetAll();
            var lstStudentReadDto = _mapper.Map<IEnumerable<StudentReadDTO>>(results);
            return lstStudentReadDto;
        }


        [HttpGet("{id}")]
        public StudentReadDTO Get(int id)
        {
            var result = _students.GetById(id);
            var studentReadDto = _mapper.Map<StudentReadDTO>(result);
            return studentReadDto;
        }


        [HttpGet("ByFirstMidName")]
        public IEnumerable<StudentReadDTO> GetByfirstMidName(string firstmidname)
        {
            var results = _students.GetByfirstMidName(firstmidname);
            var listStudentReadDto = _mapper.Map<IEnumerable<StudentReadDTO>>(results);
            return listStudentReadDto;
        }


        [HttpGet("ByLastName")]
        public IEnumerable<StudentReadDTO> GetByLastName(string lastname)
        {
            var results = _students.GetByLastName(lastname);
            var listStudentGetDto = _mapper.Map<IEnumerable<StudentReadDTO>>(results);
            return listStudentGetDto;            
        }


        [HttpPost]
        public IActionResult Post(StudentCreateDTO studentDto)
        {
            var EnrollmentDate = DateTime.Today;
            string strToday = EnrollmentDate.ToString(); // converts date to string as per current culture
            
            try
            {
                var student = _mapper.Map<Student>(studentDto);
                var newStudent = _students.Insert(student);
                var studentReadDto = _mapper.Map<StudentReadDTO>(newStudent);
                return CreatedAtAction("Get", new { id = studentReadDto.Id }, studentReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public IActionResult Put(StudentCreateDTO studentDto)
        {
            try
            {
                var student = _mapper.Map<Student>(studentDto);
                var editStudent = _students.Update(student);
                var studentGetDto = _mapper.Map<StudentReadDTO>(editStudent);
                return Ok(studentGetDto);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _students.Delete(id);
                return Ok($"Delete id {id} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Pagging/{skip}/{take}")]
        public async Task<IEnumerable<StudentDTO>> Pagging(int skip, int take)
        {

            var results = await _students.Pagging(skip, take);
            var DTO = _mapper.Map<IEnumerable<StudentDTO>>(results);

            return DTO;
        }

    }
}