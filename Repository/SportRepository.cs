using Practico2024NET.Domain;
using Practico2024NET.Persistence;

namespace Practico2024NET.Repository
{
    public class SportRepository : ISportRepository
    {
        private readonly DataContext _dataContext;

        public SportRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddSport(Sport s)
        {
            _dataContext.sports.Add(s);
            _dataContext.SaveChanges();
        }

        public void DeleteSport(int id)
        {
            var sport = _dataContext.sports.FirstOrDefault(s => s.id == id);
            if (sport is null) return;
            _dataContext.sports.Remove(sport);
            _dataContext.SaveChanges();
        }

        public Sport? GetSport(int id)
        {
            return _dataContext.sports.FirstOrDefault(s => s.id == id);
        }

        public IEnumerable<Sport?> GetSports()
        {
            return _dataContext.sports.ToList();
        }

        public bool SportExists(int id)
        {
            return _dataContext.sports.Any(s => s.id == id);
        }

        public bool SportNameExists(string sport_name)
        {
            return _dataContext.sports.Any(s => s.name == sport_name);
        }

        public void UpdateSport(Sport s)
        {
            _dataContext.sports.Update(s);
            _dataContext.SaveChanges();
        }
    }
}
