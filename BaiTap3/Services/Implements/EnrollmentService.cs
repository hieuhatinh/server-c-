using BaiTap3.DbContexts;
using BaiTap3.Dtos.Enrollment;
using BaiTap3.Entities;
using BaiTap3.Exceptions;
using BaiTap3.Services.Abstract;

namespace BaiTap3.Services.Implements
{
    public class EnrollmentService : IEnrollmentService
    {
        private EnrollmentDBContext _enrollmentDbContext;
        private StudentsDbContext _studentDbContext;

        public EnrollmentService(EnrollmentDBContext enrollmentDbContext, StudentsDbContext studentDbContext)
        {
            _enrollmentDbContext = enrollmentDbContext;
            _studentDbContext = studentDbContext;
        }

        public void CreateEnrollment(CreateEnrollmentDto input)
        {
            foreach (int idStudent in input.IdStudents)
            {
                Enrollment enrollment = new Enrollment
                {
                    Id = ++_enrollmentDbContext.Id, 
                    IdStudent = idStudent,
                    IdSubjectClass = input.IdSubjectClass
                };

                _enrollmentDbContext.Enrollments.Add(enrollment);
            }
        }

        public List<Enrollment> GetAllEnrollments()
        {
            return _enrollmentDbContext.Enrollments;
        }


        public List<Student> GetAllStudentsInClass(int idClass)
        {
            //var enrollments = _enrollmentDbContext.Enrollments.FindAll(item => item.IdSubjectClass == idClass);

            var studentsInClass = _enrollmentDbContext.Enrollments
                                    .Where(item => item.IdSubjectClass == idClass)
                                    .Join(_studentDbContext.Students, 
                                            enrollment => enrollment.IdStudent, 
                                            student => student.Id, 
                                            (studentsInClass, student) => student)
                                    .ToList();
            return studentsInClass;
        }
    }
}
