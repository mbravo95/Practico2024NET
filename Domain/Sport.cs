using System.ComponentModel.DataAnnotations;

namespace Practico2024NET.Domain
{
    public class Sport
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
    }
}
