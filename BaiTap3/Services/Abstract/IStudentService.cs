using BaiTap3.Dtos.Students;
using BaiTap3.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap3.Services.Abstract
{
    public interface IStudentService
    {
        Student CreateStudent(CreateStudentDto input);

        Student GetByIdPath(int id);

        Student GetByIdParams([FromQuery] int id);

        void UpdateStudent(int id, [FromBody] UpdateStudentDto input);

        List<Student> GetAllStudents();

        void DeleteStudent(int id);

    }
}
