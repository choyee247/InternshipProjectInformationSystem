using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagementSystem.Models
{
    public class Language
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Language_pkId { get; set; }

        [Required]
        public string LanguageName { get; set; } = "";// e.g., C#, Java

        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Framework>? Frameworks{ get; set; }
    }
}
