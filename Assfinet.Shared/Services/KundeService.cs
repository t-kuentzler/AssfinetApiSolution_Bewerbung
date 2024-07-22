using Assfinet.Shared.Contracts;
using Assfinet.Shared.Models;

namespace Assfinet.Shared.Services;

public class KundeService : IKundeService
{
    private readonly IKundeRepository _kundeRepository;
    private readonly IKundeParserService _kundeParserService;
    private readonly IAppLogger _logger;

    public KundeService(IKundeRepository kundeRepository, IKundeParserService kundeParserService,
        IAppLogger logger)
    {
        _kundeRepository = kundeRepository;
        _kundeParserService = kundeParserService;
        _logger = logger;
    }

    public async Task SaveKundenAsync(List<KundeModel> kunden)
    {
        try
        {
            if (kunden.Count == 0)
            {
                _logger.LogWarning("Es wurden 0 Kunden von der API abgerufen.");
                return;
            }

            foreach (var kunde in kunden)
            {
                var parsedKunde = _kundeParserService.ParseKundeModelToDbEntity(kunde);
                await _kundeRepository.AddKundeAsync(parsedKunde);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Es ist ein unerwarteter Fehler aufgetreten.", ex);
        }

    }
}
