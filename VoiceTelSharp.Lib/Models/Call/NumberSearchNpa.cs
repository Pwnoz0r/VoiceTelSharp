// Copyright (c) 2018 Initial Servers LLC. All rights reserved.
// https://initialservers.com/

using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace VoiceTelSharp.Lib.Models.Call
{
    public class RateCenter
    {
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("lata")] public string Lata { get; set; }

        [JsonProperty("state")] public string State { get; set; }
    }

    public class TelephoneNumber
    {
        [JsonProperty("numberID")] public string NumberId { get; set; }

        [JsonProperty("tenDigit")] public string TenDigit { get; set; }

        [JsonProperty("formattedNumber")] public string FormattedNumber { get; set; }

        [JsonProperty("e164")] public string E164 { get; set; }

        [JsonProperty("npaNxx")] public string NpaNxx { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("rateCenter")] public RateCenter RateCenter { get; set; }
    }

    public class Numbers
    {
        [JsonProperty("telephoneNumber")] public IList<TelephoneNumber> TelephoneNumber { get; set; }
    }

    [Description("https://api.voicetel.com/numberSearchNPA/[NPA]/[api_key]/")]
    public class NumberSearchNpa
    {
        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("numbers")] public Numbers Numbers { get; set; }
    }
}