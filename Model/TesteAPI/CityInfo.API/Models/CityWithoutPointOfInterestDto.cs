namespace CityInfo.API.Models
{
    /// <summary>
    /// CityWithoutPointOfInterestDto
    /// </summary>
    public class CityWithoutPointOfInterestDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Description
        /// </summary>
        public string? Description { get; set; }
    }
}
