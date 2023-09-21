using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampaignGUI.Forms.DND.MonsterLibrary
{
    public partial class MonsterLibrary : Form
    {
        public CampaignDisplay CampaignDisplay { get; set; }
        public MonsterLibrary()
        {
            InitializeComponent();
        }

        public MonsterLibrary(CampaignDisplay campaignDisplay)
        {
            InitializeComponent();
            CampaignDisplay = campaignDisplay;
        }
        private void MonsterLibrary_Load(object sender, EventArgs e)
        {

        }
    }
}
