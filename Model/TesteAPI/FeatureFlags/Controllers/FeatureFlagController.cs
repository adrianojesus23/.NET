using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

namespace FeatureFlags.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FeatureFlagController : ControllerBase
    {
        private readonly IFeatureManager _featureManager;
        private readonly IConfiguration _configuration;

        public FeatureFlagController(IFeatureManager featureManager, IConfiguration configuration)
        {
            _featureManager = featureManager;
            _configuration = configuration;
        }

        [HttpGet("BooleanFilter")]
        public async Task<IActionResult> BooleanFilter()
        {
            var names = _featureManager.GetFeatureNamesAsync();

            await foreach (var v in names)
            {
                //_configuration["Authentication:SecretForKey"]))
                var xx = _configuration[v];
                var x = v;
            }

            if (await _featureManager.IsEnabledAsync("BooleanFilter"))
            {
                return Ok("Feature enabled");
            }
            else
            {
                return BadRequest("Feature not enabled");
            }
        }

        [HttpGet("PercentageFilter")]
        public async Task<IActionResult> PercentageFilter()
        {
            if (await _featureManager.IsEnabledAsync("PercentageFilter"))
            {
                return Ok("Feature enabled");
            }
            else
            {
                return BadRequest("Feature not enabled");
            }
        }

        [HttpGet("CustomFilter")]
        public async Task<IActionResult> CustomFilter()
        {
            if (await _featureManager.IsEnabledAsync("CustomFilter"))
            {
                return Ok("Feature enabled");
            }
            else
            {
                return BadRequest("Feature not enabled");
            }
        }

        [HttpGet("TimeWindowFilter")]
        public async Task<IActionResult> TimeWindowFilter()
        {
            var collection = _featureManager.GetFeatureNamesAsync();

            if (collection is not null)
            {

            }

            if (await _featureManager.IsEnabledAsync("TimeWindowFilter"))
            {

                return Ok("Feature enabled");
            }
            else
            {
                return BadRequest("Feature not enabled");
            }
        }
    }
}
