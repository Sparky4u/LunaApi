using LunaApi.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LunaApi.Common.Models
{
    public class TaskEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; } 
        public string Description { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }
        [Required]
        public Status Status { get; set; } = Status.Pending;
        [Required]
        public Priority Priority { get; set; } = Priority.Medium;
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
