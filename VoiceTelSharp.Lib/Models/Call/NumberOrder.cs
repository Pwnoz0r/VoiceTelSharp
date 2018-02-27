// Copyright (c) 2018 Initial Servers LLC. All rights reserved.
// https://initialservers.com/

using System.ComponentModel;
using Newtonsoft.Json;

namespace VoiceTelSharp.Lib.Models.Call
{
    [Description("https://api.voicetel.com/numberOrder/[numberID]/[api_key]/")]
    public class NumberOrder
    {
        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("message")] public string Message { get; set; }
    }
}