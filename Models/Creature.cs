using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignGUI.Models
{
    public class Creature
    {
        public bool OverrideCalculations { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public Image Photo { get; set; }
        [JsonIgnore]
        public Image SecondPhoto { get; set; }
        public string Employment { get; set; }
        public List<Relationship> Relationships { get; set; }
        public List<Quest> Quests { get; set; }
        public int Age { get; set; }
        public int Level { get; set; }
        public string Alignment { get; set; }
        public string Race { get; set; }
        public int AC { get; set; }
        public int MaxHP { get; set; }
        public int HP { get; set; }
        public int TempHP { get; set; }
        public int[] Speeds { get; set; }
        public int[] Passives { get; set; }
        public string SpellcastingAbility { get; set; }
        public int SpellAttackBonus { get; set; }
        public int SpellSaveDC { get; set; }
        public int StrengthScore { get; set; }
        public int DexterityScore { get; set; }
        public int ConstitutionScore { get; set; }
        public int IntelligenceScore { get; set; }
        public int WisdomScore { get; set; }
        public int CharismaScore { get; set; }
        public int FailedDeathSaves { get; set; }
        public int SuccessfulDeathSaves { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string Skin { get; set; }
        public string Hair { get; set; }
        public string Eyes { get; set; }
        public ClassResource ClassResource1 { get; set; }
        public ClassResource ClassResource2 { get; set; }
        public string Description { get; set; }
        public string Inventory { get; set; }
        public string Attacks { get; set; }
        public string SpecialFeatures { get; set; }
        public string Vulnerabilities { get; set; }
        public string Resistances { get; set; }
        public string Immunities { get; set; }
        public string LanguageProficiencies { get; set; }
        public string ToolProficiencies { get; set; }
        public List<Proficiency> Proficiencies { get; set; }

    }
}
