using BincomElectionProject.Models.Entities;

namespace BincomElectionProject.Repositories.Interfaces
{
    public interface IPollingUnitRepository
    {
       Task<IEnumerable<PollingUnit>> GetPollingUnitsByLgaIdAsync(int lgaId);
       Task<PollingUnit> GetByIdAsync(int id);

    }
}
