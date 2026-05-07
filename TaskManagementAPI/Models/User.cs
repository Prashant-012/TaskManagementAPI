namespace TaskManagementAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }= String.Empty;
        public string Email { get; set; } = String.Empty;
        public string PasswordHash { get; set; }  = String.Empty;
        public DateTime CreatedAt { get; set; }= DateTime.UtcNow;

        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();    

    }
}
