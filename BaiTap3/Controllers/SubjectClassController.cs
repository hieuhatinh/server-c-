using BaiTap3.Dtos.SubjectClass;
using BaiTap3.Entities;
using BaiTap3.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectClassController : ControllerBase
    {
        private ISubjectClassService _subjectClassService;

        public SubjectClassController(ISubjectClassService subjectClassService)
        {
            _subjectClassService = subjectClassService;
        }

        [HttpPost("create")]
        public IActionResult CreateSubjectClass(CreateSubjectClassDto input)
        {
            return Ok(_subjectClassService.CreateSubjectClass(input));
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateSubjectClass (int id, [FromBody] UpdateSubjectClassDto input)
        {
            try
            {
                _subjectClassService.UpdateSubjectClass(id, input);

                return Ok();
            } 
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSubjectClass(int id)
        {
            try
            {
                return Ok(_subjectClassService.GetSubjectClass(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-classes")]
        public IActionResult GetAllSubjectClasses()
        {
            return Ok(_subjectClassService.GetAllSubjectClasses());
        }

        [HttpDelete("delete-class/{idClass}")]
        public IActionResult DeleteSubjectClass(int idClass)
        {
            _subjectClassService.DeleteSubjectClass(idClass);
            return Ok();
        }
    }
}
