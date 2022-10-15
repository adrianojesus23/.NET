using CityInfo.API.DbContexts;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly CityInfoContext _context;

        public CityRepository(CityInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddCity(City city)
        {
            await _context.Cities.AddAsync(city);
        }

        public async Task AddOintForCity(int cityId, PointOfInterest pointOfInterest)
        {
            var city = await GetCitiesByIdAsync(cityId, false);

            if (city is not null)
            {
                city.PointsOfInterest.Add(pointOfInterest);
            }
        }

        public async Task<bool> CityExistAsync(int cityId)
        {
            return await _context.Cities.AnyAsync(c => c.Id == cityId);
        }

        private const int maxPage = 20;

        public async Task<(IEnumerable<City>, PaginationMetadata)> GetAllCitiesAsync(string? query, int pageNumber, int pageSize)
        {
            //if (string.IsNullOrWhiteSpace(query))
            //    return await _context.Cities.OrderBy(c => c.Name).ToListAsync();

            //query = query.Trim();

            //return await _context.Cities
            //    .Where(c => c.Name == query)
            //    .OrderBy(c => c.Name)
            //    .ToListAsync();
            var collection = _context.Cities as IQueryable<City>;

            if (!string.IsNullOrEmpty(query))
            {
                query = query.Trim();

                collection = collection.Where(x => x.Name.Contains(query)
                || x.Description != null && x.Description.Contains(query));

                collection = collection.Where(x => x.Name == query);

            }

            var totalItemCount = await collection.CountAsync();

            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);


            var collectionReturn = await collection.OrderBy(x => x.Name)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionReturn, paginationMetadata);
        }

        public async Task<City?> GetCitiesByIdAsync(int id, bool includePoint)
        {
            if (includePoint)
                return await _context.Cities.Include(c => c.PointsOfInterest).Where(c => c.Id == id).FirstOrDefaultAsync();

            return await _context.Cities.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PointOfInterest>> GetPointForCitiesAsync(int cityId)
        {
            return await _context.PointOfInterest.Where(c => c.Id == cityId).ToListAsync();
        }

        public async Task<PointOfInterest?> GetPointForCitiesByIdAsync(int cityId, int pointId)
        {
            return await _context.PointOfInterest.Where(c => c.CityId == cityId && c.Id == pointId).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
