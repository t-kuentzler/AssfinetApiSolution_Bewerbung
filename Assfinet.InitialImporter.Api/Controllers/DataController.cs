using Assfinet.Shared.Contracts;
using Assfinet.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Assfinet.InitialImporter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IApiService _apiService;
        private readonly IKundeService _kundeService;

        public DataController(IApiService apiService, IKundeService kundeService)
        {
            _apiService = apiService;
            _kundeService = kundeService;
        }

        [HttpGet("import-kunden")]
        public async Task<IActionResult> ImportKunden()
        {
            try
            {
                var kundenModels = await _apiService.GetKundenAsync();

                await _kundeService.SaveKundenAsync(kundenModels);

                return Ok();
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
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }
    }
}