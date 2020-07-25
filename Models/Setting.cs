using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcapi.Models
{


    [JsonObject]
    public class Setting
    {
        public bool is_hide_rating, max_stamina_notification_enabled;
        public int favorite_character;
    }

}
