using Practico2024NET.Domain;

namespace Practico2024NET.Repository
{
    public interface IConfederacyRepository
    {
        IEnumerable<Confederacy?> GetConfederacies();
        Confederacy? GetConfederacy(int id);
        void AddConfederacy(Confederacy c);
        void UpdateConfederacy(Confederacy c);
        void DeleteConfederacy(int id);
        bool ConfederacyExists(int id);
        bool ConfederacyNameExists(string conf_name);
    }
}
