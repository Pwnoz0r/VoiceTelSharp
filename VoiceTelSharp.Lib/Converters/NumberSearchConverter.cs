// Copyright (c) 2018 Initial Servers LLC. All rights reserved.
// https://initialservers.com/

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VoiceTelSharp.Lib.Models.Call;

namespace VoiceTelSharp.Lib.Converters
{
    public class NumberSearchConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Numbers).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var telephoneNumber = JObject.Load(reader)["telephoneNumber"];

            var numbers = new List<TelephoneNumber>();

            if (telephoneNumber.Type == JTokenType.Array)
                numbers = JsonConvert.DeserializeObject<List<TelephoneNumber>>(telephoneNumber.ToString());
            else
                numbers.Add(JsonConvert.DeserializeObject<TelephoneNumber>(telephoneNumber.ToString()));

            return new Numbers {TelephoneNumber = numbers};
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}