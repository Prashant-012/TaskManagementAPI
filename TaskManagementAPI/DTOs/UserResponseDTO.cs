namespace TaskManagementAPI.DTOs
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }= String.Empty;
        public string Email { get; set; }= String.Empty;
        public DateTime CreateAt { get; set; }
    }
}
