using TaskManagementAPI.Data;
using TaskManagementAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Models;
namespace TaskManagementAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserResponseDTO> RegisterAsync(RegisterDTO registerDTO)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == registerDTO.Username ||
            u.Email == registerDTO.Email);
            
            if (existingUser != null)
            {
                throw new InvalidOperationException("User with the same email or username already exists.");
            }
            //hash the password using BCrypt
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDTO.Password);
            //create a new user entity  
            var user = new User
            {
                Username = registerDTO.Username,
                Email = registerDTO.Email,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.UtcNow
            };

            //add the user to the database
            _context.Users.Add(user);  //in memory insertion
            await _context.SaveChangesAsync(); //save changes to the database

            //return the user response DTO
            return new UserResponseDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                CreateAt = user.CreatedAt
            };

        }
    }
}
