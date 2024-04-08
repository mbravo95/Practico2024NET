namespace Practico2024NET.Dtos
{
    public class SportDto
    {
        public SportDto() { }

        public SportDto(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int id { get; set; }
        public string name { get; set; }
    }
}
