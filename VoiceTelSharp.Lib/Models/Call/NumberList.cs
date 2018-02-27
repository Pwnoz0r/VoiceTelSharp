// Copyright (c) 2018 Initial Servers LLC. All rights reserved.
// https://initialservers.com/

using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace VoiceTelSharp.Lib.Models.Call
{
    public class Number
    {
        [JsonProperty("number")] public string Num { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("ip")] public string Ip { get; set; }
    }

    [Description("https://api.voicetel.com/numberList/[api_key]/")]
    public class NumberList
    {
        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("numbers")] public IList<Number> Numbers { get; set; }
    }
}