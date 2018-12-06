// Copyright (c) 2018 Initial Servers LLC. All rights reserved.
// https://initialservers.com/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VoiceTelSharp.Lib.Controllers;
using VoiceTelSharp.Lib.Models.Account;
using VoiceTelSharp.Lib.Models.Call;
using VoiceTelSharp.Lib.Models.Info;

namespace VoiceTelSharp.Test
{
    internal class Program
    {
        private static VoiceTel VoiceTel { get; set; }
        private static string ApiKey { get; set; }

        private static async Task Main(string[] args)
        {
            await Task.Run(() => ProcessArgs(args)).ConfigureAwait(false);

            VoiceTel = new VoiceTel(ApiKey);

            #region Account

            var accountInfo = await VoiceTel.RequestAsync<AccountInfo>().ConfigureAwait(false);

            #endregion

            #region Call

            var cdr = await VoiceTel.RequestAsync<Cdr>(new Dictionary<string, string>
            {
                {"start_timestamp", $"{DateTimeOffset.Now.ToUnixTimeSeconds() - TimeSpan.FromMinutes(5).TotalSeconds}"},
                {"end_timestamp", $"{DateTimeOffset.Now.ToUnixTimeSeconds()}"}
            }).ConfigureAwait(false);

            //var gatewayAdd = await VoiceTel.RequestAsync<GatewayAdd>(new Dictionary<string, string>
            //{
            //    {"ip_address", $"{IPAddress.Parse("127.0.0.1")}"}
            //}).ConfigureAwait(false);

            var gatewayList = await VoiceTel.RequestAsync<GatewayList>().ConfigureAwait(false);

            //var gatewaySet = await VoiceTel.RequestAsync<GatewaySet>(new Dictionary<string, string>
            //{
            //    {"ID", ""},
            //    {"DID", ""}
            //}).ConfigureAwait(false);

            var numberList = await VoiceTel.RequestAsync<NumberList>().ConfigureAwait(false);

            var numberSearchNpa = await VoiceTel.RequestAsync<NumberSearchNpa>(new Dictionary<string, string>
            {
                {"NPA", "201"}
            }).ConfigureAwait(false);

            var numberSearchNpaNxx = await VoiceTel.RequestAsync<NumberSearchNpaNxx>(new Dictionary<string, string>
            {
                {"NPANXX", "201255"}
            }).ConfigureAwait(false);

            //var numberOrder = await VoiceTel.RequestAsync<NumberOrder>(new Dictionary<string, string>
            //{
            //    {"numberID", numberSearchNpaNxx.Numbers.TelephoneNumber.FirstOrDefault()?.NumberId}
            //}).ConfigureAwait(false);

            #endregion

            #region Info

            //var cnam = await VoiceTel.RequestAsync<Cnam>(new Dictionary<string, string>
            //{
            //    {"phone_number", ""}
            //}).ConfigureAwait(false);

            //var lnp = await VoiceTel.RequestAsync<Lnp>(new Dictionary<string, string>
            //{
            //    {"phone_number", ""}
            //}).ConfigureAwait(false);

            //var lrn = await VoiceTel.RequestAsync<Lrn>(new Dictionary<string, string>
            //{
            //    {"destination_number", ""},
            //    {"caller_number", ""}
            //}).ConfigureAwait(false);

            var numberCoverage = await VoiceTel.RequestAsync<NumberCoverage>(new Dictionary<string, string>
            {
                {"NPA", "201"}
            }).ConfigureAwait(false);

            #endregion

            #region SMS

            //var groupSms = await VoiceTel.RequestAsync<GroupSms>(new Dictionary<string, string>
            //{
            //    {"destination_number", "num1,num2,num3,numX"},
            //    {"caller_number", ""},
            //    {"message", $"Did you know it was {DateTime.UtcNow:F}?"}
            //}).ConfigureAwait(false);

            //var mdr = await VoiceTel.RequestAsync<Mdr>(new Dictionary<string, string>
            //{
            //    {"start_timestamp", $"{DateTimeOffset.Now.ToUnixTimeSeconds() - TimeSpan.FromMinutes(5).TotalSeconds}"},
            //    {"end_timestamp", $"{DateTimeOffset.Now.ToUnixTimeSeconds()}"},
            //    {"phone_number", ""}
            //}).ConfigureAwait(false);

            //var sms = await VoiceTel.RequestAsync<Sms>(new Dictionary<string, string>
            //{
            //    {"destination_number", ""},
            //    {"caller_number", ""},
            //    {"message", $"Did you know it was {DateTime.UtcNow:F}?"}
            //}).ConfigureAwait(false);

            //var smsv2 = await VoiceTel.PostRequestAsync<Sms>(new Dictionary<string, string>
            //    {
            //        {"apikey", ""},
            //        {"source", ""},
            //        {"destination", ""},
            //        {"messageText", ""}
            //    }, "v2/sms/")
            //    .ConfigureAwait(false);

            #endregion
        }

        private static void ProcessArgs(IEnumerable<string> args)
        {
            foreach (var s in args)
            {
                var cl = s.Split('=');
                var clSwitch = cl[0];
                var clParam = cl[1];

                switch (clSwitch)
                {
                    case "-apiKey":
                        ApiKey = clParam;
                        break;
                }
            }
        }
    }
}