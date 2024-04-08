namespace Practico2024NET.Dtos
{
    public class ConfederacyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Creation_date { get; set; }

        public ConfederacyDto() { }

        public ConfederacyDto(int id, string name, DateTime creation_date)
        {
            Id = id;
            Name = name;
            Creation_date = creation_date;
        }
    }
}
