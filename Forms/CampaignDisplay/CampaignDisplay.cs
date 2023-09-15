using CampaignGUI.Forms.ItemLibrary;
using CampaignGUI.Forms.LocationDisplay;
using CampaignGUI.Forms.MonsterLibrary;
using CampaignGUI.Forms.PeopleLibrary;
using CampaignGUI.Forms.QuestLibrary;
using CampaignGUI.Models;
using Newtonsoft.Json;
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
            Utils.SaveLastOpened(Campaign.Name);
            if (Campaign.Map != null)
                Utils.ResizeDialogToImage(this, image1, Campaign.Map);
            image1.Image = Campaign.Map;
            var directory = Path.Combine(Utils.GetDocumentsPath(), Campaign.Name);

            if (!Directory.Exists(Utils.GetLocationsPath()))
                Directory.CreateDirectory(Utils.GetLocationsPath());
            if (!Directory.Exists(Utils.GetPeoplePath()))
                Directory.CreateDirectory(Utils.GetPeoplePath());
            if (!Directory.Exists(Utils.GetMonstersPath()))
                Directory.CreateDirectory(Utils.GetMonstersPath());
            // Get Locations
            foreach (string folder in Directory.EnumerateDirectories($"{directory}\\Locations").ToList())
            {
                foreach (string file in Directory.EnumerateFiles(folder, "*.txt"))
                {
                    string contents = File.ReadAllText(file);
                    var location = CampaignGUI.Models.Location.FromFile(contents);
                    Campaign.Locations.Add(location);
                    // Add label to map

                    Label label = Utils.CreateLabel(location, image1.Location.X, image1.Location.Y);
                    Controls.Add(label);
                    label.BringToFront();
                    label.Click += new EventHandler(LocationClick);
                }
            }
            
            // Get People
            foreach (string folder in Directory.EnumerateDirectories($"{directory}\\People").ToList())
            {
                foreach (string file in Directory.EnumerateFiles(folder, "*.txt"))
                {
                    string contents = File.ReadAllText(file);
                    var person = People.FromFile(contents);
                    Campaign.PeopleLibrary.Add(person);                    
                }
            }
        }

        public void createLabel(Location location)
        {
            Label label = Utils.CreateLabel(location, image1.Location.X, image1.Location.Y);
            Controls.Add(label);
            label.BringToFront();
            label.Click += new EventHandler(LocationClick);
            Campaign.Locations.Add(location);
        }

        private void LocationClick(object sender, EventArgs e)
        {
            Label label = sender as Label;
            Location location = Campaign.Locations.Where(l => l.Name == label.Text).FirstOrDefault();
            if(location != null)
                openLocation(location);
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

                    //image1.ImageLocation = imageLocation;
                    Image image = Image.FromFile(dialog.FileName);

                    if (image.Width < 1920 && upscale.Checked)
                        image = Utils.ResizeImage(image, 1920, 1080);

                    Campaign.Map = image;
                    image1.Image = image;
                    image1.Width = image.Width;
                    image1.Height = image.Height;
                    Size = new Size(image.Width+300, image.Height+100);
                    
                    if (upscale.Checked)
                    {
                        image.Save(Path.Combine(Utils.GetMapPath(), "map.jpg"));
                    }
                    else
                        Utils.CopyUploadedImage(imageLocation, Utils.GetMapPath(), "map.jpg");
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            var x = me.X;
            var y = me.Y;

            string promptValue = Prompt.ShowDialog("New Location", "Please provide a name for the Location");

            Location location = new Location() {
                Coordinates = Tuple.Create(x, y),
                Name = promptValue,
                Map = null,
                Inhabitants = new List<People>()
            };
            
            openLocation(location);

            // Add label to map
            //myLabelsName.BringToFront();
        }

        private void openLocation(Location location)
        {
            LocationDisplay locationDisplay = new LocationDisplay(location, this);
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
                    var obj = Campaign;
                    Utils.SaveFile(ref obj, path);
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

        private void peopleLibrary_Click(object sender, EventArgs e)
        {
            PeopleLibrary pl = new PeopleLibrary(this);
            pl.Show();
        }

        private void monsterLibrary_Click(object sender, EventArgs e)
        {
            MonsterLibrary pl = new MonsterLibrary(this);
            pl.Show();
        }

        private void itemLibrary_Click(object sender, EventArgs e)
        {
            ItemLibrary pl = new ItemLibrary(this);
            pl.Show();
        }

        private void questLibrary_Click(object sender, EventArgs e)
        {
            QuestLibrary pl = new QuestLibrary(this);
            pl.Show();
        }

        public Campaign GetCampaign()
        {
            return Campaign;
        }
    }
}
