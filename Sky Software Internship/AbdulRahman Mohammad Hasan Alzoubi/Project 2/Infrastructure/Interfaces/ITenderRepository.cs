using Biding_management_System.Domain.Entities.Tender;

namespace Biding_management_System.Infrastructure.Interfaces
{
    public interface ITenderRepository
    {
        Task<List<Tender>> GetAllAsync();
        Task<Tender?> GetByIdAsync(int id);
        Task AddAsync(Tender tender);
        Task UpdateAsync(Tender tender);
        Task DeleteAsync(Tender tender);
    }
}
