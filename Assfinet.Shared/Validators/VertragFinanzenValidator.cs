using FluentValidation;
using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Validators
{
    public class VertragFinanzenValidator : AbstractValidator<VertragFinanzen>
    {
        public VertragFinanzenValidator()
        {
            RuleFor(vf => vf.ApBetrag).NotNull();
            RuleFor(vf => vf.ApBuchungsdatum).NotNull();
            RuleFor(vf => vf.BwSumme).NotNull();
            RuleFor(vf => vf.Bwsummezv).NotNull();
            RuleFor(vf => vf.DifferenzCourtage).NotNull();
            RuleFor(vf => vf.DifferenzCourtageBetrag).NotNull();
            RuleFor(vf => vf.EffektivcourtageProzent).NotNull();
            RuleFor(vf => vf.PraemieNetto).NotNull();
            RuleFor(vf => vf.ProgrammCourtage).NotNull();
            RuleFor(vf => vf.ProgrammCourtageBetrag).NotNull();
            RuleFor(vf => vf.Jahrespraemie).NotNull();
            RuleFor(vf => vf.Jahressteuerbetrag).NotNull();
            RuleFor(vf => vf.Steuer).NotNull();
            RuleFor(vf => vf.SteuerZw).NotNull();
            RuleFor(vf => vf.Zuschlagbetrag).NotNull();
            RuleFor(vf => vf.ZuschlagbetragZw).NotNull();
        }
    }
}