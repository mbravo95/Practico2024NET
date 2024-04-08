namespace Practico2024NET.Service
{
    public interface ICountryService
    {
        IEnumerable<string> getCountries();
        string getCountry(int id);
        void addCountry(string country_name);
        void deleteCountry(int id);
        void updateCountry(int id, string country_name);
    }
}
