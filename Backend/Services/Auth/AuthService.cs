using Backend.Data;
using Backend.Models.DTOs;
using Backend.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly SetTrackerDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(SetTrackerDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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
            var key = _configuration["Jwt:Key"]
                ?? throw new InvalidOperationException("Jwt:Key is not configured.");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name ?? string.Empty),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role ?? "User")
            };

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
