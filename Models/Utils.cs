using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignGUI.Models
{
    public static class Utils
    {
        public static string GetDocumentsPath()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CampaignGUI\\Campaigns");
            return path;
        }

        public static void SaveFile(Campaign campaign, string fullPath)
        {
            //bool exists = File.Exists(fullPath);
            //if(exists)
            //{
            //    using (FileStream fs = File.OpenWrite(fullPath))
            //    {
            //        var bytes = Encoding.ASCII.GetBytes(campaign.ToFile());
            //        fs.Write(bytes, 0, bytes.Length);
            //        fs.Close();
            //    };
            //}
            //else
            //{
            using (FileStream fs = File.Create(fullPath))
            {
                var bytes = Encoding.ASCII.GetBytes(campaign.ToFile());
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            };
            //}           
        }
    }
}
