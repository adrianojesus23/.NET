using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class PointOfInterestDto
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        //[MaxLength(20)]
        //public string? Description { get; set; }
    }
}
