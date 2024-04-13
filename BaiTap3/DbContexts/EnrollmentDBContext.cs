using BaiTap3.Entities;

namespace BaiTap3.DbContexts
{
    public class EnrollmentDBContext
    {
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        public int Id { get; set; } = 0;

        public EnrollmentDBContext() { }
    }
}
