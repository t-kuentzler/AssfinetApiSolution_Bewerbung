using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Models;
using AutoMapper;
using System;
using Assfinet.Shared.Exceptions;

namespace Assfinet.Shared.Services
{
    public class SparteParserService : ISparteParserService
    {
        private readonly IMapper _mapper;
        private readonly IAppLogger _logger;

        public SparteParserService(IMapper mapper, IAppLogger logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public IVertragKeyProvider ParseModelToDbEntity(object model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }

                switch (model)
                {
                    case KrvModel krvSparteModel:
                        return ParseKrvSparteModel(krvSparteModel);
                    case DepModel depSparteModel:
                        // return ParseDepSparteModel(depSparteModel);
                    // Fügen Sie hier weitere Fälle für andere Spartentypen hinzu
                    default:
                        throw new InvalidOperationException("Unbekannter Spartentyp.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Es ist ein unerwarteter Fehler beim Parsen des Spartemodells aufgetreten.", ex);
                throw new SparteParserServiceException();
            }
        }

        private KrvSparte ParseKrvSparteModel(KrvModel model)
        {
            var entity = _mapper.Map<KrvSparte>(model);
            if (entity == null)
            {
                throw new InvalidOperationException("Mapping von KrvModel zu KrvSparte fehlgeschlagen.");
            }
            return entity;
        }

        // private DepSparte ParseDepSparteModel(DepSparteModel model)
        // {
        //     var entity = _mapper.Map<DepSparte>(model);
        //     if (entity == null)
        //     {
        //         throw new InvalidOperationException("Mapping von DepSparteModel zu DepSparte fehlgeschlagen.");
        //     }
        //     return entity;
        // }

        // Fügen Sie hier weitere Methoden für andere Spartentypen hinzu
    }
}
