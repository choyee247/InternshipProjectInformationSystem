﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagementSystem.Models
{
    public class ProjectFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectFile_pkId { get; set; }

        [ForeignKey(nameof(Project))]
        public int Project_pkId { get; set; }
        public Project Project { get; set; }

        [Required(ErrorMessage = "File path is required")]
        [StringLength(500, ErrorMessage = "File path cannot exceed 500 characters")]
        public string FilePath { get; set; }

        [Required(ErrorMessage = "File type is required")]
        [StringLength(50, ErrorMessage = "File type cannot exceed 50 characters")]
        public string FileType { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "File size must be positive")]
        public long FileSize { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Uploader name is required")]
        [StringLength(100, ErrorMessage = "Uploader name cannot exceed 100 characters")]
        public string UploadedBy { get; set; }
    }
}