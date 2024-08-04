using Assfinet.Shared.Entities;
using Assfinet.Shared.Validators;
using FluentValidation.TestHelper;

namespace Assfinet.Shared.Tests.Validators
{
    public class DepSparteValidatorTests
    {
        private readonly DepSparteValidator _validator;

        public DepSparteValidatorTests()
        {
            _validator = new DepSparteValidator();
        }

        [Fact]
        public void Should_Have_Error_When_AmsId_Is_Empty()
        {
            var model = new DepSparte { AmsId = Guid.Empty };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.AmsId);
        }

        [Fact]
        public void Should_Have_Error_When_Amsidnr_Is_Empty()
        {
            var model = new DepSparte { Amsidnr = string.Empty };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Amsidnr);
        }

        [Fact]
        public void Should_Have_Error_When_Amsidnr_Exceeds_MaxLength()
        {
            var model = new DepSparte { Amsidnr = new string('a', 41) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Amsidnr);
        }

        [Fact]
        public void Should_Have_Error_When_Key_Is_Empty()
        {
            var model = new DepSparte { Key = string.Empty };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Key);
        }

        [Fact]
        public void Should_Have_Error_When_Key_Exceeds_MaxLength()
        {
            var model = new DepSparte { Key = new string('a', 41) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Key);
        }

        [Fact]
        public void Should_Have_Error_When_Typ_Is_Empty()
        {
            var model = new DepSparte { Typ = string.Empty };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Typ);
        }

        [Fact]
        public void Should_Have_Error_When_Typ_Exceeds_MaxLength()
        {
            var model = new DepSparte { Typ = new string('a', 51) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Typ);
        }

        [Fact]
        public void Should_Have_Error_When_License_Exceeds_MaxLength()
        {
            var model = new DepSparte { License = new string('a', 41) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.License);
        }

        [Fact]
        public void Should_Have_Error_When_LastSynchronisation_Is_Default()
        {
            var model = new DepSparte { LastSynchronisation = default(DateTime) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.LastSynchronisation);
        }

        [Fact]
        public void Should_Have_Error_When_Dep101_Exceeds_MaxLength()
        {
            var model = new DepSparte { DEP101 = new string('a', 151) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.DEP101);
        }
    }
}