using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampaignGUI.Forms.DND.ItemLibrary
{
    public partial class ItemLibrary : Form
    {
        public CampaignDisplay CampaignDisplay { get; set; }
        public ItemLibrary()
        {
            InitializeComponent();
        }

        private void ItemLibrary_Load(object sender, EventArgs e)
        {

        }

        public ItemLibrary(CampaignDisplay campaignDisplay)
        {
            InitializeComponent();
            CampaignDisplay = campaignDisplay;
        }
    }
}
