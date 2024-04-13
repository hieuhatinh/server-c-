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
        private SubjectClassDbContext _subjectClassDbContext;
        private EnrollmentDBContext _enrollmentDBContext;

        public SubjectClassService(SubjectClassDbContext subjectClassDbContext, EnrollmentDBContext enrollmentDBContext)
        {
            _subjectClassDbContext = subjectClassDbContext;
            _enrollmentDBContext = enrollmentDBContext;
        }
        public SubjectClass CreateSubjectClass(CreateSubjectClassDto input)
        {
            var subjectClass = new SubjectClass
            {
                Id = ++_subjectClassDbContext.IdClass,
                ClassName = input.ClassName,
                ClassCode = input.ClassCode,
                NumberStudents = input.NumberStudents,
            };

            _subjectClassDbContext.SubjectClasses.Add(subjectClass);

            return subjectClass;
        }

        public void UpdateSubjectClass(int id, [FromBody] UpdateSubjectClassDto input)
        {
            var existSubjectClass = _subjectClassDbContext.SubjectClasses.FirstOrDefault(item => item.Id == id);

            if (existSubjectClass == null)
            {
                throw new SubjectClassException($"không tìm thấy lớp học có id {id}");
            }

            existSubjectClass.ClassName = input.ClassName;
            existSubjectClass.ClassCode = input.ClassCode;
            existSubjectClass.NumberStudents = input.NumberStudents;
        }

        public SubjectClass GetSubjectClass(int id)
        {
            var existSubjectClass = _subjectClassDbContext.SubjectClasses.FirstOrDefault(item => item.Id == id);

            if (existSubjectClass == null)
            {
                throw new SubjectClassException($"không tìm thấy lớp học có id {id}");
            }

            return existSubjectClass;
        }

        public List<SubjectClass> GetAllSubjectClasses()
        {
            return _subjectClassDbContext.SubjectClasses;
        }

        public void DeleteSubjectClass(int idClass)
        {
            var exisSubjectClass = _subjectClassDbContext.SubjectClasses.FirstOrDefault(item => item.Id == idClass);

            if (exisSubjectClass == null) 
            {
                throw new SubjectClassException("Không có lớp học này");
            }

            var enrollments = _enrollmentDBContext.Enrollments.FindAll(item => item.IdSubjectClass == exisSubjectClass.Id);
            foreach ( var enrollment in enrollments )
            {
                _enrollmentDBContext.Enrollments.Remove(enrollment);
            }

            _subjectClassDbContext.SubjectClasses.Remove(exisSubjectClass);

        }
    }
}
