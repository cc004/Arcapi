using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcapi.Models
{
    [JsonObject]
    public class Core
    {
        public string core_type, _id;
        public int amount;
    }

}
