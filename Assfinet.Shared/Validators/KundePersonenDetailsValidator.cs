using FluentValidation;
using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Validators
{
    public class KundePersonenDetailsValidator : AbstractValidator<KundePersonenDetails>
    {
        public KundePersonenDetailsValidator()
        {
            RuleFor(k => k.Anrede)
                .MaximumLength(70);

            RuleFor(k => k.Arbeitgeber)
                .MaximumLength(15);

            RuleFor(k => k.AusbildungskostenMonatlich)
                .GreaterThanOrEqualTo(0).When(k => k.AusbildungskostenMonatlich.HasValue);

            RuleFor(k => k.Beruf)
                .MaximumLength(60);

            RuleFor(k => k.Berufsstatus)
                .MaximumLength(40);

            RuleFor(k => k.Besitzverhaeltnis)
                .MaximumLength(50);

            RuleFor(k => k.Bilanzstichtag)
                .MaximumLength(10);

            RuleFor(k => k.Branche)
                .MaximumLength(600);

            RuleFor(k => k.Bruttojahresmietwert)
                .GreaterThanOrEqualTo(0).When(k => k.Bruttojahresmietwert.HasValue);

            RuleFor(k => k.Bruttojahresumsatz)
                .GreaterThanOrEqualTo(0).When(k => k.Bruttojahresumsatz.HasValue);

            RuleFor(k => k.Bundesland)
                .MaximumLength(25);

            RuleFor(k => k.Familienstand)
                .MaximumLength(30);

            RuleFor(k => k.Geburtsname)
                .MaximumLength(200);

            RuleFor(k => k.Geburtsort)
                .MaximumLength(32);

            RuleFor(k => k.Geschlecht)
                .MaximumLength(10);

            RuleFor(k => k.GVersicherer1)
                .MaximumLength(50);

            RuleFor(k => k.GVersicherer2)
                .MaximumLength(50);

            RuleFor(k => k.GVersicherer3)
                .MaximumLength(50);

            RuleFor(k => k.GVersicherer4)
                .MaximumLength(50);

            RuleFor(k => k.GVersicherer5)
                .MaximumLength(50);

            RuleFor(k => k.Handelsregisternummer)
                .MaximumLength(100);

            RuleFor(k => k.HistorieZuKunde)
                .MaximumLength(40);

            RuleFor(k => k.IdentTyp)
                .MaximumLength(30);

            RuleFor(k => k.Inflationsrate)
                .GreaterThanOrEqualTo(0).When(k => k.Inflationsrate.HasValue);

            RuleFor(k => k.Info_01)
                .MaximumLength(20);

            RuleFor(k => k.Informationsweg)
                .MaximumLength(30);

            RuleFor(k => k.InhaberGF)
                .MaximumLength(100);

            RuleFor(k => k.InterneNr)
                .MaximumLength(15);

            RuleFor(k => k.IsoLand)
                .MaximumLength(3);

            RuleFor(k => k.KeyIdentDate)
                .MaximumLength(40);

            RuleFor(k => k.Kindergeldnummer)
                .MaximumLength(20);

            RuleFor(k => k.KinderLautSteuerkarte)
                .GreaterThanOrEqualTo(0).When(k => k.KinderLautSteuerkarte.HasValue);

            RuleFor(k => k.Klasse)
                .MaximumLength(5);

            RuleFor(k => k.Sozialversicherungsnummer)
                .MaximumLength(12);

            RuleFor(k => k.Staatsangehoerigkeit)
                .MaximumLength(3);

            RuleFor(k => k.Status)
                .MaximumLength(15);

            RuleFor(k => k.SteuerIdentifikationsnummer)
                .MaximumLength(15);

            RuleFor(k => k.Steuerklasse)
                .MaximumLength(10);

            RuleFor(k => k.Steuernummer)
                .MaximumLength(20);

            RuleFor(k => k.Vorname)
                .MaximumLength(40);

            RuleFor(k => k.Zuordnung)
                .NotEmpty();
        }
    }
}
