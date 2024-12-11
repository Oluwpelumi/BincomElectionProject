namespace BincomElectionProject.DTOs
{
    public record LgaResultDto(
    int LgaId,
    string LgaName,
    Dictionary<string, int> TotalResultsByParty
    );
}
