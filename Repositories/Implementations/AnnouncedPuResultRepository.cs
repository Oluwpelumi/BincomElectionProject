using BincomElectionProject.Models;
using BincomElectionProject.Models.Entities;
using BincomElectionProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BincomElectionProject.Repositories.Implementations
{
    public class AnnouncedPuResultRepository : IAnnouncedPuResultRepository
    {
        private readonly ElectionDbContext _context;

        public AnnouncedPuResultRepository(ElectionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AnnouncedPuResult>> GetResultsByPollingUnitIdAsync(int pollingUnitId)
        {
            return await _context.AnnouncedPuResults
                .Where(r => Convert.ToInt32(r.PollingUnitUniqueId) == pollingUnitId)
                .ToListAsync();
        }

        public async Task AddAsync(AnnouncedPuResult result)
        {
            await _context.AnnouncedPuResults.AddAsync(result);
            await _context.SaveChangesAsync();
        }
    }
}
