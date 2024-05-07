using BaiTap3.DbContexts;
using BaiTap3.Dtos.Students;
using BaiTap3.Entities;
using BaiTap3.Exceptions;
using BaiTap3.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap3.Services.Implements
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public StudentService(ApplicationDbContext applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
        }

        public Student CreateStudent(CreateStudentDto input)
        {
            var student = new Student
            {
                Name = input.Name,
                DateOfBirth = input.DateOfBirth,
                StudentCode = input.StudentCode,
            };

            _applicationDbContext.Students.Add(student);
            _applicationDbContext.SaveChanges();

            return student;
        }

        public void DeleteStudent(int id)
        {
            var student = _applicationDbContext.Students.FirstOrDefault(student => student.Id == id);
            if (student == null)
            {
                throw new UserException($"Không tìm thấy sinh viên có mã số {id}");
            }

            _applicationDbContext.Students.Remove(student);
            _applicationDbContext.SaveChanges();
        }

        public List<Student> GetAllStudents()
        {
            return _applicationDbContext.Students.ToList();
        }

        public Student GetByIdParams([FromQuery] int id)
        {
            var student = _applicationDbContext.Students.FirstOrDefault(student => student.Id == id);
            if ( student == null )
            {
                throw new UserException($"Không tìm thấy sinh viên có mã số {id}");
            }

            return student;
        }

        public Student GetByIdPath(int id)
        {
            var student = _applicationDbContext.Students.FirstOrDefault(student => student.Id == id);
            if (student == null)
            {
                throw new UserException($"Không tìm thấy sinh viên có mã số {id}");
            }

            return student;
        }

        public void UpdateStudent(int id, [FromBody] UpdateStudentDto input)
        {
            var existStudent = _applicationDbContext.Students.FirstOrDefault( student => student.Id == id);  

            if (existStudent == null )
            {
                throw new UserException($"Không tìm thấy sinh viên có mã số {id}");
            } 
            
            existStudent.Name = input.Name;
            existStudent.DateOfBirth = input.DateOfBirth;
            existStudent.StudentCode = input.StudentCode;

            _applicationDbContext.SaveChanges();

        }
    }
}
