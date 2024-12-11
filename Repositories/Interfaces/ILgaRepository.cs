using BincomElectionProject.Models.Entities;

namespace BincomElectionProject.Repositories.Interfaces
{
    public interface ILgaRepository
    {
        Task<Lga> GetByIdAsync(int id);
    }
}
