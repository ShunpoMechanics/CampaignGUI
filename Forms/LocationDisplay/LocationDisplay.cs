using CampaignGUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampaignGUI.Forms.LocationDisplay
{
    public partial class LocationDisplay : Form
    {
        public Location LocationObj { get; set; }
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
        }

        private void locationNameValue_TextChanged(object sender, EventArgs e)
        {
        }

        private void LocationDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Prompt to save
        }
    }
}
