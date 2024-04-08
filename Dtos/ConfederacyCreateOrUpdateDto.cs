using System.ComponentModel.DataAnnotations;

namespace Practico2024NET.Dtos
{
    public class ConfederacyCreateOrUpdateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime creation_date { get; set; }
    }
}
