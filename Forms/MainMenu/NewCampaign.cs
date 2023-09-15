using CampaignGUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampaignGUI.Forms.MainMenu
{
    public partial class NewCampaign : Form
    {
        public NewCampaign()
        {
            InitializeComponent();
        }

        private void createCampaign_Click(object sender, EventArgs e)
        {
            try
            {
                string campaignName = campaignNameValue.Text;
                Campaign campaign = new Campaign();
                campaign.Name = campaignName;

                var path = Utils.GetDocumentsPath();
                if(!Directory.Exists(path))
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CampaignGUI/Campaigns"));

                Utils.SaveLastOpened(campaignName);

                if (!Directory.Exists(Utils.GetLocationsPath()))
                    Directory.CreateDirectory(Utils.GetLocationsPath());
                if (!Directory.Exists(Utils.GetPeoplePath()))
                    Directory.CreateDirectory(Utils.GetPeoplePath());
                if (!Directory.Exists(Utils.GetMonstersPath()))
                    Directory.CreateDirectory(Utils.GetMonstersPath());

                Utils.SaveFile(ref campaign, Path.Combine(path, campaignName + ".txt"));

                CampaignDisplay display = new CampaignDisplay(campaign, campaignName+".txt");
                this.Hide();
                display.ShowDialog();
            } 
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
