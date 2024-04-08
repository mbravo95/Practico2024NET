namespace Practico2024NET.Service
{
    public interface ISportService
    {
        IEnumerable<string> getSports();
        string getSport(int id);
        void addSport(string sport_name);
        void deleteSport(int id);
        void updateSport(int id, string sport_name);
    }
}
