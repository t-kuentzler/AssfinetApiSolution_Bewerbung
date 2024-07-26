using FluentValidation;
using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Validators
{
    public class KundeValidator : AbstractValidator<Kunde>
    {
        public KundeValidator()
        {
            RuleFor(k => k.Adrid).MaximumLength(40);
            RuleFor(k => k.Aenderungsgrund).MaximumLength(100);
            RuleFor(k => k.Amsidnr).MaximumLength(40);
            RuleFor(k => k.Bearbeiter).MaximumLength(40);
            RuleFor(k => k.BelegteSparten).MaximumLength(200);
            RuleFor(k => k.Debitor).MaximumLength(11);
            RuleFor(k => k.DtazvEntgelt).MaximumLength(20);
            RuleFor(k => k.EloGid).MaximumLength(40);
            RuleFor(k => k.GTarif1).MaximumLength(50);
            RuleFor(k => k.GTarif2).MaximumLength(50);
            RuleFor(k => k.GTarif3).MaximumLength(50);
            RuleFor(k => k.GTarif4).MaximumLength(50);
            RuleFor(k => k.GTarif5).MaximumLength(50);
            RuleFor(k => k.GVstAbzug).MaximumLength(10);
            RuleFor(k => k.Handelsregisternummer).MaximumLength(100);
            RuleFor(k => k.IdentTyp).MaximumLength(30);
            RuleFor(k => k.LageBetriebsgrundstuecks).MaximumLength(50);
            RuleFor(k => k.Land).MaximumLength(3);
            RuleFor(k => k.Landesname).MaximumLength(50);
            RuleFor(k => k.Mandant).MaximumLength(50);
            RuleFor(k => k.MandantAmsidnr).MaximumLength(40);
            RuleFor(k => k.Mobiltelefon).MaximumLength(35);
            RuleFor(k => k.Name).MaximumLength(40);
            RuleFor(k => k.Name1).MaximumLength(200);
            RuleFor(k => k.Name2).MaximumLength(200);
            RuleFor(k => k.Name3).MaximumLength(200);
            RuleFor(k => k.Ort).MaximumLength(50);
            RuleFor(k => k.OrtPhonetisch).MaximumLength(50);
            RuleFor(k => k.PAusbildung).MaximumLength(30);
            RuleFor(k => k.PBeschaeftignungsverhaeltnis).MaximumLength(20);
            RuleFor(k => k.PBildung).MaximumLength(100);
            RuleFor(k => k.PersonalausweisBehoerde).MaximumLength(30);
            RuleFor(k => k.PersonalausweisNr).MaximumLength(30);
            RuleFor(k => k.Personalnummer).MaximumLength(20);
            RuleFor(k => k.PFsbehoerde).MaximumLength(30);
            RuleFor(k => k.PFsnummer).MaximumLength(20);
            RuleFor(k => k.Titel).MaximumLength(20);
            RuleFor(k => k.UmsatzJahr).MaximumLength(4);
            RuleFor(k => k.USTIDNr).MaximumLength(20);
            RuleFor(k => k.Vm1).MaximumLength(50);
            RuleFor(k => k.Vm10).MaximumLength(50);
            RuleFor(k => k.Vm2).MaximumLength(50);
            RuleFor(k => k.Vm3).MaximumLength(50);
            RuleFor(k => k.Vm4).MaximumLength(50);
            RuleFor(k => k.Vm5).MaximumLength(50);
            RuleFor(k => k.Vm6).MaximumLength(50);
            RuleFor(k => k.Vm7).MaximumLength(50);
            RuleFor(k => k.Vm8).MaximumLength(50);
            RuleFor(k => k.Vm9).MaximumLength(50);
            RuleFor(k => k.VnMvertrag).MaximumLength(40);
            RuleFor(k => k.Vnnummer).MaximumLength(15);
            RuleFor(k => k.Sachbearbeiter).MaximumLength(40);
            RuleFor(k => k.Schlagwoerter).MaximumLength(250);
            RuleFor(k => k.Strasse).MaximumLength(50);
            RuleFor(k => k.StrassePhonetisch).MaximumLength(50);
            RuleFor(k => k.Sepamandatsreferenz).MaximumLength(35);
            RuleFor(k => k.SepaSddType).MaximumLength(30);
            RuleFor(k => k.Kundenname).MaximumLength(200);
            RuleFor(k => k.KundennamePhonetisch).MaximumLength(200);
            RuleFor(k => k.Kundentyp).MaximumLength(200);
            RuleFor(k => k.Kundenverbindung).MaximumLength(20);
            RuleFor(k => k.Partner).MaximumLength(15);
            RuleFor(k => k.Finanzamt).MaximumLength(30);
            RuleFor(k => k.GBetriebsart).MaximumLength(100);
            RuleFor(k => k.Plz).MaximumLength(7);
            RuleFor(k => k.Kindergeldnummer).MaximumLength(20);
            RuleFor(k => k.Konto1).MaximumLength(12);
            RuleFor(k => k.Konto2).MaximumLength(12);
            RuleFor(k => k.Kontobezeichnung1).MaximumLength(100);
            RuleFor(k => k.Kontobezeichnung2).MaximumLength(100);
            RuleFor(k => k.Kontoinhaber1).MaximumLength(40);
            RuleFor(k => k.Kontoinhaber2).MaximumLength(40);
            
            RuleFor(kunde => kunde.PersonenDetails)
                .SetValidator(new KundePersonenDetailsValidator());
            
            RuleFor(kunde => kunde.Finanzen)
                .SetValidator(new KundeFinanzenValidator());
            
            RuleFor(kunde => kunde.Kontakt)
                .SetValidator(new KundeKontaktValidator());
        }
    }
}
