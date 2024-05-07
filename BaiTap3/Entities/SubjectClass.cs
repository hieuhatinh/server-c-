using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTap3.Entities
{
    [Table("SubjectClass")]
    public class SubjectClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ClassName { get; set; }

        [Required]
        [MaxLength(40)]
        public string ClassCode { get; set; }

        [Required]
        public int NumberStudents { get; set; }
    }
} 
