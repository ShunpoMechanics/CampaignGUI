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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void newCampaign_Click(object sender, EventArgs e)
        {
            this.Hide();            
            NewCampaign newCampaign = new NewCampaign();
            newCampaign.ShowDialog();
        }

        private void loadCampaign_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog() { };
            dialog.InitialDirectory = Utils.GetDocumentsPath();

            dialog.Filter = "txt files(*.txt)|*.txt|All Files(*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = File.OpenRead(dialog.FileName))
                {
                    byte[] bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, ((int)fs.Length));
                    
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }

                    string content = Encoding.UTF8.GetString(bytes, 0, bytes.Length);

                    Campaign campaign = Campaign.FromFile(content);
                    CampaignDisplay display = new CampaignDisplay(campaign, campaign.Name + ".txt");
                    Utils.SaveLastOpened(campaign.Name);
                    this.Hide();
                    display.ShowDialog();
                    fs.Dispose();
                    fs.Close();
                }
            }
        }
    }
}
