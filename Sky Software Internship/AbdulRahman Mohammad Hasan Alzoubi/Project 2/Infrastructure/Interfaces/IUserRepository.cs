using Biding_management_System.Domain.Entities;
namespace Biding_management_System.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByUsernameAsync(string username);
        Task AddAsync (User user);
    }
}
