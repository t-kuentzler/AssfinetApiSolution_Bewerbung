using Assfinet.Shared.Contracts;
using FluentValidation;

namespace Assfinet.Shared.Validators;

public class VertragKeyProviderValidator : AbstractValidator<IVertragKeyProvider>
{
    public VertragKeyProviderValidator()
    {
        RuleFor(x => x.Key).NotEmpty().WithMessage("Key darf nicht leer sein.");
    }
}