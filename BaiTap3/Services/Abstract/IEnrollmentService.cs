using BaiTap3.Dtos.Enrollment;
using BaiTap3.Entities;

namespace BaiTap3.Services.Abstract
{
    public interface IEnrollmentService
    {
        void CreateEnrollment(CreateEnrollmentDto input);

        List<Enrollment> GetAllEnrollments();

        List<Student> GetAllStudentsInClass(int idClass);

    }
}