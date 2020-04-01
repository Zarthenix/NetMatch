using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace NetMatch_PT.Controllers
{
    public static class ContentHandler
    {
        public static object GetJson<T>(string key)
        {
            JObject obj = JObject.Parse(File.ReadAllText("../NetMatch_PT/wwwroot/lib/content_config.json"));
            if (obj.ContainsKey(key))
            {
                return obj.GetValue(key).ToObject(typeof(T));
            }

            return null;
        }
    }
}
