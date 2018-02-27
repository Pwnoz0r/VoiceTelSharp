// Copyright (c) 2018 Initial Servers LLC. All rights reserved.
// https://initialservers.com/

using System.ComponentModel;
using Newtonsoft.Json;

namespace VoiceTelSharp.Lib.Models.Call
{
    [Description("https://api.voicetel.com/gatewayAdd/[ip_address]/[api_key]/")]
    public class GatewayAdd
    {
        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("Message")] public string Message { get; set; }
    }
}