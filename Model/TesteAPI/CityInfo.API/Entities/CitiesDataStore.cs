using CityInfo.API.Models;

namespace CityInfo.API.Entities
{
    public class CitiesDataStore
    {
        public IList<CitiesDto> Cities { get; set; }

        // public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public CitiesDataStore()
        {
            Cities = new List<CitiesDto>() {
            new CitiesDto()
            {
                 Id = 1,
                 Name = "New York",
                 Description = "The one with taht big park.",
                 PointsOfInterest =new List<PointOfInterestDto>()
                 {
                     new PointOfInterestDto()
                     {
                          Id=1,
                           Name = "Jesu",
                           //Description = "teste"
                     }
                 }
            },
            new CitiesDto()
            {
                Id = 2,
                Name = "Lisbon",
                Description = "The gabragge pun",
                PointsOfInterest =new List<PointOfInterestDto>()
                 {
                     new PointOfInterestDto()
                     {
                          Id=3,
                           Name = "Jesu",
                          // Description = "teste"
                     }
                 }
            },
             new CitiesDto()
            {
                Id = 3,
                Name = "London",
                Description = "My dream city.",
                PointsOfInterest =new List<PointOfInterestDto>()
                 {
                     new PointOfInterestDto()
                     {
                          Id=2,
                           Name = "Jesu",
                          // Description = "teste"
                     }
                 }
            }
            };
        }

        //public async Task<IList<CitiesDto>> Get(List<CitiesDto> result)
        //{

        //    return await result;
        //}
    }
}
