using Assfinet.Shared.Entities;
using FluentValidation;

namespace Assfinet.Shared.Validators
{
    public class KrvSparteValidator : AbstractValidator<KrvSparte>
    {
        public KrvSparteValidator()
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

            RuleFor(v => v.KRV101).MaximumLength(150);
            RuleFor(v => v.KRV102).MaximumLength(150);
            RuleFor(v => v.KRV103).MaximumLength(150);
            RuleFor(v => v.KRV104).MaximumLength(150);
            RuleFor(v => v.KRV105).MaximumLength(150);
            RuleFor(v => v.KRV106).MaximumLength(150);
            RuleFor(v => v.KRV108).MaximumLength(150);
            RuleFor(v => v.KRV109).MaximumLength(150);
            RuleFor(v => v.KRV110).MaximumLength(150);
            RuleFor(v => v.KRV111).MaximumLength(150);
            RuleFor(v => v.KRV112).MaximumLength(150);
            RuleFor(v => v.KRV113).MaximumLength(150);
            RuleFor(v => v.KRV114).MaximumLength(150);
            RuleFor(v => v.KRV115).MaximumLength(150);
            RuleFor(v => v.KRV116).MaximumLength(150);
            RuleFor(v => v.KRV117).MaximumLength(150);
            RuleFor(v => v.KRV118).MaximumLength(150);
            RuleFor(v => v.KRV119).MaximumLength(150);
            RuleFor(v => v.KRV120).MaximumLength(150);
            RuleFor(v => v.KRV121).MaximumLength(150);
            RuleFor(v => v.KRV122).MaximumLength(150);
            RuleFor(v => v.KRV123).MaximumLength(150);
            RuleFor(v => v.KRV124).MaximumLength(150);
            RuleFor(v => v.KRV125).MaximumLength(150);
            RuleFor(v => v.KRV126).MaximumLength(150);
            RuleFor(v => v.KRV127).MaximumLength(150);
            RuleFor(v => v.KRV128).MaximumLength(150);
            RuleFor(v => v.KRV129).MaximumLength(150);
            RuleFor(v => v.KRV130).MaximumLength(150);
            RuleFor(v => v.KRV132).MaximumLength(150);
            RuleFor(v => v.KRV134).MaximumLength(150);
            RuleFor(v => v.KRV135).MaximumLength(150);
            RuleFor(v => v.KRV136).MaximumLength(150);
            RuleFor(v => v.KRV138).MaximumLength(150);
            RuleFor(v => v.KRV141).MaximumLength(150);
            RuleFor(v => v.KRV143).MaximumLength(150);
            RuleFor(v => v.KRV145).MaximumLength(150);
            RuleFor(v => v.KRV147).MaximumLength(150);
            RuleFor(v => v.KRV149).MaximumLength(150);
            RuleFor(v => v.KRV151).MaximumLength(150);
            RuleFor(v => v.KRV153).MaximumLength(150);
            RuleFor(v => v.KRV155).MaximumLength(150);
            RuleFor(v => v.KRV156).MaximumLength(150);
            RuleFor(v => v.KRV158).MaximumLength(150);
            RuleFor(v => v.KRV159).MaximumLength(150);
            RuleFor(v => v.KRV161).MaximumLength(150);
            RuleFor(v => v.KRV162).MaximumLength(150);
            RuleFor(v => v.KRV164).MaximumLength(150);
            RuleFor(v => v.KRV165).MaximumLength(150);
            RuleFor(v => v.KRV167).MaximumLength(150);
            RuleFor(v => v.KRV168).MaximumLength(150);
            RuleFor(v => v.KRV169).MaximumLength(150);
            RuleFor(v => v.KRV171).MaximumLength(150);
            RuleFor(v => v.KRV172).MaximumLength(150);
            RuleFor(v => v.KRV173).MaximumLength(150);
            RuleFor(v => v.KRV174).MaximumLength(150);
            RuleFor(v => v.KRV204).MaximumLength(150);
            RuleFor(v => v.KRV205).MaximumLength(150);
            RuleFor(v => v.KRV206).MaximumLength(150);
            RuleFor(v => v.KRV207).MaximumLength(150);
            RuleFor(v => v.KRV209).MaximumLength(150);
            RuleFor(v => v.KRV214).MaximumLength(150);
            RuleFor(v => v.KRV215).MaximumLength(150);
            RuleFor(v => v.KRV216).MaximumLength(150);
            RuleFor(v => v.KRV217).MaximumLength(150);
            RuleFor(v => v.KRV219).MaximumLength(150);
            RuleFor(v => v.KRV229).MaximumLength(150);
            RuleFor(v => v.KRV239).MaximumLength(150);
            RuleFor(v => v.KRV249).MaximumLength(150);
            RuleFor(v => v.KRV259).MaximumLength(150);
            RuleFor(v => v.KRV260).MaximumLength(150);
            RuleFor(v => v.KRV261).MaximumLength(150);
            RuleFor(v => v.KRV262).MaximumLength(150);
            RuleFor(v => v.KRV263).MaximumLength(150);
            RuleFor(v => v.KRV264).MaximumLength(150);
            RuleFor(v => v.KRV177).MaximumLength(150);
            RuleFor(v => v.KRV178).MaximumLength(150);
            RuleFor(v => v.KRV180).MaximumLength(150);
            RuleFor(v => v.KRV181).MaximumLength(150);
            RuleFor(v => v.KRV300).MaximumLength(150);
            RuleFor(v => v.KRV301).MaximumLength(150);
            RuleFor(v => v.KRV306).MaximumLength(150);
            RuleFor(v => v.KRV307).MaximumLength(150);
            RuleFor(v => v.KRV308).MaximumLength(150);
            RuleFor(v => v.KRV309).MaximumLength(150);
            RuleFor(v => v.KRV314).MaximumLength(150);
            RuleFor(v => v.KRV315).MaximumLength(150);
            RuleFor(v => v.KRV316).MaximumLength(150);
            RuleFor(v => v.KRV317).MaximumLength(150);
            RuleFor(v => v.KRV324).MaximumLength(150);
            RuleFor(v => v.KRV325).MaximumLength(150);
            RuleFor(v => v.KRV326).MaximumLength(150);
            RuleFor(v => v.KRV327).MaximumLength(150);
            RuleFor(v => v.KRV333).MaximumLength(150);
            RuleFor(v => v.KRV334).MaximumLength(150);
            RuleFor(v => v.KRV335).MaximumLength(150);
            RuleFor(v => v.KRV336).MaximumLength(150);
            RuleFor(v => v.KRV337).MaximumLength(150);
            RuleFor(v => v.KRV343).MaximumLength(150);
            RuleFor(v => v.KRV344).MaximumLength(150);
            RuleFor(v => v.KRV345).MaximumLength(150);
            RuleFor(v => v.KRV346).MaximumLength(150);
            RuleFor(v => v.KRV347).MaximumLength(150);
        }
    }
}