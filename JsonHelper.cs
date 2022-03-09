using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Globalization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace popmsg
{
    public static class JsonHelper
    {
        public static string Encode(object obj)
        {
            JsonLongToStringConverter jsonLongToStr = new JsonLongToStringConverter();
            IsoDateTimeConverter jsonDateTime = new IsoDateTimeConverter
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
            };
            return JsonConvert.SerializeObject(obj, new JsonConverter[] { jsonLongToStr, jsonDateTime });
        }
        public static T Decode<T>(string str)
        {
            return (T)JsonConvert.DeserializeObject(str, typeof(T));
        }



        public static T Decode<T>(string json, string key)
        {
            string tmpjson = json;
            if (tmpjson.StartsWith("["))
            {
                tmpjson = tmpjson.TrimStart("[".ToCharArray());
            }
            if (tmpjson.EndsWith("]"))
            {
                tmpjson = tmpjson.TrimEnd("]".ToCharArray());
            }

            JObject obj = JsonConvert.DeserializeObject(tmpjson) as JObject;

            if (obj == null)
            {
                return default(T);
            }


            return obj.GetValue(key).ToObject<T>();

           

                
        }
    }
    public class JsonLongToStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(System.Int64).Equals(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            return JValue.ReadFrom(reader).Value<long>();
        }
        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
        }
    }
}