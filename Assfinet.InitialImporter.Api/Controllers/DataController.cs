using Assfinet.Shared.Contracts;
using Assfinet.Shared.Exceptions;
using Assfinet.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assfinet.InitialImporter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IApiService _apiService;
        private readonly IAppLogger _logger;

        public DataController(IApiService apiService, IAppLogger logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        [HttpGet("kunden")]
        public async Task<IActionResult> GetKunden()
        {
            try
            {
                var kunden = await _apiService.GetKundenAsync();
                return Ok(kunden);
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }
        
        [HttpGet("vertrage")]
        public async Task<IActionResult> GetVertraege()
        {
            try
            {
                var vertraege = await _apiService.GetVertraegeAsync();
                return Ok(vertraege);
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }
        
        [HttpGet("spartenDaten")]
        public async Task<IActionResult> GetSpartenDaten([FromQuery] string sparte)
        {
            try
            {
                var spartenDaten = await _apiService.GetSpartenDatenAsync(sparte);
                return Ok(spartenDaten);
            }
            catch (UnknownSparteException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }
    }
}