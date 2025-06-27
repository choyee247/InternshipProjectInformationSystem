using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagementSystem.Models
{
    public class ProjectMember
    {
        [Key]
        public int ProjectMember_pkId { get; set; }

        [ForeignKey(nameof(Project))]
        public int Project_pkId { get; set; }

        [ForeignKey(nameof(Student))]
        public int Student_pkId { get; set; }

        public virtual Project Project { get; set; }
        public virtual Student Student { get; set; }
    }
}