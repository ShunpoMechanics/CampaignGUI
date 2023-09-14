using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignGUI.Models
{
    public class People
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public Relationship[] Relationships{ get; set; }
        
    }
}
