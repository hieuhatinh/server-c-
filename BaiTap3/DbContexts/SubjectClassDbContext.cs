using BaiTap3.Entities;

namespace BaiTap3.DbContexts
{
    public class SubjectClassDbContext
    {
        public List<SubjectClass> SubjectClasses { get; set; } = new List<SubjectClass>();

        public int IdClass { get; set; } = 0;
        public SubjectClassDbContext() { }
    }
}
