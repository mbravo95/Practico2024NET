namespace Practico2024NET.Dtos
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CountryDto() { }

        public CountryDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
