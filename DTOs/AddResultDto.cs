using System.ComponentModel.DataAnnotations;

namespace BincomElectionProject.DTOs
{
    //public record AddResultDto
    //{
    //    public int PollingUnitUniqueId { get; init; }
    //    public string Party { get; init; }
    //    public int Score { get; init; }

    //    // Parameterless constructor
    //    public AddResultDto() { }

    //    // Full constructor
    //    public AddResultDto(int pollingUnitUniqueId, string party, int score)
    //    {
    //        PollingUnitUniqueId = pollingUnitUniqueId;
    //        Party = party;
    //        Score = score;
    //    }
    //}

    public record AddResultDto
    {
        [Required(ErrorMessage = "Polling Unit Unique ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Polling Unit Unique ID must be a positive integer.")]
        public int PollingUnitUniqueId { get; init; }

        [Required(ErrorMessage = "Party abbreviation is required.")]
        [StringLength(4, ErrorMessage = "Party abbreviation cannot exceed 4 characters.")]
        public string Party { get; init; } = string.Empty;

        [Required(ErrorMessage = "Party score is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Party score must be a non-negative number.")]
        public int Score { get; init; }

        [StringLength(50, ErrorMessage = "Entered By User cannot exceed 50 characters.")]
        public string? EnteredByUser { get; init; }

        [StringLength(50, ErrorMessage = "User IP Address cannot exceed 50 characters.")]
        [RegularExpression(@"\b(?:\d{1,3}\.){3}\d{1,3}\b", ErrorMessage = "Invalid IP address format.")]
        public string? UserIpAddress { get; init; }
    }


}
