using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskStatus = TaskManagementApp.Models.Enums.TaskStatus;

namespace TaskManagementApp.Models
{
    public class TaskItem
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        [Required]
        public TaskStatus Status { get; set; }

        [MaxLength(500)]
        public string Remarks { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        // Foreign Keys
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        // Navigation Properties
        [ForeignKey(nameof(CreatedBy))]
        public User CreatedByUser { get; set; }

        [ForeignKey(nameof(UpdatedBy))]
        public User UpdatedByUser { get; set; }
    }
}
