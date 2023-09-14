using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignGUI.Models
{
    public class Location
    {
        public string Name { get; set; }
        public List<People> Inhabitants { get; set; }
        public Tuple<int, int> Coordinates { get; set; }
        [JsonIgnore]
        public Image Map { get; set; }
        public static Location FromFile(string content)
        {
            Location location = JsonConvert.DeserializeObject<Location>(content);
            Image image;
            string path = Path.Combine(Utils.GetDocumentsPath(), Utils.GetLastOpened(), $"Locations\\{location.Name}", "map.jpg");
            using (var bmpTemp = new Bitmap(path))
            {
                image = new Bitmap(bmpTemp);
            }
            location.Map = image;
            return location;
        }
    }
}
