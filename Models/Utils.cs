using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampaignGUI.Models
{
    public static class Utils
    {
        public static string GetDocumentsPath()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CampaignGUI\\Campaigns");
            return path;
        }

        public static string GetMapPath()
        {
            string campaignName = GetLastOpened();
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"CampaignGUI\\Campaigns\\{campaignName}\\Map");
            return path;
        }

        public static string GetMonstersPath()
        {
            string campaignName = GetLastOpened();
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"CampaignGUI\\Campaigns\\{campaignName}\\Monsters");
            return path;
        }

        public static string GetPeoplePath()
        {
            string campaignName = GetLastOpened();
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"CampaignGUI\\Campaigns\\{campaignName}\\People");
            return path;
        }

        public static void ResizeDialogToImage(Form form, PictureBox pictureBox, Image image)
        {
            pictureBox.Width = image.Width;
            pictureBox.Height = image.Height;
            form.Size = new Size(image.Width + 300, image.Height + 100);
        }

        public static void SaveLastOpened(string campaignName)
        {
            if (File.Exists($"{GetDocumentsPath()}\\lastOpenedSave.txt"))
            {
                File.Delete($"{GetDocumentsPath()}\\lastOpenedSave.txt");
            }
            using (FileStream fs = File.Create($"{GetDocumentsPath()}\\lastOpenedSave.txt"))
            {
                var bytes = Encoding.ASCII.GetBytes(campaignName);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
                fs.Dispose();
            }
        }

        public static string GetLastOpened()
        {
            string result = "";
            using (FileStream fs = File.OpenRead($"{GetDocumentsPath()}\\lastOpenedSave.txt"))
            {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, (int)fs.Length);
                result = Encoding.ASCII.GetString(bytes);
                fs.Close();
                fs.Dispose();
            }

            return result;
        }

        public static Label CreateLabel(Location location, Form form)
        {
            Label namelabel = new Label();
            namelabel.Location = new Point(location.Coordinates.Item1,location.Coordinates.Item2);
            namelabel.Text = location.Name; 
            namelabel.AutoSize = true;
            return namelabel;
        }

        public static void SaveFile<T>(ref T file, string fullPath)
        {
            var exists = Directory.Exists(fullPath);
            if (!exists)
            {
                using (FileStream fs = File.Create(fullPath))
                {
                    var bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(file));
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                };
            }
            else
            {
                using (FileStream fs = File.OpenWrite(fullPath))
                {
                    var bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(file));
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                };
            }
        }

        public static void CopyUploadedImage(string originalFilePath, string localFilePath, string filename)
        {
            var exists = Directory.Exists(localFilePath);
            if (!exists)
                Directory.CreateDirectory(localFilePath);

            exists = File.Exists(Path.Combine(localFilePath, filename));
            if (exists)
                File.Delete(Path.Combine(localFilePath, filename));
            File.Copy(originalFilePath, Path.Combine(localFilePath, "map.jpg"));
        }
    }

    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }

}
