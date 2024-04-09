using BaiTap3.Dtos.Students;
using BaiTap3.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController: ControllerBase
    {
        private IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("create")]
        public IActionResult Create(CreateStudentDto input)
        {
            return Ok(_studentService.CreateStudent(input));
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdPath(int id)
        {
            try
            {
                var student = _studentService.GetByIdPath(id);

                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        public IActionResult GetByIdParams([FromQuery] int id)
        {
            try
            {
                var student = _studentService.GetByIdParams(id);

                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("update/{id}")]
        public IActionResult Update(int id, [FromBody] UpdateStudentDto input)
        {
            try
            {
                _studentService.UpdateStudent(id, input);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all")]
        public IActionResult GetAllStudents()
        {
            return Ok(_studentService.GetAllStudents());
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _studentService.DeleteStudent(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
