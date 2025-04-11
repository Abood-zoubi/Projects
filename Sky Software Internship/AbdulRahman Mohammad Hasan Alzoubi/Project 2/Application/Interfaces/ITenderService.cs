using Biding_management_System.Application.DTOs.Tender;
namespace Biding_management_System.Application.Interfaces
{
    public interface ITenderService
    {
        Task<List<TenderDTO>> GetAllTendersAsync();
        Task<TenderDTO?> GetTenderByIdAsync(int id);
        Task AddTenderAsync(CreateTenderDTO dto);
        Task<bool> UpdateTenderAsync(int id, UpdateTenderDTO dto);
        Task<bool> DeleteTenderAsync(int id);
    }
}
