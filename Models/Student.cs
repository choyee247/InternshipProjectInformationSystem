using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementSystem.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Student_pkId { get; set; }
        public string StudentName { get; set; } = "";
        public string RollNumber { get; set; } = "";
        public string AcademicYear { get; set; } = "";

        [ForeignKey(nameof(StudentDepartment))]
        public int Department_pkID { get; set; }  // Foreign Key to StudentDepartment

        public virtual StudentDepartment? StudentDepartment { get; set; }
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";

        // NRC dropdown parts
       
        
        [ForeignKey(nameof(NRCType))]
        public int NRCType_pkId { get; set; }

        [ForeignKey(nameof(NRCTownship))]
        public int NRC_pkId { get; set; }
        public int NRCNumber { get; set; } 

        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "";
        
        public virtual NRCTownship? NRCTownship { get; set; }
        public virtual NRCType? NRCType { get; set; }
    }
}
