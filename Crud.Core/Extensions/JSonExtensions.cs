using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Core.Extensions
{
    public static class JSonExtensions
    {
        public static string ToJson(this object item)
        {
            return JsonConvert.SerializeObject(item, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }
        public static T FromJson<T>(this string item)
        {
            return JsonConvert.DeserializeObject<T>(item);
        }
    }
}
