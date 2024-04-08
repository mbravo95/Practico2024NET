using Practico2024NET.Domain;

namespace Practico2024NET.Repository
{
    public interface ICountryRepository
    {
        IEnumerable<Country?> GetCountries();
        Country? GetCountry(int id);
        void AddCountry(Country c);
        void UpdateCountry(Country c);
        void DeleteCountry(int id);
        bool CountryExists(int id);
        bool CountryNameExists(string country_name);
    }
}
