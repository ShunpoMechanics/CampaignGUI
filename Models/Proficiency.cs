﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignGUI.Models
{
    public class Proficiency
    {
        public string Name { get; set; }
        public bool Proficient { get; set; }
        public bool Expertise { get; set; }
        public string Stat { get; set; }
        public int Value { get; set; }
        public bool Overriden { get; set; }
    }
}
