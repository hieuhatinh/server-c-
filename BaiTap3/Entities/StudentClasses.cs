using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTap3.Entities
{
    [Table("StudentClasses")]
    public class StudentClasses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public int IdStudent { get; set; }

        public int IdSubjectClass { get; set; }
    }
}
