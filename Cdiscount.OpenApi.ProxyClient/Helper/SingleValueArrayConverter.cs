using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Cdiscount.OpenApi.ProxyClient.Helper
{
    /// <summary>
    /// Parse Json into a List of objects, whether the square brackets [] are there or not 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingleValueArrayConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object result = null;

            if (reader.TokenType == JsonToken.StartObject)
            {
                T instance = (T)serializer.Deserialize(reader, typeof(T));
                result = new List<T>() { instance };
            }
            else if (reader.TokenType == JsonToken.StartArray)
            {
                result = serializer.Deserialize(reader, objectType);
            }

            return result;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }
    }
}
