using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignGUI.Models
{
    public class Campaign
    {
        public string Name { get; set; }
        public Location[] Locations { get; set; }
        public Quest[] Quests { get; set; }
        public Image Map { get; set; }

        public static Campaign FromFile(string content)
        {
            Campaign campaign = JsonConvert.DeserializeObject<Campaign>(content);
            return campaign;
        }

        public string ToFile()
        {
            string output = JsonConvert.SerializeObject(this);
            return output;
        }
    }
}
