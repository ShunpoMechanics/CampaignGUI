using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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

        public static string GetLocationsPath()
        {
            string campaignName = GetLastOpened();
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"CampaignGUI\\Campaigns\\{campaignName}\\Locations");
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

        public static Label CreateLabel(Location location, int offsetX, int offsetY)
        {
            Label namelabel = new Label();
            namelabel.Location = new Point(location.Coordinates.Item1+offsetX,location.Coordinates.Item2+offsetY);
            namelabel.Text = location.Name; 
            namelabel.AutoSize = true;
            return namelabel;
        }

        public static int SaveFile<T>(ref T file, string fullPath)
        {
            try
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
                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public static int DeleteFile<T>(ref T file, string fullPath)
        {
            try
            {
                var exists = Directory.Exists(fullPath);
                Directory.Delete(fullPath, true);
                return 0;
            }
            catch (Exception ex)
            {
                return -1;
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

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
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
