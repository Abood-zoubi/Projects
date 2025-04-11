using System.Security.Cryptography;
using System.Text;
using Biding_management_System.Domain.Entities;
using Biding_management_System.Application.Services;
using Biding_management_System.Application.DTOs.Authentication;
using Biding_management_System.Infrastructure.Repositories;

namespace Biding_management_System.Application.Services
{
    public class AuthenticationService
    {
        private readonly UserRepository _userRepository;

        public AuthenticationService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> RegisterUserAsync(RegisterDTO dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingUser != null) return "Email already exists.";

            var newUser = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = HashPassword(dto.Password),
                Role = dto.Role
            };

            await _userRepository.AddAsync(newUser);
            return "User registered successfully.";
        }

        public async Task<string?> LoginAsync(LoginDTO dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null || !VerifyPassword(dto.Password, user.Password)) 
                return null;

            return JwtTokenService.GenerateToken(user);
        }

        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
        private static bool VerifyPassword(string inputPassword, string storedHash)
        {
            return HashPassword(inputPassword) == storedHash;
        }
    }
}
