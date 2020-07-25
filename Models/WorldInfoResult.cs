using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcapi.Models
{
    [JsonObject]
    public class WorldInfoResult : IResult
    {
        public int user_id;
        public string current_map;
        public List<JObject> maps = new List<JObject>();
    }
}
