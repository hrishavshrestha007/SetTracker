using Backend.Models.DTOs;
using Backend.Models.Entities;

namespace Backend.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request);
        Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
        Task<User?> GetByEmailAsync(string email);
    }
}
