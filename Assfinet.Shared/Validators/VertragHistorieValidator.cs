using FluentValidation;
using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Validators
{
    public class VertragHistorieValidator : AbstractValidator<VertragHistorie>
    {
        public VertragHistorieValidator()
        {
            RuleFor(vh => vh.Historiengrund).MaximumLength(100);
            RuleFor(vh => vh.HistorieZuVertrag).MaximumLength(40);
            RuleFor(vh => vh.Hpvahb).MaximumLength(15);
        }
    }
}