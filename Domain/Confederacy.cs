using System.ComponentModel.DataAnnotations;

namespace Practico2024NET.Domain
{
    public class Confederacy
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public DateTime creation_date { get; set; }
    }
}
