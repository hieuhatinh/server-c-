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
        private readonly StudentsDbContext _dbContext;
        public StudentService(StudentsDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Student CreateStudent(CreateStudentDto input)
        {
            var student = new Student
            {
                Id = ++_dbContext.Id,
                Name = input.Name,
                DateOfBirth = input.DateOfBirth,
                StudentCode = input.StudentCode,
            };

            _dbContext.Students.Add(student);

            return student;
        }

        public void DeleteStudent(int id)
        {
            var student = _dbContext.Students.FirstOrDefault(student => student.Id == id);
            if (student == null)
            {
                throw new UserException($"Không tìm thấy sinh viên có mã số {id}");
            }

            _dbContext.Students.Remove(student);
        }

        public List<Student> GetAllStudents()
        {
            return _dbContext.Students;
        }

        public Student GetByIdParams([FromQuery] int id)
        {
            var student = _dbContext.Students.FirstOrDefault(student => student.Id == id);
            if ( student == null )
            {
                throw new UserException($"Không tìm thấy sinh viên có mã số {id}");
            }

            return student;
        }

        public Student GetByIdPath(int id)
        {
            var student = _dbContext.Students.FirstOrDefault(student => student.Id == id);
            if (student == null)
            {
                throw new UserException($"Không tìm thấy sinh viên có mã số {id}");
            }

            return student;
        }

        public void UpdateStudent(int id, [FromBody] UpdateStudentDto input)
        {
            var existStudent = _dbContext.Students.FirstOrDefault( student => student.Id == id);  
            if (existStudent == null )
            {
                throw new UserException($"Không tìm thấy sinh viên có mã số {id}");
            } 
            else
            {
                existStudent.Name = input.Name;
                existStudent.DateOfBirth = input.DateOfBirth;
                existStudent.StudentCode = input.StudentCode;
            }
        }
    }
}
