using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignGUI.Models
{
    public class Location
    {
        public string Name { get; set; }
        public List<People> Inhabitants { get; set; }
        public Tuple<int, int> Coordinates { get; set; }
        public Image Map { get; set; }
    }
}
