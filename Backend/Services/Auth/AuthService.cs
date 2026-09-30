using Backend.Data;
using Backend.Models.DTOs;
using Backend.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly SetTrackerDbContext _context;

        public AuthService(SetTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request)
        {
            var normalizedEmail = (request.Email ?? string.Empty).Trim();

            // Check if user already exists
            bool exists = await _context.Users
                .AnyAsync(u => (u.Email ?? string.Empty).ToLower() == normalizedEmail.ToLower());

            if (exists)
                throw new InvalidOperationException("A user with this email already exists.");

            // Create new user
            var user = new User
            {
                Name = request.Name ?? string.Empty,
                Email = normalizedEmail,
                Role = "User"
            };

            // Hash password
            var hasher = new PasswordHasher<User>();
            user.PasswordHash = hasher.HashPassword(user, request.Password!);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                Id = user.Id,
                Name = user.Name ?? string.Empty,
                Email = user.Email,
                Token = GenerateToken(user)
            };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
        {
            var identifier = (request.Email ?? string.Empty).Trim();

            var user = await _context.Users
                .FirstOrDefaultAsync(u => (u.Email ?? string.Empty).ToLower() == identifier.ToLower());

            if (user == null)
                throw new UnauthorizedAccessException("Invalid username or password.");

            var hasher = new PasswordHasher<User>();

            if (user.PasswordHash == request.Password)
            {
                // Migrate the previously seeded plain-text password to a hash.
                user.PasswordHash = hasher.HashPassword(user, request.Password);
                await _context.SaveChangesAsync();
            }
            else
            {
                var result = hasher.VerifyHashedPassword(
                    user,
                    user.PasswordHash,
                    request.Password);

                if (result == PasswordVerificationResult.Failed)
                {
                    throw new UnauthorizedAccessException("Invalid email or password.");
                }
            }

            return new AuthResponseDto
            {
                Id = user.Id,
                Name = user.Name ?? string.Empty,
                Email = user.Email,
                Token = GenerateToken(user)
            };
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        private string GenerateToken(User user)
        {
            // TODO: Implement JWT token generation
            // For now, return a simple token placeholder
            return $"token_{user.Id}_{DateTime.UtcNow.Ticks}";
        }
    }
}
