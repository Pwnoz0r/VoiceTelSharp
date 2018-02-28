// Copyright (c) 2018 Initial Servers LLC. All rights reserved.
// https://initialservers.com/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VoiceTelSharp.Lib.Controllers;
using VoiceTelSharp.Lib.Models.Account;
using VoiceTelSharp.Lib.Models.Call;
using VoiceTelSharp.Lib.Models.Info;
using VoiceTelSharp.Lib.Models.Sms;

namespace VoiceTelSharp.Test
{
    internal class Program
    {
        private static VoiceTel VoiceTel { get; set; }
        private static string ApiKey { get; set; }

        private static async Task Main(string[] args)
        {
            await Task.Run(() => ProcessArgs(args));

            VoiceTel = new VoiceTel(ApiKey);

            #region Account

            var accountInfo = await VoiceTel.Request<AccountInfo>();

            #endregion

            #region Call

            var cdr = await VoiceTel.Request<Cdr>(new Dictionary<string, string>
            {
                {"start_timestamp", $"{DateTimeOffset.Now.ToUnixTimeSeconds() - TimeSpan.FromMinutes(5).TotalSeconds}"},
                {"end_timestamp", $"{DateTimeOffset.Now.ToUnixTimeSeconds()}"}
            });

            //var gatewayAdd = await VoiceTel.Request<GatewayAdd>(new Dictionary<string, string>
            //{
            //    {"ip_address", $"{IPAddress.Parse("127.0.0.1")}"}
            //});
            var gatewayList = await VoiceTel.Request<GatewayList>();

            //var gatewaySet = await VoiceTel.Request<GatewaySet>(new Dictionary<string, string>
            //{
            //    {"ID", ""},
            //    {"DID", ""}
            //});
            var numberList = await VoiceTel.Request<NumberList>();

            var numberSearchNpa = await VoiceTel.Request<NumberSearchNpa>(new Dictionary<string, string>
            {
                {"NPA", "201"}
            });

            var numberSearchNpaNxx = await VoiceTel.Request<NumberSearchNpaNxx>(new Dictionary<string, string>
            {
                {"NPANXX", "201223"}
            });
            //var numberOrder = await VoiceTel.Request<NumberOrder>();

            #endregion

            #region Info

            //var cnam = await VoiceTel.Request<Cnam>(new Dictionary<string, string>
            //{
            //    {"phone_number", ""}
            //});

            //var lnp = await VoiceTel.Request<Lnp>(new Dictionary<string, string>
            //{
            //    {"phone_number", ""}
            //});

            //var lrn = await VoiceTel.Request<Lrn>(new Dictionary<string, string>
            //{
            //    {"destination_number", ""},
            //    {"caller_number", ""}
            //});
            var numberCoverage = await VoiceTel.Request<NumberCoverage>(new Dictionary<string, string>
            {
                {"NPA", "201"}
            });

            #endregion

            #region SMS

            var groupSms = await VoiceTel.Request<GroupSms>(new Dictionary<string, string>
            {
                {"destination_number", "num1,num2,num3,numX"},
                {"caller_number", ""},
                {"message", $"Did you know it was {DateTime.UtcNow:F}?"}
            });

            //var mdr = await VoiceTel.Request<Mdr>(new Dictionary<string, string>
            //{
            //    {"start_timestamp", $"{DateTimeOffset.Now.ToUnixTimeSeconds() - TimeSpan.FromMinutes(5).TotalSeconds}"},
            //    {"end_timestamp", $"{DateTimeOffset.Now.ToUnixTimeSeconds()}"},
            //    {"phone_number", ""}
            //});

            //var sms = await VoiceTel.Request<Sms>(new Dictionary<string, string>
            //{
            //    {"destination_number", ""},
            //    {"caller_number", ""},
            //    {"message", $"Did you know it was {DateTime.UtcNow:F}?"}
            //});

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