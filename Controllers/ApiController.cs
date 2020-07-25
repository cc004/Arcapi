using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Arcapi.Contexts;
using Arcapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Arcapi.Controllers
{
    [ApiController]
    [Route("coffee/12")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> logger;
        private readonly AuthorizationContext context;

        public ApiController(ILogger<ApiController> logger, AuthorizationContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        [HttpPost("auth/login")]
        public ActionResult<LoginResult> Login()
        {
            var auth = Request.Headers["Authorization"].Single();
            if (!auth.StartsWith("Basic ")) return new LoginResult { success = false };
            auth = auth.Substring(6);

            logger.LogInformation($"logging in with authorization {auth}");

            var token = Convert.ToBase64String(new Guid().ToByteArray().Concat(new Guid().ToByteArray()).ToArray());
            context.Auths.Add(new Authorization
            {
                username = auth.Split(':').First(),
                token = token
            });

            return new LoginResult
            {
                access_token = token
            };
        }

        [HttpGet("user/me")]
        public ActionResult<ValueResult> UserInfo()
        {
            var user = Utils.GetFakeUser();
            return (ValueResult) user;
        }

        [HttpGet("purchase/bundle/pack")]
        public ActionResult<ValueResult> BundleInfo()
        {
            return (ValueResult) new JArray();
        }

        [HttpGet("world/map/me")]
        public ActionResult<ValueResult> WorldInfo()
        {
            var user = Utils.GetFakeUser();
            return (ValueResult) new WorldInfoResult
            {
                user_id = user.user_id,
                current_map = user.current_map
            };
        }

        [HttpGet("serve/download/me/song")]
        public ActionResult<ValueResult> SongInfo()
        {
            return (ValueResult) new JObject();
        }

        [HttpGet("game/info")]
        public ActionResult<ValueResult> GameInfo()
        {
            return (ValueResult) JToken.Parse(Encoding.ASCII.GetString(Convert.FromBase64String("eyJtYXhfc3RhbWluYSI6IDEyLCAic3RhbWluYV9yZWNvdmVyX3RpY2siOiAxODAwMDAwLCAiY29yZV9leHAiOiAyNTAsICJjdXJyX3RzIjogMTU5NTY1MTA2OTY3MiwgImxldmVsX3N0ZXBzIjogW3sibGV2ZWwiOiAxLCAibGV2ZWxfZXhwIjogMH0sIHsibGV2ZWwiOiAyLCAibGV2ZWxfZXhwIjogNTB9LCB7ImxldmVsIjogMywgImxldmVsX2V4cCI6IDEwMH0sIHsibGV2ZWwiOiA0LCAibGV2ZWxfZXhwIjogMTUwfSwgeyJsZXZlbCI6IDUsICJsZXZlbF9leHAiOiAyMDB9LCB7ImxldmVsIjogNiwgImxldmVsX2V4cCI6IDMwMH0sIHsibGV2ZWwiOiA3LCAibGV2ZWxfZXhwIjogNDUwfSwgeyJsZXZlbCI6IDgsICJsZXZlbF9leHAiOiA2NTB9LCB7ImxldmVsIjogOSwgImxldmVsX2V4cCI6IDkwMH0sIHsibGV2ZWwiOiAxMCwgImxldmVsX2V4cCI6IDEyMDB9LCB7ImxldmVsIjogMTEsICJsZXZlbF9leHAiOiAxNjAwfSwgeyJsZXZlbCI6IDEyLCAibGV2ZWxfZXhwIjogMjEwMH0sIHsibGV2ZWwiOiAxMywgImxldmVsX2V4cCI6IDI3MDB9LCB7ImxldmVsIjogMTQsICJsZXZlbF9leHAiOiAzNDAwfSwgeyJsZXZlbCI6IDE1LCAibGV2ZWxfZXhwIjogNDIwMH0sIHsibGV2ZWwiOiAxNiwgImxldmVsX2V4cCI6IDUxMDB9LCB7ImxldmVsIjogMTcsICJsZXZlbF9leHAiOiA2MTAwfSwgeyJsZXZlbCI6IDE4LCAibGV2ZWxfZXhwIjogNzIwMH0sIHsibGV2ZWwiOiAxOSwgImxldmVsX2V4cCI6IDg1MDB9LCB7ImxldmVsIjogMjAsICJsZXZlbF9leHAiOiAxMDAwMH0sIHsibGV2ZWwiOiAyMSwgImxldmVsX2V4cCI6IDExNTAwfSwgeyJsZXZlbCI6IDIyLCAibGV2ZWxfZXhwIjogMTMwMDB9LCB7ImxldmVsIjogMjMsICJsZXZlbF9leHAiOiAxNDUwMH0sIHsibGV2ZWwiOiAyNCwgImxldmVsX2V4cCI6IDE2MDAwfSwgeyJsZXZlbCI6IDI1LCAibGV2ZWxfZXhwIjogMTc1MDB9LCB7ImxldmVsIjogMjYsICJsZXZlbF9leHAiOiAxOTAwMH0sIHsibGV2ZWwiOiAyNywgImxldmVsX2V4cCI6IDIwNTAwfSwgeyJsZXZlbCI6IDI4LCAibGV2ZWxfZXhwIjogMjIwMDB9LCB7ImxldmVsIjogMjksICJsZXZlbF9leHAiOiAyMzUwMH0sIHsibGV2ZWwiOiAzMCwgImxldmVsX2V4cCI6IDI1MDAwfV0sICJ3b3JsZF9yYW5raW5nX2VuYWJsZWQiOiBmYWxzZSwgImlzX2J5ZF9jaGFwdGVyX3VubG9ja2VkIjogdHJ1ZX0=")));
        }

        [HttpGet("present/me")]
        public ActionResult<ValueResult> PresentInfo()
        {
            return (ValueResult) new JArray();
        }

        [HttpGet("compose/aggregate")]
        public ActionResult<ValueResult> Aggregate()
        {
            JArray arr = JArray.Parse(Request.Query["calls"]);
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", Request.Headers["Authorization"].Single());

            return (ValueResult) new JArray(arr.Select(call =>
            {
                var conn = Request.HttpContext.Connection;
                var endpoint = $"https://localhost:{conn.LocalPort}/coffee/12{call.Value<string>("endpoint")}";

                return new JObject
                {
                    ["id"] = call["id"],
                    ["value"] = JToken.Parse(client.GetAsync(endpoint).Result.Content.ReadAsStringAsync().Result)["value"]
                };
            }));
        }

    }
}
