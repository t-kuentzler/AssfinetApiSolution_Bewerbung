using Assfinet.Shared.Entities;
using FluentValidation;

namespace Assfinet.Shared.Validators
{
    public class ImoSparteValidator : AbstractValidator<ImoSparte>
    {
        public ImoSparteValidator()
        {
            RuleFor(v => v.AmsId).NotEmpty();
            RuleFor(v => v.Amsidnr)
                .NotEmpty()
                .MaximumLength(40);
            RuleFor(v => v.Key)
                .NotEmpty()
                .MaximumLength(40);
            RuleFor(v => v.Typ)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(v => v.License).MaximumLength(40);
            RuleFor(v => v.LastSynchronisation).NotEmpty();

            RuleFor(v => v.IMO101).MaximumLength(150);
            RuleFor(v => v.IMO102).MaximumLength(150);
            RuleFor(v => v.IMO104).MaximumLength(150);
            RuleFor(v => v.IMO105).MaximumLength(150);
            RuleFor(v => v.IMO106).MaximumLength(150);
            RuleFor(v => v.IMO109).MaximumLength(150);
            RuleFor(v => v.IMO110).MaximumLength(150);
            RuleFor(v => v.IMO114).MaximumLength(150);
            RuleFor(v => v.IMO115).MaximumLength(150);
            RuleFor(v => v.IMO116).MaximumLength(150);
            RuleFor(v => v.IMO117).MaximumLength(150);
            RuleFor(v => v.IMO118).MaximumLength(150);
            RuleFor(v => v.IMO119).MaximumLength(150);
            RuleFor(v => v.IMO121).MaximumLength(150);
            RuleFor(v => v.IMO122).MaximumLength(150);
            RuleFor(v => v.IMO123).MaximumLength(150);
            RuleFor(v => v.IMO125).MaximumLength(150);
            RuleFor(v => v.IMO126).MaximumLength(150);
            RuleFor(v => v.IMO127).MaximumLength(150);
            RuleFor(v => v.IMO128).MaximumLength(150);
            RuleFor(v => v.IMO130).MaximumLength(150);
            RuleFor(v => v.IMO131).MaximumLength(150);
            RuleFor(v => v.IMO132).MaximumLength(150);
        }
    }
}