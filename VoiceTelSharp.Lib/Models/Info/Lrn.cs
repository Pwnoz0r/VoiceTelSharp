// Copyright (c) 2018 Initial Servers LLC. All rights reserved.
// https://initialservers.com/

using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace VoiceTelSharp.Lib.Models.Info
{
    public class LrnObject
    {
        [JsonProperty("LRN")] public string Lrn { get; set; }

        [JsonProperty("OCN")] public string Ocn { get; set; }

        [JsonProperty("LATA")] public string Lata { get; set; }

        [JsonProperty("CITY")] public string City { get; set; }

        [JsonProperty("STATE")] public string State { get; set; }

        [JsonProperty("JURISDICTION")] public string Jurisdiction { get; set; }

        [JsonProperty("LEC")] public string Lec { get; set; }
    }

    [Description("https://api.voicetel.com/lrn/[destination_number]/[caller_number]/[api_key]/")]
    public class Lrn
    {
        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("lrn")] public IList<Lrn> LrnObjects { get; set; }
    }
}