using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampaignGUI.Forms.QuestLibrary
{
    public partial class QuestLibrary : Form
    {
        public CampaignDisplay CampaignDisplay { get; set; }
        public QuestLibrary()
        {
            InitializeComponent();
        }

        public QuestLibrary(CampaignDisplay campaignDisplay)
        {
            InitializeComponent();
            CampaignDisplay = campaignDisplay;
        }

        private void QuestLibrary_Load(object sender, EventArgs e)
        {

        }
    }
}
