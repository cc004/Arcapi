using Arcapi.Contexts;
using Arcapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcapi
{
    public static class Utils
    {
        public static string GetUsername(this HttpRequest request, AuthorizationContext context)
        {
            var auth = request.Headers["Authorization"].Single();
            return context.Auths.Single(a => $"Bearer {a.token}" == auth).username;
        }

        public static User GetFakeUser()
        {
            var result = JsonConvert.DeserializeObject<User>(Encoding.ASCII.GetString(Convert.FromBase64String("ewogICAgImlzX2FwcmlsZm9vbHMiOiBmYWxzZSwKICAgICJjdXJyX2F2YWlsYWJsZV9tYXBzIjogWwogICAgXSwKICAgICJjaGFyYWN0ZXJfc3RhdHMiOiBbCiAgICAgICAgewogICAgICAgICAgICAiaXNfdW5jYXBwZWQiOiBmYWxzZSwKICAgICAgICAgICAgInVuY2FwX2NvcmVzIjogWwogICAgICAgICAgICAgICAgewogICAgICAgICAgICAgICAgICAgICJfaWQiOiAiNWYwZWVjMmE2YzlhM2QwMTI3NDdhMGQ5IiwKICAgICAgICAgICAgICAgICAgICAiY29yZV90eXBlIjogImNvcmVfaG9sbG93IiwKICAgICAgICAgICAgICAgICAgICAiYW1vdW50IjogMjUKICAgICAgICAgICAgICAgIH0sCiAgICAgICAgICAgICAgICB7CiAgICAgICAgICAgICAgICAgICAgIl9pZCI6ICI1ZjBlZWMyYTZjOWEzZDAxMjc0N2EwZDgiLAogICAgICAgICAgICAgICAgICAgICJjb3JlX3R5cGUiOiAiY29yZV9kZXNvbGF0ZSIsCiAgICAgICAgICAgICAgICAgICAgImFtb3VudCI6IDUKICAgICAgICAgICAgICAgIH0KICAgICAgICAgICAgXSwKICAgICAgICAgICAgImNoYXJfdHlwZSI6IDEsCiAgICAgICAgICAgICJza2lsbF9pZF91bmNhcCI6ICIiLAogICAgICAgICAgICAic2tpbGxfcmVxdWlyZXNfdW5jYXAiOiBmYWxzZSwKICAgICAgICAgICAgInNraWxsX3VubG9ja19sZXZlbCI6IDAsCiAgICAgICAgICAgICJza2lsbF9pZCI6ICJnYXVnZV9lYXN5IiwKICAgICAgICAgICAgIm92ZXJkcml2ZSI6IDM1LjAxNTE2MjU2MDEzOTk2LAogICAgICAgICAgICAicHJvZyI6IDM1LjAxNTE2MjU2MDEzOTk2LAogICAgICAgICAgICAiZnJhZyI6IDU1LjAxMzQxMzAzMzk2OTk3LAogICAgICAgICAgICAibGV2ZWxfZXhwIjogNTAsCiAgICAgICAgICAgICJleHAiOiA5NC4xNjE5NDAwMDAwMDAwMiwKICAgICAgICAgICAgImxldmVsIjogMiwKICAgICAgICAgICAgIm5hbWUiOiAiaGlrYXJpIiwKICAgICAgICAgICAgImNoYXJhY3Rlcl9pZCI6IDAKICAgICAgICB9LAogICAgICAgIHsKICAgICAgICAgICAgImlzX3VuY2FwcGVkIjogZmFsc2UsCiAgICAgICAgICAgICJ1bmNhcF9jb3JlcyI6IFsKICAgICAgICAgICAgICAgIHsKICAgICAgICAgICAgICAgICAgICAiX2lkIjogIjVmMGVlYzJhNmM5YTNkMDEyNzQ3YTBkYiIsCiAgICAgICAgICAgICAgICAgICAgImNvcmVfdHlwZSI6ICJjb3JlX2Rlc29sYXRlIiwKICAgICAgICAgICAgICAgICAgICAiYW1vdW50IjogMjUKICAgICAgICAgICAgICAgIH0sCiAgICAgICAgICAgICAgICB7CiAgICAgICAgICAgICAgICAgICAgIl9pZCI6ICI1ZjBlZWMyYTZjOWEzZDAxMjc0N2EwZGEiLAogICAgICAgICAgICAgICAgICAgICJjb3JlX3R5cGUiOiAiY29yZV9ob2xsb3ciLAogICAgICAgICAgICAgICAgICAgICJhbW91bnQiOiA1CiAgICAgICAgICAgICAgICB9CiAgICAgICAgICAgIF0sCiAgICAgICAgICAgICJjaGFyX3R5cGUiOiAwLAogICAgICAgICAgICAic2tpbGxfaWRfdW5jYXAiOiAiIiwKICAgICAgICAgICAgInNraWxsX3JlcXVpcmVzX3VuY2FwIjogZmFsc2UsCiAgICAgICAgICAgICJza2lsbF91bmxvY2tfbGV2ZWwiOiAwLAogICAgICAgICAgICAic2tpbGxfaWQiOiAiIiwKICAgICAgICAgICAgIm92ZXJkcml2ZSI6IDY1LjYyODM3MTQ4MjcyMzQyLAogICAgICAgICAgICAicHJvZyI6IDY1LjYyODM3MTQ4MjcyMzQyLAogICAgICAgICAgICAiZnJhZyI6IDY1LjYyODM3MTQ4MjcyMzQyLAogICAgICAgICAgICAibGV2ZWxfZXhwIjogMTIwMCwKICAgICAgICAgICAgImV4cCI6IDEyODIuMjk1NTU1LAogICAgICAgICAgICAibGV2ZWwiOiAxMCwKICAgICAgICAgICAgIm5hbWUiOiAidGFpcml0c3UiLAogICAgICAgICAgICAiY2hhcmFjdGVyX2lkIjogMQogICAgICAgIH0sCiAgICAgICAgewogICAgICAgICAgICAiaXNfcHJldmlld2FibGUiOiB0cnVlLAogICAgICAgICAgICAidW5jYXBfY29yZXMiOiBbCiAgICAgICAgICAgICAgICB7CiAgICAgICAgICAgICAgICAgICAgIl9pZCI6ICI1ZjBlZWMyYTZjOWEzZDAxMjc0N2EwZGQiLAogICAgICAgICAgICAgICAgICAgICJjb3JlX3R5cGUiOiAiY29yZV9jcmltc29uIiwKICAgICAgICAgICAgICAgICAgICAiYW1vdW50IjogMjUKICAgICAgICAgICAgICAgIH0sCiAgICAgICAgICAgICAgICB7CiAgICAgICAgICAgICAgICAgICAgIl9pZCI6ICI1ZjBlZWMyYTZjOWEzZDAxMjc0N2EwZGMiLAogICAgICAgICAgICAgICAgICAgICJjb3JlX3R5cGUiOiAiY29yZV9ob2xsb3ciLAogICAgICAgICAgICAgICAgICAgICJhbW91bnQiOiA1CiAgICAgICAgICAgICAgICB9CiAgICAgICAgICAgIF0sCiAgICAgICAgICAgICJjaGFyX3R5cGUiOiAwLAogICAgICAgICAgICAic2tpbGxfaWRfdW5jYXAiOiAiIiwKICAgICAgICAgICAgInNraWxsX3JlcXVpcmVzX3VuY2FwIjogdHJ1ZSwKICAgICAgICAgICAgInNraWxsX3VubG9ja19sZXZlbCI6IDIwLAogICAgICAgICAgICAic2tpbGxfaWQiOiAiZnJhZ3Nfa291IiwKICAgICAgICAgICAgIm92ZXJkcml2ZSI6IDQ3LjUsCiAgICAgICAgICAgICJwcm9nIjogNzAsCiAgICAgICAgICAgICJmcmFnIjogOTAsCiAgICAgICAgICAgICJsZXZlbF9leHAiOiAxMDAwMCwKICAgICAgICAgICAgImV4cCI6IDEwMDAwLAogICAgICAgICAgICAibGV2ZWwiOiAyMCwKICAgICAgICAgICAgIm5hbWUiOiAia291IiwKICAgICAgICAgICAgImNoYXJhY3Rlcl9pZCI6IDIKICAgICAgICB9LAogICAgICAgIHsKICAgICAgICAgICAgImlzX3ByZXZpZXdhYmxlIjogdHJ1ZSwKICAgICAgICAgICAgInVuY2FwX2NvcmVzIjogW10sCiAgICAgICAgICAgICJjaGFyX3R5cGUiOiAwLAogICAgICAgICAgICAic2tpbGxfaWRfdW5jYXAiOiAiIiwKICAgICAgICAgICAgInNraWxsX3JlcXVpcmVzX3VuY2FwIjogZmFsc2UsCiAgICAgICAgICAgICJza2lsbF91bmxvY2tfbGV2ZWwiOiAwLAogICAgICAgICAgICAic2tpbGxfaWQiOiAiIiwKICAgICAgICAgICAgIm92ZXJkcml2ZSI6IDc1LAogICAgICAgICAgICAicHJvZyI6IDc1LAogICAgICAgICAgICAiZnJhZyI6IDc1LAogICAgICAgICAgICAibGV2ZWxfZXhwIjogMTAwMDAsCiAgICAgICAgICAgICJleHAiOiAxMDAwMCwKICAgICAgICAgICAgImxldmVsIjogMjAsCiAgICAgICAgICAgICJuYW1lIjogInNhcHBoaXJlIiwKICAgICAgICAgICAgImNoYXJhY3Rlcl9pZCI6IDMKICAgICAgICB9LAogICAgICAgIHsKICAgICAgICAgICAgImlzX3ByZXZpZXdhYmxlIjogdHJ1ZSwKICAgICAgICAgICAgInVuY2FwX2NvcmVzIjogWwogICAgICAgICAgICAgICAgewogICAgICAgICAgICAgICAgICAgICJfaWQiOiAiNWYwZWVjMmE2YzlhM2QwMTI3NDdhMGRmIiwKICAgICAgICAgICAgICAgICAgICAiY29yZV90eXBlIjogImNvcmVfYW1iaXZhbGVudCIsCiAgICAgICAgICAgICAgICAgICAgImFtb3VudCI6IDI1CiAgICAgICAgICAgICAgICB9LAogICAgICAgICAgICAgICAgewogICAgICAgICAgICAgICAgICAgICJfaWQiOiAiNWYwZWVjMmE2YzlhM2QwMTI3NDdhMGRlIiwKICAgICAgICAgICAgICAgICAgICAiY29yZV90eXBlIjogImNvcmVfZGVzb2xhdGUiLAogICAgICAgICAgICAgICAgICAgICJhbW91bnQiOiA1CiAgICAgICAgICAgICAgICB9CiAgICAgICAgICAgIF0sCiAgICAgICAgICAgICJjaGFyX3R5cGUiOiAwLAogICAgICAgICAgICAic2tpbGxfaWRfdW5jYXAiOiAidmlzdWFsX2luayIsCiAgICAgICAgICAgICJza2lsbF9yZXF1aXJlc191bmNhcCI6IGZhbHNlLAogICAgICAgICAgICAic2tpbGxfdW5sb2NrX2xldmVsIjogOCwKICAgICAgICAgICAgInNraWxsX2lkIjogIm5vdGVfbWlycm9yIiwKICAgICAgICAgICAgIm92ZXJkcml2ZSI6IDcwLAogICAgICAgICAgICAicHJvZyI6IDkwLAogICAgICAgICAgICAiZnJhZyI6IDcwLAogICAgICAgICAgICAibGV2ZWxfZXhwIjogMTAwMDAsCiAgICAgICAgICAgICJleHAiOiAxMDAwMCwKICAgICAgICAgICAgImxldmVsIjogMjAsCiAgICAgICAgICAgICJuYW1lIjogImxldGhlIiwKICAgICAgICAgICAgImNoYXJhY3Rlcl9pZCI6IDQKICAgICAgICB9CiAgICBdLAogICAgImZyaWVuZHMiOiBbXSwKICAgICJzZXR0aW5ncyI6IHsKICAgICAgICAiaXNfaGlkZV9yYXRpbmciOiBmYWxzZSwKICAgICAgICAiZmF2b3JpdGVfY2hhcmFjdGVyIjogMSwKICAgICAgICAibWF4X3N0YW1pbmFfbm90aWZpY2F0aW9uX2VuYWJsZWQiOiBmYWxzZQogICAgfSwKICAgICJ1c2VyX2lkIjogMjQwOTA5OCwKICAgICJuYW1lIjogIjExNzYzMjE4OTciLAogICAgInVzZXJfY29kZSI6ICI2NDY3Nzg1MTgiLAogICAgImRpc3BsYXlfbmFtZSI6ICIxMTc2MzIxODk3IiwKICAgICJ0aWNrZXQiOiAwLAogICAgImNoYXJhY3RlciI6IDEsCiAgICAiaXNfbG9ja2VkX25hbWVfZHVwbGljYXRlIjogZmFsc2UsCiAgICAiaXNfc2tpbGxfc2VhbGVkIjogZmFsc2UsCiAgICAiY3VycmVudF9tYXAiOiAiZXh0ZW5kX2JsYWNrbG90dXMiLAogICAgInByb2dfYm9vc3QiOiAwLAogICAgIm5leHRfZnJhZ3N0YW1fdHMiOiAtMSwKICAgICJtYXhfc3RhbWluYV90cyI6IDE1OTA1ODA1MTc2MzQsCiAgICAic3RhbWluYSI6IDEwLAogICAgIndvcmxkX3VubG9ja3MiOiBbXSwKICAgICJ3b3JsZF9zb25ncyI6IFsKICAgICAgICAiYmFiYXJvcXVlIiwKICAgICAgICAic2hhZGVzb2ZsaWdodCIKICAgIF0sCiAgICAic2luZ2xlcyI6IFtdLAogICAgInBhY2tzIjogW10sCiAgICAiY2hhcmFjdGVycyI6IFsKICAgICAgICAwLAogICAgICAgIDEKICAgIF0sCiAgICAiY29yZXMiOiBbCiAgICAgICAgewogICAgICAgICAgICAiY29yZV90eXBlIjogImNvcmVfZ2VuZXJpYyIsCiAgICAgICAgICAgICJhbW91bnQiOiAwLAogICAgICAgICAgICAiX2lkIjogIjVlYWFlMjI2YmRiNGIxMDY5NjBlNDJjNyIKICAgICAgICB9CiAgICBdLAogICAgInJlY2VudF9zY29yZSI6IFtdLAogICAgIm1heF9mcmllbmQiOiAxMCwKICAgICJyYXRpbmciOiAyOTMsCiAgICAiam9pbl9kYXRlIjogMTU3MTA2NDE2Njc3Mwp9")));
            result.rating = 9999;
            result.ticket = 9999;
            result.packs = new List<string>
            {
                "core", "zettai", "yozakurafubuki", "chunithm", "tonesphere", "surrender", "izana", "nijuusei", "amygdata", "omatsuri", "dropdead", "avantraze", "alexandrite", "auxesia", "heavenlycaress", "crosssoul", "altale", "bethere", "rei", "phantasia", "astraltale", "fallensquare", "feelssoright", "dataerror", "mirai", "einherjar", "yourvoiceso", "battlenoone", "groovecoaster", "dreadnought", "prelude", "teriqma", "yugamu", "empireofwinter", "mirzam", "scarletcage", "dottodot", "extend", "lanota", "metallicpunisher", "libertas", "callmyname", "carminescythe", "modelista", "laqryma", "saikyostronger", "impurebird", "shiawase", "vs", "dynamix", "filament"
            };
            result.world_songs = new List<string>
            {
                "vector", "monochromeprincess", "gloryroad", "lostdesire", "redandblue", "grimheart", "supernova", "vividtheory", "suomi", "darakunosono", "diode", "lucifer", "babaroque", "givemeanightmare", "anokumene", "etherstrike", "goodtek", "shadesoflight", "syro", "kanagawa", "guardina", "revixy", "worldvanquisher", "ignotus", "rabbitintheblackroom", "blaster", "blrink", "cyberneciacatharsis", "solitarydream", "qualia", "espebranch", "blacklotus", "sheriruth", "harutopia", "onefr", "bookmaker", "gekka", "nhelv", "faintlight", "corpssansorganes", "freefall", "pragmatism", "rugie", "dreaminattraction", "essenceoftwilight", "axiumcrisis"
            };

            result.characters = Enumerable.Range(0, 15).ToList();
            result.character_stats = Enumerable.Range(0, 15).Select(i => new Character
            {
                character_id = i,
                char_type = i,
                skill_id = "",
                skill_requires_uncap = false,
                skill_unlock_level = 0,
                skill_id_uncap = "",
                uncap_cores = new List<Core>
                {
                    new Core
                    {
                        amount = 0,
                        core_type = "core_hallow",
                        _id = "5f0eec2a6c9a3d012747a0d9"
                    }
                },
                exp = 99999,
                level = 9999,
                prog = 1e5,
                frag = 1e5,
                overdrive = 1e5,
                name = $"character{i}",
                is_uncapped = false,
                levelexp = 100
            }).ToList();
            return result;
        }
    }
}
