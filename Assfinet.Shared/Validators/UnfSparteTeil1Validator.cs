using Assfinet.Shared.Entities;
using FluentValidation;

namespace Assfinet.Shared.Validators
{
    public class UnfSparteTeil1Validator : AbstractValidator<UnfSparteTeil1>
    {
        public UnfSparteTeil1Validator()
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
                
            RuleFor(v => v.License)
                .MaximumLength(40);
                
            RuleFor(v => v.UNF101)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF102)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF104)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF105)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF106)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF107)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF108)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF109)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF110)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF111)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF112)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF113)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF114)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF115)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF116)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF117)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF118)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF119)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF120)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF125)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF126)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF127)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF128)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF129)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF130)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF134)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF135)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF136)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF137)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF138)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF139)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF140)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF141)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF142)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF143)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF144)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF145)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF146)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF147)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF148)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF149)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF150)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF151)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF152)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF153)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF154)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF155)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF156)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF157)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF158)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF160)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF161)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF162)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF163)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF172)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF173)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF174)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF175)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF176)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF177)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF192)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF193)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF194)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF195)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF196)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF197)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF198)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF199)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF204)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF205)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF206)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF207)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF208)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF211)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF212)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF213)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF214)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF215)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF216)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF217)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF218)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF219)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF220)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF221)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF222)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF223)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF224)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF225)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF226)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF227)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF228)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF229)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF230)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF231)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF232)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF233)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF234)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF235)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF236)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF237)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF238)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF239)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF240)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF241)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF242)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF243)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF244)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF245)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF265)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF266)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF267)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF268)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF269)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF270)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF271)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF272)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF273)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF274)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF275)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF276)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF277)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF278)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF279)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF280)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF281)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF282)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF283)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF284)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF285)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF286)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF287)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF288)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF289)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF290)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF291)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF292)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF293)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF294)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF295)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF296)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF297)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF298)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF299)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF300)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF301)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF302)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF303)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF304)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF305)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF306)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF307)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF308)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF309)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF310)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF311)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF312)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF313)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF314)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF315)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF316)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF317)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF318)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF319)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF320)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF321)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF322)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF323)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF326)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF327)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF328)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF329)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF330)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF331)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF332)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF333)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF334)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF335)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF336)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF337)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF338)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF339)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF340)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF341)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF342)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF343)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF344)
                .MaximumLength(150);
                
            RuleFor(v => v.UNF345)
                .MaximumLength(150);
                
            RuleFor(k => k.UnfSparteTeil2)
                .SetValidator(new UnfSparteTeil2Validator());
        }
    }
}
