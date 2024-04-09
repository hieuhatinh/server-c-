using Microsoft.AspNetCore.Mvc;

namespace BaiTap3.Dtos.Students
{
    public class UpdateStudentDto
    {
        public string Name { get; set; }
        public string StudentCode { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
