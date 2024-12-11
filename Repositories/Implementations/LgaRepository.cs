using BincomElectionProject.Models;
using BincomElectionProject.Models.Entities;
using BincomElectionProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BincomElectionProject.Repositories.Implementations
{
    public class LgaRepository : ILgaRepository
    {
        private readonly ElectionDbContext _context;
        public LgaRepository(ElectionDbContext context)
        {
            _context = context;
        }
        //public async Task<Lga> GetByIdAsync(int id)
        //{
        //    return await _context.Lgas
        // .Where(l => l.DateEntered != null && l.DateEntered != DateTime.MinValue && l.DateEntered != new DateTime(1, 1, 1))  // Use the valid minimum date (1/1/0001)
        // .FirstOrDefaultAsync(p => p.UniqueId == id);
        //    //return await _context.Lgas.Where(l => l.DateEntered != null && l.DateEntered != DateTime.MinValue && l.DateEntered != new DateTime(0000, 01, 01)).FirstOrDefaultAsync(p => p.UniqueId == id);
        //}

        public async Task<Lga> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Lgas
                    .FirstOrDefaultAsync(p => p.UniqueId == id && (p.DateEntered == null || p.DateEntered >= DateTime.MinValue));
            }
            catch (Exception ex)
            {
                // Handle or log the error as necessary
                throw new InvalidOperationException("An error occurred while fetching the LGA record.", ex);
            }
        }
    

    }
}
