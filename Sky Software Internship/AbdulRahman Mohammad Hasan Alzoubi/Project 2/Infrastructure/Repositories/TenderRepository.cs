using Biding_management_System.Application.DTOs.Tender;
using Biding_management_System.Domain.Entities.Tender;
using Biding_management_System.Infrastructure.Data;
using Biding_management_System.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Biding_management_System.Infrastructure.Repositories
{
    public class TenderRepository : ITenderRepository
    {
        private readonly AppDbContext _context;

        public TenderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Tender>> GetAllAsync()
        {
            return await _context.Tenders.ToListAsync();
        }

        public async Task AddAsync(Tender tender)
        {
            _context.Tenders.Add(tender);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tender tender)
        {
            _context.Tenders.Update(tender);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Tender Tender)
        {
            var tender = await _context.Tenders.FindAsync(Tender);
            if (tender != null)
            {
                _context.Tenders.Remove(tender);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Tender?> GetByIdAsync(int id)
        {
            return await _context.Tenders.FindAsync(id);
        }


    }
}
