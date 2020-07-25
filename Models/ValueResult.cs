using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcapi.Models
{
    public class ValueResult : ApiResult
    {
        public JToken value;

        public static implicit operator ValueResult(JToken obj) => new ValueResult
        {
            value = obj
        };

        public static implicit operator ValueResult(IResult obj) => new ValueResult
        {
            value = JToken.FromObject(obj)
        };
    }
}
