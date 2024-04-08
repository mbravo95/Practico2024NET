using Practico2024NET.Domain;
using Practico2024NET.Exceptions;
using Practico2024NET.Repository;

namespace Practico2024NET.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public IEnumerable<string> getCountries()
        {
            return countriesToString(_countryRepository.GetCountries());
        }

        public string getCountry(int id)
        {
            var country = _countryRepository.GetCountry(id);
            if (country is null) throw new RecordNotFoundException("El pais con id=" + id + " no existe.");
            return country.name;
        }

        public void addCountry(string country_name)
        {
            if (_countryRepository.CountryNameExists(country_name)) throw new RecordDuplicatedException("El pais " + country_name + " ya existe en el sistema.");
            _countryRepository.AddCountry(new Country { name = country_name });
        }

        public void deleteCountry(int id)
        {
            if (!_countryRepository.CountryExists(id)) throw new RecordNotFoundException("El pais con id=" + id + " no existe.");
            _countryRepository.DeleteCountry(id);
        }

        public void updateCountry(int id, string country_name)
        {
            var country = _countryRepository.GetCountry(id);
            if (country is null) throw new RecordNotFoundException("El pais con id=" + id + " no existe.");
            if (_countryRepository.CountryNameExists(country_name)) throw new RecordDuplicatedException("El pais " + country_name + " ya existe en el sistema.");
            country.name = country_name;
            _countryRepository.UpdateCountry(country);
        }

        private IEnumerable<string> countriesToString(IEnumerable<Country> countries)
        {
            IEnumerable<string> result = new List<string>();
            foreach (Country c in countries)
            {
                result.Append(c.name);
            }
            return result;
        }
    }
}
