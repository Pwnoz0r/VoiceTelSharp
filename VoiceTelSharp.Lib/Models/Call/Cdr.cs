// Copyright (c) 2018 Initial Servers LLC. All rights reserved.
// https://initialservers.com/

using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace VoiceTelSharp.Lib.Models.Call
{
    public class Value
    {
        [JsonProperty("cid")] public string Cid { get; set; }

        [JsonProperty("dst")] public string Dst { get; set; }

        [JsonProperty("ip")] public string Ip { get; set; }

        [JsonProperty("dur")] public string Dur { get; set; }

        [JsonProperty("nr")] public string Nr { get; set; }

        [JsonProperty("ba")] public string Ba { get; set; }

        [JsonProperty("cn")] public string Cn { get; set; }

        [JsonProperty("qp")] public string Qp { get; set; }
    }

    public class CdrObject
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("key")] public IList<string> Key { get; set; }

        [JsonProperty("value")] public Value Value { get; set; }
    }

    [Description("https://api.voicetel.com/cdr/[start_timestamp]/[end_timestamp]/[api_key]/")]
    public class Cdr
    {
        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("cdr")] public IList<CdrObject> CdrObjects { get; set; }
    }
}