using CityInfo.API.Entities;

namespace CityInfo.API.Repository
{
    public interface ICityRepository
    {
        Task<City?> GetCitiesByIdAsync(int id, bool includePoint);
        Task<(IEnumerable<City>, PaginationMetadata)> GetAllCitiesAsync(string? query, int pageNumber, int pageSize);
        Task<IEnumerable<PointOfInterest>> GetPointForCitiesAsync(int cityId);
        Task<PointOfInterest?> GetPointForCitiesByIdAsync(int cityId, int pointId);

        Task<bool> CityExistAsync(int cityId);

        Task AddCity(City city);
        Task<bool> SaveChangeAsync();
        Task AddOintForCity(int cityId, PointOfInterest pointOfInterest);
    }
}
