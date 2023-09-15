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

namespace CampaignGUI.Forms.LocationDisplay
{
    public partial class LocationDisplay : Form
    {
        public Location LocationObj { get; set; }
        public string Filepath { get; set; }
        public string MapPath { get; set; }
        public CampaignDisplay CampaignDisplay { get; set; }
        public LocationDisplay()
        {
            InitializeComponent();
        }

        public LocationDisplay(Location location, CampaignDisplay campaignDisplay)
        {
            InitializeComponent();
            LocationObj = location;
            CampaignDisplay = campaignDisplay;
        }

        private void LocationDisplay_Load(object sender, EventArgs e)
        {
            try
            {
                locationNameValue.Text = LocationObj.Name;
                MapPath = Path.Combine(Utils.GetDocumentsPath(), Utils.GetLastOpened(), $"Locations\\{LocationObj.Name}");
                if (MapPath != null)
                {
                    image1.ImageLocation = $"{MapPath}\\map.jpg";
                    if (File.Exists(image1.ImageLocation))
                    {
                        Image image;
                        using (var bmpTemp = new Bitmap(image1.ImageLocation))
                        {
                            image = new Bitmap(bmpTemp);
                        }
                        Utils.ResizeDialogToImage(this, image1, image);
                    }
                }
                Filepath = Path.Combine(MapPath, $"{LocationObj.Name}.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void locationNameValue_TextChanged(object sender, EventArgs e)
        {
        }

        private void LocationDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Prompt to save
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void upload_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = " JPG files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = dialog.FileName;

                    image1.ImageLocation = imageLocation;
                    Image image = Image.FromFile(dialog.FileName);
                    image1.Image = image;
                    image1.Width = image.Width;
                    image1.Height = image.Height;
                    Size = new Size(image.Width + 300, image.Height + 100);

                    Utils.CopyUploadedImage(imageLocation, MapPath, "map.jpg");
                    LocationObj.Map = image;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                var obj = LocationObj;
                var success = Utils.SaveFile(ref obj, Filepath);
                CampaignDisplay.createLabel(LocationObj);
                if (success == 0)
                {
                    Timer timer = new Timer();
                    timer.Interval = 2000;
                    timer.Tick += new EventHandler(timer_Tick);
                    save.Text = "Save \u2713";
                    timer.Start();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            save.Text = "Save";
        }
    }

}
