using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using Assfinet.Shared.Exceptions;

namespace Assfinet.Shared.Services
{
    public class KundeParserService : IKundeParserService
    {
        private readonly IMapper _mapper;
        private readonly IAppLogger _logger;

        public KundeParserService(IMapper mapper, IAppLogger logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public Kunde ParseKundeModelToDbEntity(KundeModel kundeModel)
        {
            try
            {
                if (kundeModel == null)
                {
                    throw new ArgumentNullException(nameof(kundeModel));
                }

                var kunde = _mapper.Map<Kunde>(kundeModel);
                if (kunde == null)
                {
                    throw new InvalidOperationException("Mapping von KundeModel zu Kunde fehlgeschlagen.");
                }

                kunde.PersonenDetails = _mapper.Map<KundePersonenDetails>(kundeModel) ?? new KundePersonenDetails();
                kunde.Finanzen = _mapper.Map<KundeFinanzen>(kundeModel) ?? new KundeFinanzen();
                kunde.Kontakt = _mapper.Map<KundeKontakt>(kundeModel) ?? new KundeKontakt();

                return kunde;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"Es ist ein unerwarteter Fehler beim Parsen von KundeModel zu Kunde aufgetreten.",
                    ex);
                throw new KundeParserServiceException();
            }
        }
    }
}