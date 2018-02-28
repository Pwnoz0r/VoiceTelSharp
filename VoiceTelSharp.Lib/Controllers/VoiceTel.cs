using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VoiceTelSharp.Lib.Converters;
using VoiceTelSharp.Lib.Models.Call;
using VoiceTelSharp.Lib.Models.Sms;

namespace VoiceTelSharp.Lib.Controllers
{
    public class VoiceTel
    {
        public VoiceTel(string apiKey)
        {
            ApiKey = apiKey;
        }

        private string ApiKey { get; }

        public async Task<T> Request<T>(Dictionary<string, string> parameters = null)
        {
            var classType = typeof(T);
            var requestString = GetDescription(classType).Replace("[api_key]", ApiKey);

            if (parameters != null)
                foreach (var parameter in parameters)
                    if (typeof(T) == typeof(GroupSms))
                    {
                        if (parameter.Key != "destination_number") continue;

                        var numbers = parameter.Value.Split(',')
                            .Aggregate(string.Empty, (current, number) => current + $"-{number}");

                        requestString = requestString.Replace($"[{parameter.Key}]", numbers.TrimStart('-'));
                    }
                    else
                    {
                        requestString = requestString.Replace($"[{parameter.Key}]", parameter.Value);
                    }

            var requestUri = new Uri(requestString);

            return await HttpClientGet<T>(requestUri);
        }

        private static async Task<T> HttpClientGet<T>(Uri requestUri)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(requestUri);

                if (typeof(T) == typeof(NumberSearchNpa) || typeof(T) == typeof(NumberSearchNpaNxx))
                    return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync(),
                        new NumberSearchConverter());

                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
        }

        private static string GetDescription(ICustomAttributeProvider type)
        {
            var attributes = (DescriptionAttribute[])
                type.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length == 0 ? null : attributes[0].Description;
        }
    }
}