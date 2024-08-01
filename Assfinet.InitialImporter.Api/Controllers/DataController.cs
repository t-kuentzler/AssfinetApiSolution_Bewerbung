using Assfinet.Shared.Contracts;
using Assfinet.Shared.Enums;
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
        private readonly IKundeService _kundeService;
        private readonly IVertragService _vertragService;
        private readonly ISparteService _sparteService;
        private readonly IAppLogger _logger;

        public DataController(IApiService apiService, IKundeService kundeService,
            IVertragService vertragService, ISparteService sparteService,
            IAppLogger logger)
        {
            _apiService = apiService;
            _kundeService = kundeService;
            _vertragService = vertragService;
            _sparteService = sparteService;
            _logger = logger;
        }

        [HttpPost("import-kunden")]
        public async Task<IActionResult> ImportKunden()
        {
            try
            {
                int skip = 4200;
                int take = 50;
                bool hasMoreData = true;
                var allKunden = new List<KundeModel>();

                while (hasMoreData)
                {
                    var kundenModels = await _apiService.GetKundenAsync(skip, take);
                    if (kundenModels.Count < take)
                    {
                        hasMoreData = false;
                    }

                    if (kundenModels.Count > 0)
                    {
                        await _kundeService.ImportKundenAsync(kundenModels);
                        allKunden.AddRange(kundenModels);
                    }

                    skip += take;
                    await Task.Delay(3000);
                }

                _logger.LogInformation($"Es wurden insgesamt {allKunden.Count} Kunden importiert.");
                return Ok("Import abgeschlossen.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }

        [HttpPost("import-vertraege")]
        public async Task<IActionResult> ImportVertraege()
        {
            try
            {
                int skip = 12000;
                int take = 50;
                bool hasMoreData = true;
                var allVertraege = new List<VertragModel>();

                while (hasMoreData)
                {
                    var vertraegeModels = await _apiService.GetVertraegeAsync(skip, take);
                    if (vertraegeModels.Count < take)
                    {
                        hasMoreData = false;
                    }

                    if (vertraegeModels.Count > 0)
                    {
                        await _vertragService.ImportVertraegeAsync(vertraegeModels);
                        allVertraege.AddRange(vertraegeModels);
                    }

                    skip += take;
                    await Task.Delay(3000);
                }

                _logger.LogInformation($"Es wurden insgesamt {allVertraege.Count} Verträge importiert.");
                return Ok("Import abgeschlossen.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Interner Serverfehler");
            }
        }

        [HttpPost("import-sparten")]
        public async Task<IActionResult> ImportSpartenDaten([FromQuery] Spartentypen sparte)
        {
            try
            {
                int skip = 0;
                int take = 10;
                bool hasMoreData = true;
                var allSparten = new List<object>();

                while (hasMoreData)
                {
                    var spartenDaten = await _apiService.GetSpartenDatenAsync(sparte.ToString(), skip, take);
                    if (spartenDaten.Count < take)
                    {
                        hasMoreData = false;
                    }

                    if (spartenDaten.Count > 0)
                    {
                        // await _sparteService.ImportSpartenDatenAsync(spartenDaten);
                        allSparten.AddRange(spartenDaten);
                    }

                    skip += take;
                    await Task.Delay(3000);
                }

                _logger.LogInformation($"Es wurden insgesamt {allSparten.Count} Verträge importiert.");
                return Ok("Import abgeschlossen.");
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