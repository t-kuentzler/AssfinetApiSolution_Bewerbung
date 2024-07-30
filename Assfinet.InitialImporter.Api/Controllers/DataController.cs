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
        private readonly IVertragService _vertragService;

        public DataController(IApiService apiService, IKundeService kundeService,
            IVertragService vertragService)
        {
            _apiService = apiService;
            _kundeService = kundeService;
            _vertragService = vertragService;
        }

        [HttpPost("import-kunden")]
        public async Task<IActionResult> ImportKunden()
        {
            try
            {
                var kundenModels = await _apiService.GetKundenAsync();

                await _kundeService.ImportKundenAsync(kundenModels);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }
        
        [HttpPost("import-vertrage")]
        public async Task<IActionResult> ImportVertraege()
        {
            try
            {
                var vertraege = await _apiService.GetVertraegeAsync();

                await _vertragService.ImportVertraegeAsync(vertraege);
                
                return Ok(vertraege);
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }
        
        [HttpPost("import-spartenDaten")]
        public async Task<IActionResult> ImportSpartenDaten([FromQuery] string sparte)
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