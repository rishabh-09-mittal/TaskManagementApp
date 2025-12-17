using System.ComponentModel.DataAnnotations;

namespace TaskManagementApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }

        // Navigation Properties
        public ICollection<TaskItem> CreatedTasks { get; set; }
        public ICollection<TaskItem> UpdatedTasks { get; set; }
    }
}
