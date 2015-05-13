using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Cdiscount.OpenApi.ProxyClient.Helper
{
    /// <summary>
    /// Convert the one item to a list while the API doesn't support more. Also convert to lowercases.
    /// </summary>
    public class ToLowerCaseStringEnumerableConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            object toSerialize;
            string stringToSend = value as string;

            if (stringToSend != null)
            {
                toSerialize = new List<string> { stringToSend.ToLowerInvariant() };
            }
            else
            {
                toSerialize = value;
            }

            serializer.Serialize(writer, toSerialize);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IEnumerable<string>);
        }

        public override bool CanRead
        {
            get
            {
                return false;
            }
        }
    }
}
