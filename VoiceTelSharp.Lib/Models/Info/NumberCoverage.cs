// Copyright (c) 2018 Initial Servers LLC. All rights reserved.
// https://initialservers.com/

using System.ComponentModel;
using Newtonsoft.Json;

namespace VoiceTelSharp.Lib.Models.Info
{
    [Description("https://api.voicetel.com/numberCoverage/[NPA]/[api_key]/")]
    public class NumberCoverage
    {
        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("coverage")] public int Coverage { get; set; }
    }
}