using Biding_management_System.Application.DTOs.Tender;
using Biding_management_System.Domain.Entities;
using Biding_management_System.Domain.Entities.Tender;
using Mapster;
using Biding_management_System.Application.Interfaces;
using Biding_management_System.Infrastructure.Interfaces;


namespace Biding_management_System.Application.Services
{
    public class TenderService : ITenderService
    {
        private readonly ITenderRepository _tenderRepository;

        public TenderService(ITenderRepository tenderRepository)
        {
            _tenderRepository = tenderRepository;
        }

        public async Task<List<TenderDTO>> GetAllTendersAsync()
        {
            var tenders = await _tenderRepository.GetAllAsync();
            return tenders.Adapt<List<TenderDTO>>();
        }

        public async Task<TenderDTO?> GetTenderByIdAsync(int id)
        {
            var tender = await _tenderRepository.GetByIdAsync(id);
            return tender?.Adapt<TenderDTO>();
        }

        public async Task AddTenderAsync(CreateTenderDTO dto)
        {
            var tender = dto.Adapt<Tender>();
            await _tenderRepository.AddAsync(tender);
        }

        public async Task<bool> UpdateTenderAsync(int id, UpdateTenderDTO dto)
        {
            var tender = await _tenderRepository.GetByIdAsync(id);
            if (tender == null) return false;

            tender = dto.Adapt(tender);
            await _tenderRepository.UpdateAsync(tender);
            return true;
        }

        public async Task<bool> DeleteTenderAsync(int id)
        {
            var tender = await _tenderRepository.GetByIdAsync(id);
            if (tender == null) return false;

            await _tenderRepository.DeleteAsync(tender);
            return true;
        }
    }
}
