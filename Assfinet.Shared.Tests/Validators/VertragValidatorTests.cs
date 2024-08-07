using Assfinet.Shared.Entities;
using Assfinet.Shared.Validators;
using FluentValidation.TestHelper;

namespace Assfinet.Shared.Tests.Validators
{
    public class VertragValidatorTests
    {
        private readonly VertragValidator _validator;

        public VertragValidatorTests()
        {
            _validator = new VertragValidator();
        }

        [Fact]
        public void Should_Have_Error_When_AmsId_Is_Empty()
        {
            var model = new Vertrag();
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(v => v.AmsId);
        }

        [Fact]
        public void Should_Have_Error_When_Amsidnr_Is_Empty()
        {
            var model = new Vertrag { Amsidnr = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(v => v.Amsidnr);
        }

        [Fact]
        public void Should_Have_Error_When_Amsidnr_Exceeds_MaxLength()
        {
            var model = new Vertrag { Amsidnr = new string('a', 41) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(v => v.Amsidnr);
        }

        [Fact]
        public void Should_Have_Error_When_Sparte_Exceeds_MaxLength()
        {
            var model = new Vertrag { Sparte = new string('a', 51) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(v => v.Sparte);
        }

        [Fact]
        public void Should_Have_Error_When_Details_Exceeds_MaxLength()
        {
            var model = new Vertrag { Details = new string('a', 61) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(v => v.Details);
        }

        [Fact]
        public void Should_Have_Error_When_Key_Is_Empty()
        {
            var model = new Vertrag { Key = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(v => v.Key);
        }

        [Fact]
        public void Should_Have_Error_When_Key_Exceeds_MaxLength()
        {
            var model = new Vertrag { Key = new string('a', 41) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(v => v.Key);
        }

        [Fact]
        public void Should_Have_Error_When_Vu_Exceeds_MaxLength()
        {
            var model = new Vertrag { Vu = new string('a', 81) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(v => v.Vu);
        }

        [Fact]
        public void Should_Have_Error_When_ComputedStatus_Exceeds_MaxLength()
        {
            var model = new Vertrag { ComputedStatus = new string('a', 61) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(v => v.ComputedStatus);
        }

        [Fact]
        public void Should_Have_Error_When_License_Exceeds_MaxLength()
        {
            var model = new Vertrag { License = new string('a', 41) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(v => v.License);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Properties_Are_Valid()
        {
            var model = new Vertrag
            {
                AmsId = Guid.NewGuid(),
                Amsidnr = "validAmsidnr",
                Sparte = "validSparte",
                Details = "validDetails",
                Key = "validKey",
                Vu = "validVu",
                ComputedStatus = "validComputedStatus",
                Dirty = true,
                License = "validLicense",
                VertragDetails = new VertragDetails(),
                Historie = new VertragHistorie(),
                BankDetails = new VertragBank()
            };

            var result = _validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(v => v.AmsId);
            result.ShouldNotHaveValidationErrorFor(v => v.Amsidnr);
            result.ShouldNotHaveValidationErrorFor(v => v.Sparte);
            result.ShouldNotHaveValidationErrorFor(v => v.Details);
            result.ShouldNotHaveValidationErrorFor(v => v.Key);
            result.ShouldNotHaveValidationErrorFor(v => v.Vu);
            result.ShouldNotHaveValidationErrorFor(v => v.ComputedStatus);
            result.ShouldNotHaveValidationErrorFor(v => v.Dirty);
            result.ShouldNotHaveValidationErrorFor(v => v.License);
            result.ShouldNotHaveValidationErrorFor(v => v.VertragDetails);
            result.ShouldNotHaveValidationErrorFor(v => v.Historie);
            result.ShouldNotHaveValidationErrorFor(v => v.BankDetails);
        }
    }
}