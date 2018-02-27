// Copyright (c) 2018 Initial Servers LLC. All rights reserved.
// https://initialservers.com/

using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace VoiceTelSharp.Lib.Models.Account
{
    public class Account
    {
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("cash")] public string Cash { get; set; }

        [JsonProperty("rate")] public string Rate { get; set; }

        [JsonProperty("username")] public string Username { get; set; }

        [JsonProperty("created")] public string Created { get; set; }

        [JsonProperty("email")] public string Email { get; set; }

        [JsonProperty("enabled")] public string Enabled { get; set; }

        [JsonProperty("caller_id")] public object CallerId { get; set; }

        [JsonProperty("notify")] public string Notify { get; set; }

        [JsonProperty("notify_threshold")] public string NotifyThreshold { get; set; }
    }

    [Description("https://api.voicetel.com/accountInfo/[api_key]/")]
    public class AccountInfo
    {
        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("account")] public IList<Account> Accounts { get; set; }
    }
}