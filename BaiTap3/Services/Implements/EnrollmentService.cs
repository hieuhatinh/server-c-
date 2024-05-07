using BaiTap3.DbContexts;
using BaiTap3.Dtos.Enrollment;
using BaiTap3.Entities;
using BaiTap3.Exceptions;
using BaiTap3.Services.Abstract;

namespace BaiTap3.Services.Implements
{
    public class EnrollmentService : IEnrollmentService
    {
        private ApplicationDbContext _applicationDbContext;

        public EnrollmentService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void CreateEnrollment(CreateEnrollmentDto input)
        {
            foreach (int idStudent in input.IdStudents)
            {
                StudentClasses enrollment = new StudentClasses
                {
                    IdStudent = idStudent,
                    IdSubjectClass = input.IdSubjectClass
                };

                _applicationDbContext.StudentClasses.Add(enrollment);
            }
        }

        public List<StudentClasses> GetAllEnrollments()
        {
            return _applicationDbContext.StudentClasses.ToList();
        }

        public List<Student> GetAllStudentsInClass(int idClass)
        {
            var studentsInClass = _applicationDbContext.StudentClasses
                                    .Where(item => item.IdSubjectClass == idClass)
                                    .Join(_applicationDbContext.Students, 
                                            enrollment => enrollment.IdSubjectClass, 
                                            student => student.Id, 
                                            (studentsInClass, student) => student)
                                    .ToList();
            return studentsInClass;
        }
    }
}
