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
        public LocationDisplay()
        {
            InitializeComponent();
        }

        public LocationDisplay(Location location)
        {
            InitializeComponent();
            LocationObj = location;
        }

        private void LocationDisplay_Load(object sender, EventArgs e)
        {
            locationNameValue.Text = LocationObj.Name;
            MapPath = Path.Combine(Utils.GetDocumentsPath(), Utils.GetLastOpened(), $"Locations\\{LocationObj.Name}");
            Filepath = Path.Combine(MapPath, $"{LocationObj.Name}.txt");
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
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = dialog.FileName;

                    image1.ImageLocation = imageLocation;
                    Image image = Image.FromFile(dialog.FileName);
                    image1.Image = image;
                    image1.Width = image.Width;
                    image1.Height = image.Height;
                    this.Size = new Size(image.Width + 300, image.Height + 100);

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
                Utils.SaveFile(ref obj, Filepath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
