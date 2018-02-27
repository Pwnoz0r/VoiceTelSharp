// Copyright (c) 2018 Initial Servers LLC. All rights reserved.
// https://initialservers.com/

using System.ComponentModel;
using Newtonsoft.Json;

namespace VoiceTelSharp.Lib.Models.Info
{
    public class PortableNumbers
    {
        [JsonProperty("Tn")] public string Tn { get; set; }
    }

    public class Tiers
    {
        [JsonProperty("Tier")] public string Tier { get; set; }
    }

    public class TnList
    {
        [JsonProperty("Tn")] public string Tn { get; set; }
    }

    public class RateCenterGroup
    {
        [JsonProperty("RateCenter")] public string RateCenter { get; set; }

        [JsonProperty("City")] public string City { get; set; }

        [JsonProperty("State")] public string State { get; set; }

        [JsonProperty("LATA")] public string Lata { get; set; }

        [JsonProperty("Tiers")] public Tiers Tiers { get; set; }

        [JsonProperty("TnList")] public TnList TnList { get; set; }
    }

    public class SupportedRateCenters
    {
        [JsonProperty("RateCenterGroup")] public RateCenterGroup RateCenterGroup { get; set; }
    }

    public class UnsupportedRateCenters
    {
    }

    public class LosingCarrierTnList
    {
        [JsonProperty("LosingCarrierSPID")] public string LosingCarrierSpid { get; set; }

        [JsonProperty("LosingCarrierName")] public string LosingCarrierName { get; set; }

        [JsonProperty("LosingCarrierIsWireless")]
        public string LosingCarrierIsWireless { get; set; }

        [JsonProperty("LosingCarrierAccountNumberRequired")]
        public string LosingCarrierAccountNumberRequired { get; set; }

        [JsonProperty("LosingCarrierMinimumPortingInterval")]
        public string LosingCarrierMinimumPortingInterval { get; set; }

        [JsonProperty("TnList")] public TnList TnList { get; set; }
    }

    public class SupportedLosingCarriers
    {
        [JsonProperty("LosingCarrierTnList")] public LosingCarrierTnList LosingCarrierTnList { get; set; }
    }

    public class LnpObject
    {
        [JsonProperty("PortType")] public string PortType { get; set; }

        [JsonProperty("PortableNumbers")] public PortableNumbers PortableNumbers { get; set; }

        [JsonProperty("SupportedRateCenters")] public SupportedRateCenters SupportedRateCenters { get; set; }

        [JsonProperty("UnsupportedRateCenters")]
        public UnsupportedRateCenters UnsupportedRateCenters { get; set; }

        [JsonProperty("SupportedLosingCarriers")]
        public SupportedLosingCarriers SupportedLosingCarriers { get; set; }
    }

    [Description("https://api.voicetel.com/lnp/[phone_number]/[api_key]/")]
    public class Lnp
    {
        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("lnp")] public LnpObject LnpObject { get; set; }
    }
}