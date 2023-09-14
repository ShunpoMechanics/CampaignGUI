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
    public class Campaign
    {
        public string Name { get; set; }
        public List<Location> Locations { get; set; }
        public List<Quest> Quests { get; set; }
        public List<Monster> MonsterLibrary { get; set; }
        //[JsonConverter(typeof(ImageConverter))]
        public Image Map { get; set; }

        public static Campaign FromFile(string content)
        {
            Campaign campaign = JsonConvert.DeserializeObject<Campaign>(content);            
            Image image;
            using (var bmpTemp = new Bitmap(Path.Combine(Utils.GetMapPath(), "map.jpg")))
            {
                image = new Bitmap(bmpTemp);
            }
            campaign.Map = image;
            return campaign;
        }

        public string ToFile()
        {
            string output = JsonConvert.SerializeObject(this);
            return output;
        }
    }
    //public class ImageConverter : JsonConverter
    //{
    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        try
    //        {
    //            var base64 = (string)reader.Value;
    //            // convert base64 to byte array, put that into memory stream and feed to image
    //            return Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)));
    //        }
    //        catch (Exception ex)
    //        {
    //            return null;
    //        }
    //    }

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        var image = (Image)value;
    //        // save to memory stream in original format
    //        var ms = new MemoryStream();
    //        image.Save(ms, image.RawFormat);
    //        byte[] imageBytes = ms.ToArray();
    //        // write byte array, will be converted to base64 by JSON.NET
    //        writer.WriteValue(imageBytes);
    //    }

    //    public override bool CanConvert(Type objectType)
    //    {
    //        return objectType == typeof(Image);
    //    }
    //}
}
