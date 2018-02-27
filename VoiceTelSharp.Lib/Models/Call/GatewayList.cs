// Copyright (c) 2018 Initial Servers LLC. All rights reserved.
// https://initialservers.com/

using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace VoiceTelSharp.Lib.Models.Call
{
    public class Gateway
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("ip")] public string Ip { get; set; }
    }

    [Description("https://api.voicetel.com/gatewayList/[api_key]/")]
    public class GatewayList
    {
        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("gateways")] public IList<Gateway> Gateways { get; set; }
    }
}