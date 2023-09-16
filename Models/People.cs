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
    public class People: Creature
    {
        public int ProficiencyBonus { get; set; }
        public Guid Id { get; set; }

        public People()
        {
            Id = Guid.NewGuid();
            Proficiencies = new List<Proficiency>();            
            Relationships = new List<Relationship>();
            Quests = new List<Quest>();            
        }
        public People(bool newPerson)
        {
            Id = Guid.NewGuid();
            Proficiencies = new List<Proficiency>();            
            Relationships = new List<Relationship>();
            Quests = new List<Quest>();
            string scores = File.ReadAllText("../Ability Scores.txt");
            Proficiencies = JsonConvert.DeserializeObject<List<Proficiency>>(scores);
        }
        public static People FromFile(string content)
        {
            People person = JsonConvert.DeserializeObject<People>(content);
            Image image;

            string path = Path.Combine(Utils.GetDocumentsPath(), Utils.GetLastOpened(), $"People\\{person.Id}", "photo1.jpg");

            if (File.Exists(Path.Combine(Utils.GetDocumentsPath(), Utils.GetLastOpened(), $"People\\{person.Id}", "photo1.jpg")))
            {
                using (var bmpTemp = new Bitmap(path))
                {
                    image = new Bitmap(bmpTemp);
                }
                person.Photo = image;
            }
            if (File.Exists(Path.Combine(Utils.GetDocumentsPath(), Utils.GetLastOpened(), $"People\\{person.Id}", "photo2.jpg")))
            { 
                path = Path.Combine(Utils.GetDocumentsPath(), Utils.GetLastOpened(), $"People\\{person.Id}", "photo2.jpg");
                using (var bmpTemp = new Bitmap(path))
                {
                    image = new Bitmap(bmpTemp);
                }
                person.SecondPhoto = image;
            }
            person.ProficiencyBonus = CalculateProficiencyBonus(person.Level);
            return person;
        }

        public static int CalculateProficiencyBonus(int level)
        {
            return (int) Math.Floor(2 + (((double)level - 1) / 4));
        }

    }
}
