using TaskManagementAPI.DTOs;

namespace TaskManagementAPI.Services
{
    public interface IAuthService
    {
        Task<UserResponseDTO> RegisterAsync(RegisterDTO registerDTO);
    }
}
