using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignGUI.Models
{
    public class Quest
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string PrerequisiteQuest { get; set; }
        public string LocationName { get; set; }
        public string Description { get; set; }
        public List<People> PeopleInvolved { get; set; }
        public List<Monster> Monsters { get; set; }
     }
}
