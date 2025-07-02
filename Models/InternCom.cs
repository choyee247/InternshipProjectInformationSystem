using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementSystem.Models
{
    public class InternCom
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required]
            [StringLength(100)]
            public string Name { get; set; } = string.Empty;

            [Required]
            [StringLength(100)]
            public string Industry { get; set; } = string.Empty;

            [StringLength(500)]
            public string Description { get; set; } = string.Empty;
            

        [Url]
            public string Website { get; set; } = string.Empty;

            [Url]
            public string Image { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;

            [StringLength(100)]
            public string City { get; set; } = string.Empty;
        [StringLength(500)]
        public string Country { get; set; }
        [EmailAddress]
            public string Email { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = "";

           

            public bool OffersInternships { get; set; }

            
        }
    }

