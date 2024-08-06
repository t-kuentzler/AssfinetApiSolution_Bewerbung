using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assfinet.Shared.Entities;

public class UnfSparteTeil1
{
    public int Id { get; set; }

    [Required] public Guid AmsId { get; set; }

    public DateTimeOffset? Bearbeitet { get; set; }

    [Required] [StringLength(40)] public string Amsidnr { get; set; }

    [Required] [StringLength(40)] public string Key { get; set; }

    [Required] [StringLength(50)] public string Typ { get; set; }

    [NotMapped] [JsonExtensionData] public IDictionary<string, JToken> AdditionalData { get; set; }

    public bool Dirty { get; set; }

    [StringLength(40)] public string? License { get; set; }

    public DateTime? LastSynchronisation { get; set; }

    [StringLength(150)] public string? UNF101 { get; set; }
    [StringLength(150)] public string? UNF102 { get; set; }
    [StringLength(150)] public string? UNF104 { get; set; }
    [StringLength(150)] public string? UNF105 { get; set; }
    [StringLength(150)] public string? UNF106 { get; set; }
    [StringLength(150)] public string? UNF107 { get; set; }
    [StringLength(150)] public string? UNF108 { get; set; }
    [StringLength(150)] public string? UNF109 { get; set; }
    [StringLength(150)] public string? UNF110 { get; set; }
    [StringLength(150)] public string? UNF111 { get; set; }
    [StringLength(150)] public string? UNF112 { get; set; }
    [StringLength(150)] public string? UNF113 { get; set; }
    [StringLength(150)] public string? UNF114 { get; set; }
    [StringLength(150)] public string? UNF115 { get; set; }
    [StringLength(150)] public string? UNF116 { get; set; }
    [StringLength(150)] public string? UNF117 { get; set; }
    [StringLength(150)] public string? UNF118 { get; set; }
    [StringLength(150)] public string? UNF119 { get; set; }
    [StringLength(150)] public string? UNF120 { get; set; }
    [StringLength(150)] public string? UNF125 { get; set; }
    [StringLength(150)] public string? UNF126 { get; set; }
    [StringLength(150)] public string? UNF127 { get; set; }
    [StringLength(150)] public string? UNF128 { get; set; }
    [StringLength(150)] public string? UNF129 { get; set; }
    [StringLength(150)] public string? UNF130 { get; set; }
    [StringLength(150)] public string? UNF134 { get; set; }
    [StringLength(150)] public string? UNF135 { get; set; }
    [StringLength(150)] public string? UNF136 { get; set; }
    [StringLength(150)] public string? UNF137 { get; set; }
    [StringLength(150)] public string? UNF138 { get; set; }
    [StringLength(150)] public string? UNF139 { get; set; }
    [StringLength(150)] public string? UNF140 { get; set; }
    [StringLength(150)] public string? UNF141 { get; set; }
    [StringLength(150)] public string? UNF142 { get; set; }
    [StringLength(150)] public string? UNF143 { get; set; }
    [StringLength(150)] public string? UNF144 { get; set; }
    [StringLength(150)] public string? UNF145 { get; set; }
    [StringLength(150)] public string? UNF146 { get; set; }
    [StringLength(150)] public string? UNF147 { get; set; }
    [StringLength(150)] public string? UNF148 { get; set; }
    [StringLength(150)] public string? UNF149 { get; set; }
    [StringLength(150)] public string? UNF150 { get; set; }
    [StringLength(150)] public string? UNF151 { get; set; }
    [StringLength(150)] public string? UNF152 { get; set; }
    [StringLength(150)] public string? UNF153 { get; set; }
    [StringLength(150)] public string? UNF154 { get; set; }
    [StringLength(150)] public string? UNF155 { get; set; }
    [StringLength(150)] public string? UNF156 { get; set; }
    [StringLength(150)] public string? UNF157 { get; set; }
    [StringLength(150)] public string? UNF158 { get; set; }
    [StringLength(150)] public string? UNF160 { get; set; }
    [StringLength(150)] public string? UNF161 { get; set; }
    [StringLength(150)] public string? UNF162 { get; set; }
    [StringLength(150)] public string? UNF163 { get; set; }
    [StringLength(150)] public string? UNF172 { get; set; }
    [StringLength(150)] public string? UNF173 { get; set; }
    [StringLength(150)] public string? UNF174 { get; set; }
    [StringLength(150)] public string? UNF175 { get; set; }
    [StringLength(150)] public string? UNF176 { get; set; }
    [StringLength(150)] public string? UNF177 { get; set; }
    [StringLength(150)] public string? UNF192 { get; set; }
    [StringLength(150)] public string? UNF193 { get; set; }
    [StringLength(150)] public string? UNF194 { get; set; }
    [StringLength(150)] public string? UNF195 { get; set; }
    [StringLength(150)] public string? UNF196 { get; set; }
    [StringLength(150)] public string? UNF197 { get; set; }
    [StringLength(150)] public string? UNF198 { get; set; }
    [StringLength(150)] public string? UNF199 { get; set; }
    [StringLength(150)] public string? UNF204 { get; set; }
    [StringLength(150)] public string? UNF205 { get; set; }
    [StringLength(150)] public string? UNF206 { get; set; }
    [StringLength(150)] public string? UNF207 { get; set; }
    [StringLength(150)] public string? UNF208 { get; set; }
    [StringLength(150)] public string? UNF211 { get; set; }
    [StringLength(150)] public string? UNF212 { get; set; }
    [StringLength(150)] public string? UNF213 { get; set; }
    [StringLength(150)] public string? UNF214 { get; set; }
    [StringLength(150)] public string? UNF215 { get; set; }
    [StringLength(150)] public string? UNF216 { get; set; }
    [StringLength(150)] public string? UNF217 { get; set; }
    [StringLength(150)] public string? UNF218 { get; set; }
    [StringLength(150)] public string? UNF219 { get; set; }
    [StringLength(150)] public string? UNF220 { get; set; }
    [StringLength(150)] public string? UNF221 { get; set; }
    [StringLength(150)] public string? UNF222 { get; set; }
    [StringLength(150)] public string? UNF223 { get; set; }
    [StringLength(150)] public string? UNF224 { get; set; }
    [StringLength(150)] public string? UNF225 { get; set; }
    [StringLength(150)] public string? UNF226 { get; set; }
    [StringLength(150)] public string? UNF227 { get; set; }
    [StringLength(150)] public string? UNF228 { get; set; }
    [StringLength(150)] public string? UNF229 { get; set; }
    [StringLength(150)] public string? UNF230 { get; set; }
    [StringLength(150)] public string? UNF231 { get; set; }
    [StringLength(150)] public string? UNF232 { get; set; }
    [StringLength(150)] public string? UNF233 { get; set; }
    [StringLength(150)] public string? UNF234 { get; set; }
    [StringLength(150)] public string? UNF235 { get; set; }
    [StringLength(150)] public string? UNF236 { get; set; }
    [StringLength(150)] public string? UNF237 { get; set; }
    [StringLength(150)] public string? UNF238 { get; set; }
    [StringLength(150)] public string? UNF239 { get; set; }
    [StringLength(150)] public string? UNF240 { get; set; }
    [StringLength(150)] public string? UNF241 { get; set; }
    [StringLength(150)] public string? UNF242 { get; set; }
    [StringLength(150)] public string? UNF243 { get; set; }
    [StringLength(150)] public string? UNF244 { get; set; }
    [StringLength(150)] public string? UNF245 { get; set; }
    [StringLength(150)] public string? UNF265 { get; set; }
    [StringLength(150)] public string? UNF266 { get; set; }
    [StringLength(150)] public string? UNF267 { get; set; }
    [StringLength(150)] public string? UNF268 { get; set; }
    [StringLength(150)] public string? UNF269 { get; set; }
    [StringLength(150)] public string? UNF270 { get; set; }
    [StringLength(150)] public string? UNF271 { get; set; }
    [StringLength(150)] public string? UNF272 { get; set; }
    [StringLength(150)] public string? UNF273 { get; set; }
    [StringLength(150)] public string? UNF274 { get; set; }
    [StringLength(150)] public string? UNF275 { get; set; }
    [StringLength(150)] public string? UNF276 { get; set; }
    [StringLength(150)] public string? UNF277 { get; set; }
    [StringLength(150)] public string? UNF278 { get; set; }
    [StringLength(150)] public string? UNF279 { get; set; }
    [StringLength(150)] public string? UNF280 { get; set; }
    [StringLength(150)] public string? UNF281 { get; set; }
    [StringLength(150)] public string? UNF282 { get; set; }
    [StringLength(150)] public string? UNF283 { get; set; }
    [StringLength(150)] public string? UNF284 { get; set; }
    [StringLength(150)] public string? UNF285 { get; set; }
    [StringLength(150)] public string? UNF286 { get; set; }
    [StringLength(150)] public string? UNF287 { get; set; }
    [StringLength(150)] public string? UNF288 { get; set; }
    [StringLength(150)] public string? UNF289 { get; set; }
    [StringLength(150)] public string? UNF290 { get; set; }
    [StringLength(150)] public string? UNF291 { get; set; }
    [StringLength(150)] public string? UNF292 { get; set; }
    [StringLength(150)] public string? UNF293 { get; set; }
    [StringLength(150)] public string? UNF294 { get; set; }
    [StringLength(150)] public string? UNF295 { get; set; }
    [StringLength(150)] public string? UNF296 { get; set; }
    [StringLength(150)] public string? UNF297 { get; set; }
    [StringLength(150)] public string? UNF298 { get; set; }
    [StringLength(150)] public string? UNF299 { get; set; }
    [StringLength(150)] public string? UNF300 { get; set; }
    [StringLength(150)] public string? UNF301 { get; set; }
    [StringLength(150)] public string? UNF302 { get; set; }
    [StringLength(150)] public string? UNF303 { get; set; }
    [StringLength(150)] public string? UNF304 { get; set; }
    [StringLength(150)] public string? UNF305 { get; set; }
    [StringLength(150)] public string? UNF306 { get; set; }
    [StringLength(150)] public string? UNF307 { get; set; }
    [StringLength(150)] public string? UNF308 { get; set; }
    [StringLength(150)] public string? UNF309 { get; set; }
    [StringLength(150)] public string? UNF310 { get; set; }
    [StringLength(150)] public string? UNF311 { get; set; }
    [StringLength(150)] public string? UNF312 { get; set; }
    [StringLength(150)] public string? UNF313 { get; set; }
    [StringLength(150)] public string? UNF314 { get; set; }
    [StringLength(150)] public string? UNF315 { get; set; }
    [StringLength(150)] public string? UNF316 { get; set; }
    [StringLength(150)] public string? UNF317 { get; set; }
    [StringLength(150)] public string? UNF318 { get; set; }
    [StringLength(150)] public string? UNF319 { get; set; }
    [StringLength(150)] public string? UNF320 { get; set; }
    [StringLength(150)] public string? UNF321 { get; set; }
    [StringLength(150)] public string? UNF322 { get; set; }
    [StringLength(150)] public string? UNF323 { get; set; }
    [StringLength(150)] public string? UNF326 { get; set; }
    [StringLength(150)] public string? UNF327 { get; set; }
    [StringLength(150)] public string? UNF328 { get; set; }
    [StringLength(150)] public string? UNF329 { get; set; }
    [StringLength(150)] public string? UNF330 { get; set; }
    [StringLength(150)] public string? UNF331 { get; set; }
    [StringLength(150)] public string? UNF332 { get; set; }
    [StringLength(150)] public string? UNF333 { get; set; }
    [StringLength(150)] public string? UNF334 { get; set; }
    [StringLength(150)] public string? UNF335 { get; set; }
    [StringLength(150)] public string? UNF336 { get; set; }
    [StringLength(150)] public string? UNF337 { get; set; }
    [StringLength(150)] public string? UNF338 { get; set; }
    [StringLength(150)] public string? UNF339 { get; set; }
    [StringLength(150)] public string? UNF340 { get; set; }
    [StringLength(150)] public string? UNF341 { get; set; }
    [StringLength(150)] public string? UNF342 { get; set; }
    [StringLength(150)] public string? UNF343 { get; set; }
    [StringLength(150)] public string? UNF344 { get; set; }
    [StringLength(150)] public string? UNF345 { get; set; }
    
    public virtual UnfSparteTeil2 UnfSparteTeil2 { get; set; }
}