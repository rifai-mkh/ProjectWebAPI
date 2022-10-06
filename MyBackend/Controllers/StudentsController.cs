using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBackend.DAL;
using MyBackend.DTO;
using MyBackend.Models;
using System;
using System.Globalization;
using System.Threading;

namespace MyBackend.Controllers
{
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

            //List<StudentGetDTO> listStudentGetDto = new List<StudentGetDTO>();
            //var results = _student.GetByfirstMidName(firstmidname);
            //foreach (var r in results)
            //{
            //    listStudentGetDto.Add(new StudentGetDTO
            //    {
            //        Id = r.ID,
            //        LastName = r.LastName,
            //        FirstMidName = r.FirstMidName
            //    });
            //}
            //return listStudentGetDto;
        }

        [HttpGet("ByLastName")]
        public IEnumerable<StudentReadDTO> GetByLastName(string lastname)
        {
            var results = _students.GetByLastName(lastname);
            var listStudentGetDto = _mapper.Map<IEnumerable<StudentReadDTO>>(results);
            return listStudentGetDto;

            //List<StudentGetDTO> listStudentGetDto = new List<StudentGetDTO>();
            //var results = _student.GetByLastName(lastname);
            //foreach (var r in results)
            //{
            //    listStudentGetDto.Add(new StudentGetDTO
            //    {
            //        Id = r.ID,
            //        LastName = r.LastName,
            //        FirstMidName = r.FirstMidName
            //    });
            //}
            //return listStudentGetDto;
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

                //var student = new Student
                //{
                //    ID= id,
                //    LastName = studentDto.LastName,
                //    FirstMidName = studentDto.FirstMidName
                //};

                //var editStudent = _student.Update(student);

                //StudentGetDTO studentGetDto = new StudentGetDTO
                //{
                //    Id = student.ID,
                //    LastName = studentDto.LastName,
                //    FirstMidName = studentDto.FirstMidName
                //};

                //return Ok(studentGetDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /*[HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            try
            {
                var editStudent = _mapper.Map<Student>(quoteAddDto);
                _quotes.Update(editQuote);
                var quoteGetDto = _mapper.Map<QuoteGetDTO>(editQuote);
                return Ok(quoteGetDto);
                var editStudent = _student.Update(student);
                return Ok(editStudent);*/
        /*}
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
                _students.Delete(id);
                return Ok($"Delete id {id} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}