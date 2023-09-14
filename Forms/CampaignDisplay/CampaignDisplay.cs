using CampaignGUI.Forms.LocationDisplay;
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

namespace CampaignGUI
{
    public partial class CampaignDisplay : Form
    {
        public Campaign Campaign { get; set; }
        public string FileName { get; set; }
        public CampaignDisplay(Campaign campaign, string filename)
        {
            InitializeComponent();
            Campaign = campaign;
            FileName = filename;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            campaignNameValue.Text = Campaign.Name;
        }

        private void campaignNamValue_TextChanged(object sender, EventArgs a)
        {
            try
            {
                Campaign.Name = campaignNameValue.Text;
            } 
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void upload_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";

                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    
                    image1.ImageLocation = imageLocation;
                    Image image = Image.FromFile(dialog.FileName);
                    image1.Width = image.Width;
                    image1.Height = image.Height;
                    this.Size = new Size(image.Width+300, image.Height+100);
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void openLocation(Location location)
        {
            LocationDisplay locationDisplay = new LocationDisplay();
            locationDisplay.Show();
        }

        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                var confirmSave = MessageBox.Show("Are you sure you want to save all changes made?",
                                     "Confirm Overwriting Data",
                                     MessageBoxButtons.YesNo);
                if (confirmSave == DialogResult.Yes)
                {
                    string path = Path.Combine(Utils.GetDocumentsPath(), FileName);

                    Utils.SaveFile(Campaign, path);
                }
                else
                {
                    // If 'No', do something here.
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
