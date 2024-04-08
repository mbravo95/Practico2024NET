using Practico2024NET.Domain;

namespace Practico2024NET.Repository
{
    public interface ISportRepository
    {
        IEnumerable<Sport?> GetSports();
        Sport? GetSport(int id);
        void AddSport(Sport s);
        void UpdateSport(Sport s);
        void DeleteSport(int id);
        bool SportExists(int id);
        bool SportNameExists(string sport_name);
    }
}
