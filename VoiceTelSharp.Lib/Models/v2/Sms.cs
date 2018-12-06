// Copyright (c) 2018 Initial Servers LLC. All rights reserved.
// https://initialservers.com/

using Newtonsoft.Json;

namespace VoiceTelSharp.Lib.Models.v2
{
    public class Sms
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public Message Message { get; set; }
    }

    public class Message
    {
        [JsonProperty("transaction", NullValueHandling = NullValueHandling.Ignore)]
        public Transaction Transaction { get; set; }
    }

    public class Transaction
    {
        [JsonProperty("transactionGUID", NullValueHandling = NullValueHandling.Ignore)]
        public string TransactionGuid { get; set; }

        [JsonProperty("destination", NullValueHandling = NullValueHandling.Ignore)]
        public string Destination { get; set; }
    }
}