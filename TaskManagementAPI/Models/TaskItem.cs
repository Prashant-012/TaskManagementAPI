using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public bool IsCompleted { get; set; } = false;
        public int Priority { get; set; } = 0; // 0: Low, 1: Medium, 2: High
        public DateTime? DueDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //foreign key to User
        public int UserId { get; set; }

        // Navigation property
        public User User { get; set; }
    }
}
