// Copyright (c) 2018 Initial Servers LLC. All rights reserved.
// https://initialservers.com/

using System.ComponentModel;
using Newtonsoft.Json;

namespace VoiceTelSharp.Lib.Models.Sms
{
    [Description(
        "https://api.voicetel.com/groupsms/[destination_number]-[dst_#2]-[dst_#3]/[caller_number]/[message]/[api_key]/")]
    public class GroupSms
    {
        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("message")] public string Message { get; set; }

        [JsonProperty("Number")] public string Number { get; set; }
    }
}