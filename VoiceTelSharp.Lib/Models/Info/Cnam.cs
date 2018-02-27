// Copyright (c) 2018 Initial Servers LLC. All rights reserved.
// https://initialservers.com/

using System.ComponentModel;
using Newtonsoft.Json;

namespace VoiceTelSharp.Lib.Models.Info
{
    [Description("https://api.voicetel.com/cnam/[phone_number]/[api_key]/")]
    public class Cnam
    {
        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("cnam")] public string Response { get; set; }
    }
}