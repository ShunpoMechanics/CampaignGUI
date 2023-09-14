using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignGUI.Models
{
    public class Relationship
    {
        public Tuple<People, People> PeopleInvolved { get; set; }
        public string Description { get; set; }
    }
}
