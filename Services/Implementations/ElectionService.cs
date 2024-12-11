using BincomElectionProject.DTOs;
using BincomElectionProject.Models.Entities;
using BincomElectionProject.Repositories.Interfaces;
using BincomElectionProject.Services.Interfaces;

namespace BincomElectionProject.Services.Implementations
{
    public class ElectionService : IElectionService
    {
        private readonly IPollingUnitRepository _pollingUnitRepository;
        private readonly IAnnouncedPuResultRepository _announcedPuResultRepository;
        private readonly ILgaRepository _lgaRepository;

        public ElectionService(IPollingUnitRepository pollingUnitRepository, IAnnouncedPuResultRepository announcedPuResultRepository, ILgaRepository lgaRepository)
        {
            _pollingUnitRepository = pollingUnitRepository;
            _announcedPuResultRepository = announcedPuResultRepository;
            _lgaRepository = lgaRepository; 
        }


        public async Task<IEnumerable<PollingUnitResultDto>> GetPollingUnitResultsAsync(int pollingUnitId)
        {
            var results = await _announcedPuResultRepository.GetResultsByPollingUnitIdAsync(pollingUnitId);
            return results.Select(r => new PollingUnitResultDto
            (
                Convert.ToInt32(r.PollingUnitUniqueId),
                r.PartyAbbreviation,
                r.PartyScore
            ));
        }


        public async Task<LgaResultDto> GetTotalResultsByLgaIdAsync(int lgaId)
        {
            var lga = await _lgaRepository.GetByIdAsync(lgaId);
            if (lga != null && (!lga.DateEntered.HasValue || lga.DateEntered.Value >= DateTime.MinValue))
            {
                var pollingUnits = await _pollingUnitRepository.GetPollingUnitsByLgaIdAsync(lgaId);
                var unitIds = pollingUnits.Select(p => p.UniqueId);

                var totalResults = new Dictionary<string, int>();
                foreach (var unitId in unitIds)
                {
                    var results = await _announcedPuResultRepository.GetResultsByPollingUnitIdAsync(unitId);
                    foreach (var result in results)
                    {
                        if (totalResults.ContainsKey(result.PartyAbbreviation))
                        {
                            totalResults[result.PartyAbbreviation] += result.PartyScore;
                        }
                        else
                        {
                            totalResults[result.PartyAbbreviation] = result.PartyScore;
                        }
                    }
                }
                return new LgaResultDto
                (
                    lgaId,
                    lga.LgaName,
                    totalResults
                );
            }
            else
            {
                return null;
            }
        }


        //public async Task<LgaResultDto> GetTotalResultsByLgaIdAsync(int lgaId)
        //{
        //    var lga = await _lgaRepository.GetByIdAsync(lgaId);
        //    if (lga != null)
        //    {
        //        var pollingUnits = await _pollingUnitRepository.GetPollingUnitsByLgaIdAsync(lgaId);
        //        var unitIds = pollingUnits.Select(p => p.UniqueId);

        //        var totalResults = new Dictionary<string, int>();
        //        foreach (var unitId in unitIds)
        //        {
        //            var results = await _announcedPuResultRepository.GetResultsByPollingUnitIdAsync(unitId);
        //            foreach (var result in results)
        //            {
        //                if (totalResults.ContainsKey(result.PartyAbbreviation))
        //                {
        //                    totalResults[result.PartyAbbreviation] += result.PartyScore;
        //                }
        //                else
        //                {
        //                    totalResults[result.PartyAbbreviation] = result.PartyScore;
        //                }
        //            }
        //        }
        //        return new LgaResultDto
        //        (
        //            lgaId,
        //            lga.LgaName,
        //            totalResults
        //        );
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}


        //public async Task AddPollingUnitResultAsync(AddResultDto addResultDto)
        //{
        //    var result = new AnnouncedPuResult
        //    {
        //        PollingUnitUniqueId = addResultDto.PollingUnitUniqueId.ToString(),
        //        PartyAbbreviation = addResultDto.Party,
        //        PartyScore = addResultDto.Score
        //    };

        //    await _announcedPuResultRepository.AddAsync(result);
        //}

        public async Task AddPollingUnitResultAsync(AddResultDto addResultDto)
        {
            if (addResultDto == null)
            {
                throw new ArgumentNullException(nameof(addResultDto), "The result data cannot be null.");
            }

            var result = new AnnouncedPuResult
            {
                PollingUnitUniqueId = addResultDto.PollingUnitUniqueId.ToString(),
                PartyAbbreviation = addResultDto.Party,
                PartyScore = addResultDto.Score,
                EnteredByUser = addResultDto.EnteredByUser ?? "System", // Default user if not provided
                DateEntered = DateTime.UtcNow, // Automatically set the current time
                UserIpAddress = addResultDto.UserIpAddress ?? "0.0.0.0" // Default IP if not provided
            };

            await _announcedPuResultRepository.AddAsync(result);
        }

    }
}
