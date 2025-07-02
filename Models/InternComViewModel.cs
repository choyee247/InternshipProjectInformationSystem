using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

public class InternComViewModel
{
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

    public IFormFile? ImageFile { get; set; }

    public string? ExistingImage { get; set; }

    [Required]
    public string Address { get; set; } = string.Empty;

    [StringLength(100)]
    public string City { get; set; } = string.Empty;

    [StringLength(500)]
    public string Country { get; set; } = string.Empty;

    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string PhoneNumber { get; set; } = "";

    public bool OffersInternships { get; set; }
}
