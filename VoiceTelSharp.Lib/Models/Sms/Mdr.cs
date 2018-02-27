// Copyright (c) 2018 Initial Servers LLC. All rights reserved.
// https://initialservers.com/

using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace VoiceTelSharp.Lib.Models.Sms
{
    public class Value
    {
        [JsonProperty("number")] public string Number { get; set; }

        [JsonProperty("message")] public string Message { get; set; }

        [JsonProperty("rate")] public string Rate { get; set; }

        [JsonProperty("ip")] public string Ip { get; set; }

        [JsonProperty("direction")] public string Direction { get; set; }
    }

    public class MdrObject
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("key")] public IList<string> Key { get; set; }

        [JsonProperty("value")] public Value Value { get; set; }
    }

    [Description("https://api.voicetel.com/mdr/[start_timestamp]/[end_timestamp]/[phone_number]/[api_key]/")]
    public class Mdr
    {
        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("mdr")] public IList<MdrObject> MdrObjects { get; set; }
    }
}