using BaiTap3.Dtos.Enrollment;
using BaiTap3.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpPost("create")]
        public IActionResult CreateEnrollment([FromBody] CreateEnrollmentDto input)
        {
            _enrollmentService.CreateEnrollment(input);

            return Ok();
        }

        [HttpGet("get-all-enrollments")]
        public IActionResult GetAllEnrollments()
        {
            return Ok(_enrollmentService.GetAllEnrollments());
        }

        [HttpGet("students-in-class/{idClass}")]
        public IActionResult GetAllStudentsInClass(int idClass)
        {
            return Ok(_enrollmentService.GetAllStudentsInClass(idClass));
        }
    }
}
