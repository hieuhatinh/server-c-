using BaiTap3.DbContexts;
using BaiTap3.Dtos.SubjectClass;
using BaiTap3.Entities;
using BaiTap3.Exceptions;
using BaiTap3.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap3.Services.Implements
{
    public class SubjectClassService : ISubjectClassService
    {
        private ApplicationDbContext _applicationDbContext;

        public SubjectClassService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public SubjectClass CreateSubjectClass(CreateSubjectClassDto input)
        {
            var subjectClass = new SubjectClass
            {
                ClassName = input.ClassName,
                ClassCode = input.ClassCode,
                NumberStudents = input.NumberStudents,
            };

            _applicationDbContext.SubjectClasses.Add(subjectClass);
            _applicationDbContext.SaveChanges();

            return subjectClass;
        }

        public void UpdateSubjectClass(int id, [FromBody] UpdateSubjectClassDto input)
        {
            var existSubjectClass = _applicationDbContext.SubjectClasses.FirstOrDefault(item => item.Id == id);

            if (existSubjectClass == null)
            {
                throw new SubjectClassException($"không tìm thấy lớp học có id {id}");
            }

            existSubjectClass.ClassName = input.ClassName;
            existSubjectClass.ClassCode = input.ClassCode;
            existSubjectClass.NumberStudents = input.NumberStudents;

            _applicationDbContext.SaveChanges();
        }

        public SubjectClass GetSubjectClass(int id)
        {
            var existSubjectClass = _applicationDbContext.SubjectClasses.FirstOrDefault(item => item.Id == id);

            if (existSubjectClass == null)
            {
                throw new SubjectClassException($"không tìm thấy lớp học có id {id}");
            }

            return existSubjectClass;
        }

        public List<SubjectClass> GetAllSubjectClasses()
        {
            return _applicationDbContext.SubjectClasses.OrderBy(s => s.ClassName).ToList();
        }

        public void DeleteSubjectClass(int idClass)
        {
            var exisSubjectClass = _applicationDbContext.SubjectClasses.FirstOrDefault(item => item.Id == idClass);

            if (exisSubjectClass == null) 
            {
                throw new SubjectClassException("Không có lớp học này");
            }

            var studentsInClass = from student in _applicationDbContext.StudentClasses
                                  where student.IdSubjectClass == exisSubjectClass.Id
                                  select student;
            foreach ( var student in studentsInClass )
            {
                _applicationDbContext.StudentClasses.Remove(student);
            }

            _applicationDbContext.SubjectClasses.Remove(exisSubjectClass);

            _applicationDbContext.SaveChanges();
        }
    }
}
