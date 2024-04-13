using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BaiTap3.Dtos.Students
{
    public class UpdateStudentDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên sinh viên không được bỏ trống"),
         MaxLength(50, ErrorMessage = "Tên sinh viên không được quá 50 kí tự")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Mã sinh viên không được bỏ trống")]
        public string StudentCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ngày sinh không được bỏ trống"),
         DataType(DataType.Date, ErrorMessage = "Chỉ nhập ngày sinh")]
        public DateTime DateOfBirth { get; set; }
    }
}
