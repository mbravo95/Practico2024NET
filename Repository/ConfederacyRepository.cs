using Practico2024NET.Domain;
using Practico2024NET.Persistence;

namespace Practico2024NET.Repository
{
    public class ConfederacyRepository : IConfederacyRepository
    {
        private readonly DataContext _dataContext;
        public ConfederacyRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void AddConfederacy(Confederacy c)
        {
            _dataContext.confederacies.Add(c);
            _dataContext.SaveChanges();
        }

        public bool ConfederacyExists(int id)
        {
            return _dataContext.confederacies.Any(c => c.id == id);
        }

        public bool ConfederacyNameExists(string conf_name)
        {
            return _dataContext.confederacies.Any(c => c.name == conf_name);
        }

        public void DeleteConfederacy(int id)
        {
            var confederacy = _dataContext.confederacies.FirstOrDefault(c => c.id == id);
            if (confederacy is null) return;
            _dataContext.confederacies.Remove(confederacy);
            _dataContext.SaveChanges();
        }

        public IEnumerable<Confederacy?> GetConfederacies()
        {
            return _dataContext.confederacies.ToList();
        }

        public Confederacy? GetConfederacy(int id)
        {
            return _dataContext.confederacies.FirstOrDefault(c => c.id == id);
        }

        public void UpdateConfederacy(Confederacy c)
        {
            _dataContext.confederacies.Update(c);
            _dataContext.SaveChanges();
        }
    }
}
