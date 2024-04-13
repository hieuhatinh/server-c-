using System.ComponentModel.DataAnnotations;

namespace BaiTap3.Dtos.SubjectClass
{
    public class UpdateSubjectClassDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không được bỏ trông tên lớp"),
            MaxLength(50, ErrorMessage = "Không quá 50 kí tự")]
        public string ClassName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "không được bỏ trống"),
            MinLength(5, ErrorMessage = "Tối thiểu 5 kí tự")]
        public string ClassCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "không được bỏ trống"), 
            Range(1, double.MaxValue, ErrorMessage = "Số lớn hơn 0")]
        public int NumberStudents { get; set; }
    }
}
