// Copyright (c) 2018 Initial Servers LLC. All rights reserved.
// https://initialservers.com/

using System.ComponentModel;
using Newtonsoft.Json;

namespace VoiceTelSharp.Lib.Models.Sms
{
    [Description("https://api.voicetel.com/sms/[destination_number]/[caller_number]/[message]/[api_key]/")]
    public class Sms
    {
        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("message")] public string Message { get; set; }
    }
}