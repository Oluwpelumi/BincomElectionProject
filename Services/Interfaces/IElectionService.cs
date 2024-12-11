using BincomElectionProject.DTOs;

namespace BincomElectionProject.Services.Interfaces
{
    public interface IElectionService
    {
        Task<IEnumerable<PollingUnitResultDto>> GetPollingUnitResultsAsync(int pollingUnitId);
        Task<LgaResultDto> GetTotalResultsByLgaIdAsync(int lgaId);
        Task AddPollingUnitResultAsync(AddResultDto addResultDto);
    }
}
