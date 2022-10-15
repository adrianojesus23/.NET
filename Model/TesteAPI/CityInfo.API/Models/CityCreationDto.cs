using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class CityCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<PointOfInterestCreationDto> PointsOfInterest { get; set; } = new List<PointOfInterestCreationDto>();
    }
}
