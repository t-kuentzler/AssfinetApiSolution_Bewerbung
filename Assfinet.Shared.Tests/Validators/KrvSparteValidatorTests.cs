using Assfinet.Shared.Entities;
using Assfinet.Shared.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace Assfinet.Shared.Tests.Validators
{
    public class KrvSparteValidatorTests
    {
        private readonly KrvSparteValidator _validator;

        public KrvSparteValidatorTests()
        {
            _validator = new KrvSparteValidator();
        }

        [Fact]
        public void Should_Have_Error_When_AmsId_Is_Empty()
        {
            var model = new KrvSparte { AmsId = Guid.Empty };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(s => s.AmsId);
        }

        [Fact]
        public void Should_Have_Error_When_Amsidnr_Exceeds_Max_Length()
        {
            var model = new KrvSparte { Amsidnr = new string('A', 41) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(s => s.Amsidnr);
        }

        [Fact]
        public void Should_Have_Error_When_Key_Exceeds_Max_Length()
        {
            var model = new KrvSparte { Key = new string('A', 41) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(s => s.Key);
        }

        [Fact]
        public void Should_Have_Error_When_Typ_Exceeds_Max_Length()
        {
            var model = new KrvSparte { Typ = new string('A', 51) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(s => s.Typ);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Krv101_Is_Valid()
        {
            var model = new KrvSparte { KRV101 = new string('A', 150) };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(s => s.KRV101);
        }

        //Nur erste KRV Eigenschaft testen, da alle die selben regeln haben
        [Fact]
        public void Should_Have_Error_When_Krv101_Exceeds_Max_Length()
        {
            var model = new KrvSparte { KRV101 = new string('A', 151) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(s => s.KRV101);
        }
    }
}
