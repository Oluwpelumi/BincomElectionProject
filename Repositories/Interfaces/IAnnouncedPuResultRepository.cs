using BincomElectionProject.Models.Entities;

namespace BincomElectionProject.Repositories.Interfaces
{
    public interface IAnnouncedPuResultRepository
    {
        Task<IEnumerable<AnnouncedPuResult>> GetResultsByPollingUnitIdAsync(int pollingUnitId);
        Task AddAsync(AnnouncedPuResult result);
    }
}
