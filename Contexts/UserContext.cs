using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcapi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Arcapi.Contexts
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

    [JsonObject]
    public class Setting
    {
        public bool is_hide_rating, max_stamina_notification_enabled;
        public int favorite_character;
    }

    [JsonObject]
    public class Core
    {
        public string core_type, _id;
        public int amount;
    }

    [JsonObject]
    public class User : IResult
    {
        public bool is_aprilfools, is_locked_name_duplicate, is_skill_sealed;
        public string name, display_name, user_code, password, current_map;
        public int ticket, character, user_id, prog_boost, stamina, max_friend, rating;
        public long next_fragstam_ts, max_stamina_ts, join_date;
        public List<int> world_unlocks, singles, packs, friends, curr_available_maps, characters;
        public List<string> world_songs;
        public List<Core> cores;
        public List<Character> character_stats;
        public List<int> recent_score;
        public Setting settings;
    }

    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
