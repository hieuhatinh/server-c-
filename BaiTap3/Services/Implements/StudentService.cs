using BaiTap3.Dtos.Students;
using BaiTap3.Entities;
using BaiTap3.Exceptions;
using BaiTap3.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap3.Services.Implements
{
    public class StudentService : IStudentService
    {
        private static List<Student> _students = new List<Student>();
        private static int _id = 0;
        public Student CreateStudent(CreateStudentDto input)
        {
            var student = new Student
            {
                Id = ++_id,
                Name = input.Name,
                DateOfBirth = input.DateOfBirth,
                StudentCode = input.StudentCode,
            };

            _students.Add(student);

            return student;
        }

        public void DeleteStudent(int id)
        {
            var student = _students.FirstOrDefault(student => student.Id == id);
            if (student == null)
            {
                throw new UserException($"Không tìm thấy sinh viên có mã số {id}");
            }

            _students.Remove(student);
        }

        public List<Student> GetAllStudents()
        {
            return _students;
        }

        public Student GetByIdParams([FromQuery] int id)
        {
            var student = _students.FirstOrDefault(student => student.Id == id);
            if ( student == null )
            {
                throw new UserException($"Không tìm thấy sinh viên có mã số {id}");
            }

            return student;
        }

        public Student GetByIdPath(int id)
        {
            var student = _students.FirstOrDefault(student => student.Id == id);
            if (student == null)
            {
                throw new UserException($"Không tìm thấy sinh viên có mã số {id}");
            }

            return student;
        }

        public void UpdateStudent(int id, [FromBody] UpdateStudentDto input)
        {
            var existStudent = _students.FirstOrDefault( student => student.Id == id);  
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
