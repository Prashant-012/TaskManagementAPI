using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Services;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService; 
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] DTOs.RegisterDTO registerDTO)
        {

            try
            {
                var user = await _authService.RegisterAsync(registerDTO);
                return CreatedAtAction(nameof(Register), new { id = user.Id }, user);
            }

            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

            catch (Exception ex)
            {
                return StatusCode(500,new { message = "An unexpected error occurred during user registration.", detail = ex.Message });
            }
        }
    }
}
