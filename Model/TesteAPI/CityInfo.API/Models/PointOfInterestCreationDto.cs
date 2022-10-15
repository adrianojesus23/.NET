using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class PointOfInterestCreationDto
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        // public string? Description { get; set; }
    }
}
