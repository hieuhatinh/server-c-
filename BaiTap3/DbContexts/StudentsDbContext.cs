using BaiTap3.Entities;

namespace BaiTap3.DbContexts
{
    public class StudentsDbContext
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public int Id { get; set; } = 0;

        public StudentsDbContext() { }
    }
}
