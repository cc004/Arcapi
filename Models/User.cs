using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcapi.Models
{
    [JsonObject]
    public class User : IResult
    {
        public bool is_aprilfools, is_locked_name_duplicate, is_skill_sealed;
        public string name, display_name, user_code, password, current_map;
        public int ticket, character, user_id, prog_boost, stamina, max_friend, rating;
        public long next_fragstam_ts, max_stamina_ts, join_date;
        public List<int> world_unlocks, singles, friends, curr_available_maps, characters;
        public List<string> world_songs, packs;
        public List<Core> cores;
        public List<Character> character_stats;
        public List<int> recent_score;
        public Setting settings;
    }
}