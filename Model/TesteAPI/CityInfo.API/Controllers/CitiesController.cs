using AutoMapper;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Repository;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
namespace CityInfo.API.Controllers
{

    [Route("api/[controller]")]
    [Authorize(Policy = "MustBeFromAntwerp")]
    [ApiVersion("1.0")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;
        private readonly ILogger<CitiesController> _logger;
        private readonly ILocalMailService _mailService;
        private readonly ICloudMailService _cloudMail;
        private readonly CitiesDataStore _citiesDataStore;

        public CitiesController(IMapper mapper, ICityRepository cityRepository, ILogger<CitiesController> logger, ILocalMailService mailService, ICloudMailService cloudMail, CitiesDataStore citiesDataStore)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _cityRepository = cityRepository;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _cloudMail = cloudMail ?? throw new ArgumentNullException(nameof(cloudMail));
            _citiesDataStore = citiesDataStore ?? throw new ArgumentNullException(nameof(citiesDataStore));
        }
        private const int maxPage = 20;

        [HttpGet]
        //JsonResult
        public async Task<ActionResult<IEnumerable<CityWithoutPointOfInterestDto>>> GetCities([FromQuery] string? query, int pageNumber = 1, int pageSize = 10)
        {
            //IList<Object> listCities = new List<Object>();
            //listCities.Add(new { Id = 1, Name = "Laura" });
            //listCities.Add(new { Id = 2, Name = "Gabriel" });
            //listCities.Add(new { Id = 3, Name = "Jeuss" });
            // var result = new JsonResult(_citiesDataStore.Cities);
            //result.StatusCode = 200;

            //_mailService.Send("Carta", "Envia me money");
            //return Ok(result);
            //new JsonResult(_citiesDataStore.Cities); ;

            if (pageSize > maxPage) { pageNumber = maxPage; }
            // var cities = await _cityRepository.GetAllCitiesAsync(query, pageNumber, pageSize);

            //var results = new List<CityWithoutPointOfInterestDto>();
            //foreach (var city in cities)
            //{
            //    results.Add(new CityWithoutPointOfInterestDto
            //    {
            //        Id = city.Id,
            //        Name = city.Name,
            //        Description = city.Description
            //    });
            //}
            //var results = _mapper.Map<IEnumerable<CityWithoutPointOfInterestDto>>(cities);

            //var cityName = User.Claims.FirstOrDefault(x => x.Type == "city").Value;



            var (cityEntities, paginationMetada) = await _cityRepository.GetAllCitiesAsync(query, pageNumber, pageSize);


            //if (!cityEntities.Any(x => x.Name == cityName))
            //{
            //    Forbid();
            //}

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetada));

            return Ok(_mapper.Map<IEnumerable<CityWithoutPointOfInterestDto>>(cityEntities));
            //  return results.Any() ? Ok(results) : NotFound();
        }

        /// <summary>
        /// GetCityById
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="incluidePoint">incluidePoint</param>
        /// <response code="200"></response>
        /// <returns></returns>
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCityById([FromQuery] int id, bool incluidePoint = false)
        {

            var city = await _cityRepository.GetCitiesByIdAsync(id, incluidePoint);

            if (city is null)
                NotFound();

            if (incluidePoint)
                return Ok(_mapper.Map<CitiesDto>(city));

            return Ok(_mapper.Map<CityWithoutPointOfInterestDto>(city));
            //var result = new CitiesDto();
            //try
            //{
            //    if (id.HasValue is false)
            //        return BadRequest();

            //    result = _citiesDataStore.Cities.Where(x => x.Id.Equals(id)).FirstOrDefault();

            //    if (result is null)
            //    {
            //        _logger.LogInformation($"The city not found {result}");
            //        _logger.LogCritical($"{id} error this");
            //        return NotFound();
            //    }

            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, "Problem");
            //}

            //return Ok(result);
        }


        [HttpGet("point", Name = "GetPoint")]
        public async Task<ActionResult<IEnumerable<PointOfInterestDto>>> GetAllPoint(int cityId)
        {
            if (!await _cityRepository.CityExistAsync(cityId))
            {
                _logger.LogInformation($"City with in {cityId} wasn't found when accessing points of interest");

                NotFound();
            }

            var points = await _cityRepository.GetPointForCitiesAsync(cityId);

            var result = _mapper.Map<IEnumerable<PointOfInterestDto>>(points);

            return result.Any() ? Ok(result) : NotFound();
        }


        [HttpGet("PointOnly")]
        public async Task<ActionResult<PointOfInterestDto>> GetPoint(int cityId, int pointOfInterestId)
        {
            if (!await _cityRepository.CityExistAsync(cityId))
            {
                _logger.LogInformation($"City with in {cityId} wasn't found when accessing points of interest");

                NotFound();
            }
            var point = await _cityRepository.GetPointForCitiesByIdAsync(cityId, pointOfInterestId);

            if (point is null)
            {
                _logger.LogInformation($"No found point of interest");
                NotFound();
            }

            var result = _mapper.Map<PointOfInterestDto>(point);
            return result is null ? NotFound() : Ok(result);
            //var city = _citiesDataStore.Cities.Where(x => x.Id.Equals(cityId)).FirstOrDefault();

            //if (city is null) PointOfInterestDto
            //    return NotFound();

            //var point = city.PointsOfInterest.FirstOrDefault(x => x.Id == pointOfInterestId);

            //if (point is null)
            //    return NotFound();

            //return Ok(point);
        }

        [HttpPost("City")]
        public async Task<ActionResult<CityCreationDto>> CreatePointOfInterest([FromBody] CityCreationDto cityCreationDto)
        {
            var final = _mapper.Map<City>(cityCreationDto);

            await _cityRepository.AddCity(final);

            await _cityRepository.SaveChangeAsync();

            return CreatedAtRoute("GetCityById", new { id = final.Id, incluidePoint = false }, cityCreationDto);
        }


        [HttpPost]
        public async Task<ActionResult<PointOfInterestDto>> CreatePointOfInterest(int cityId, [FromBody] PointOfInterestCreationDto pointOfInterestCreationDto)
        {
            //if (ModelState.IsValid) BadRequest();

            //var result = _citiesDataStore.Cities.Where(x => x.Id.Equals(cityId)).FirstOrDefault();

            //if (result is null)
            //    return NotFound();

            //var max = _citiesDataStore.Cities.SelectMany(x => x.PointsOfInterest).Max(x => x.Id);

            //var final = new PointOfInterestDto()
            //{
            //    Id = ++max,
            //    Name = pointOfInterestCreationDto.Name,
            //    //  Description = pointOfInterestCreationDto.Description
            //};

            //result.PointsOfInterest.Add(final);

            if (!await _cityRepository.CityExistAsync(cityId))
            {
                _logger.LogInformation($"City with in {cityId} wasn't found when accessing points of interest");

                NotFound();
            }

            var final = _mapper.Map<PointOfInterest>(pointOfInterestCreationDto);

            await _cityRepository.AddOintForCity(cityId, final);

            await _cityRepository.SaveChangeAsync();

            return CreatedAtRoute("GetPoint", new { cityId = cityId, pointOfInterestId = final.Id }, pointOfInterestCreationDto);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(typeof(CitiesDto), StatusCodes.Status200OK)]
        public IEnumerable<IActionResult> GetByName([FromQuery] string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                BadRequest();

            var result = _citiesDataStore.Cities.FirstOrDefault(x => x.Name.Equals(name));

            if (result is null)
                NotFound();

            yield return Ok(result);
        }

        [HttpGet("Asinc")]
        public IAsyncEnumerable<int> GetAsync()
        {
            return FetchItems();
        }

        private async IAsyncEnumerable<int> FetchItems()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000);

                yield return i;
            }
        }

        /*
         IAsyncEnumerable
        yield return
         */
    }
}
