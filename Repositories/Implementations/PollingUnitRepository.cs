using BincomElectionProject.Models;
using BincomElectionProject.Models.Entities;
using BincomElectionProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BincomElectionProject.Repositories.Implementations
{
    public class PollingUnitRepository : IPollingUnitRepository
    {
        private readonly ElectionDbContext _context;
        public PollingUnitRepository(ElectionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PollingUnit>> GetPollingUnitsByLgaIdAsync(int lgaId)
        {
            return await _context.PollingUnits.Where(p => p.LgaId == lgaId).ToListAsync();
        }

        public async Task<PollingUnit> GetByIdAsync(int id)
        {
            return await _context.PollingUnits.FirstOrDefaultAsync(p => p.UniqueId == id);
        }
    }
}
