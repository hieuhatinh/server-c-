using Microsoft.AspNetCore.Mvc;

namespace BaiTap3.Dtos.Students
{
    public class CreateStudentDto
    {
        public string Name { get; set; }
        public string StudentCode { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
