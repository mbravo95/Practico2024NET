using Practico2024NET.Domain;
using Practico2024NET.Persistence;

namespace Practico2024NET.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _dataContext;

        public CountryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void AddCountry(Country c)
        {
            _dataContext.countries.Add(c);
            _dataContext.SaveChanges();
        }

        public bool CountryExists(int id)
        {
            return _dataContext.countries.Any(c => c.id == id);
        }

        public bool CountryNameExists(string country_name)
        {
            return _dataContext.sports.Any(c => country_name == c.name);
        }

        public void DeleteCountry(int id)
        {
            var country = _dataContext.countries.FirstOrDefault(c => c.id == id);
            if (country is null) return;
            _dataContext.Remove(country);
            _dataContext.SaveChanges();
        }

        public IEnumerable<Country?> GetCountries()
        {
            return _dataContext.countries.ToList();
        }

        public Country? GetCountry(int id)
        {
            return _dataContext.countries.FirstOrDefault(c => c.id == id);
        }

        public void UpdateCountry(Country c)
        {
            _dataContext.countries.Update(c);
            _dataContext.SaveChanges();
        }
    }
}
