using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcapi.Models
{
    [JsonObject]
    public class Character
    {
        public List<Core> uncap_cores;
        public bool is_uncapped, is_previewable, skill_requires_uncap;
        public int char_type, skill_unlock_level, character_id, level, levelexp;
        public string skill_id_uncap, skill_id, name;
        public double overdrive, prog, frag, exp;
    }
}
