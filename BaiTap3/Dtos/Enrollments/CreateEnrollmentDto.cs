using System.ComponentModel.DataAnnotations;

namespace BaiTap3.Dtos.Enrollment
{
    public class CreateEnrollmentDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "không được bỏ trống")
            ]
        public int IdSubjectClass { get; set; }

        [Required(ErrorMessage = "không được bỏ trống"), 
            MinLength(1, ErrorMessage = "Danh sách có ít nhất 1 sinh viên")]
        public List<int> IdStudents { get; set; }
    }
}
