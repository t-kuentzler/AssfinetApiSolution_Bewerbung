using FluentValidation;
using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Validators
{
    public class VertragHistorieValidator : AbstractValidator<VertragHistorie>
    {
        public VertragHistorieValidator()
        {
            RuleFor(vh => vh.Historiendatum).NotNull();
            RuleFor(vh => vh.Historiengrund).MaximumLength(100);
            RuleFor(vh => vh.HistorieZuVertrag).MaximumLength(40);
            RuleFor(vh => vh.HonorarVm1).NotNull();
            RuleFor(vh => vh.HonorarVm10).NotNull();
            RuleFor(vh => vh.HonorarVm2).NotNull();
            RuleFor(vh => vh.HonorarVm3).NotNull();
            RuleFor(vh => vh.HonorarVm4).NotNull();
            RuleFor(vh => vh.HonorarVm5).NotNull();
            RuleFor(vh => vh.HonorarVm6).NotNull();
            RuleFor(vh => vh.HonorarVm7).NotNull();
            RuleFor(vh => vh.HonorarVm8).NotNull();
            RuleFor(vh => vh.HonorarVm9).NotNull();
            RuleFor(vh => vh.Hpvahb).MaximumLength(15);
            RuleFor(vh => vh.HpvGruppe).NotNull();
        }
    }
}