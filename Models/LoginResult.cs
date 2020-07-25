using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcapi.Models
{
    public class LoginResult : ApiResult
    {
        public string access_token;
        public string token_type = "Bearer";
    }
}
