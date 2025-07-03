using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectManagementSystem;
using ProjectManagementSystem.Models;
public class Email
{
    [Key]
    public int Email_PkId { get; set; }
    public string EmailAddress { get; set; }
    public string Class { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset CreatedDate { get; set; }

    [Required]
    public string RollNumber { get; set; }


}