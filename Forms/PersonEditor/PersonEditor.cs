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

namespace CampaignGUI.Forms.PersonEditor
{
    public partial class PersonEditor : Form
    {
        int DeathSavesFailed { get; set; }
        int DeathSavesSucceeded { get; set; }
        List<Proficiency> proficienciesList = new List<Proficiency>();
        int[] Speeds = new int[3];
        int[] Passives = new int[3];
        Image Image { get; set; }
        Image Image2 { get; set; }
        
        static Stat[] _stats = { new Stat { Acroynm = "str", Name = "Strength" }, new Stat { Acroynm = "dex", Name = "Dexterity" }, new Stat { Name = "Constitution", Acroynm = "con" }, 
            new Stat { Acroynm = "int", Name = "Intelligence" }, new Stat { Name = "Wisdom", Acroynm = "wis" }, new Stat { Name = "Charisma", Acroynm = "cha"} };
        ClassResource ClassResource1 { get; set; }
        ClassResource ClassResource2 { get; set; }
        public People Person { get; set; }
        public PersonEditor()
        {
            InitializeComponent();
            Person = new People();
            ClassResource1 = new ClassResource();
            ClassResource2 = new ClassResource();
        }

        public PersonEditor(People person)
        {
            InitializeComponent();
            Person = person;
            ClassResource1 = new ClassResource();
            ClassResource2 = new ClassResource();
        }

        private void save_Click(object sender, EventArgs e)
        {
            Person.ClassResource1 = ClassResource1;
            Person.ClassResource2 = ClassResource2;

            Person.Proficiencies = proficienciesList;

            Person.Passives = Passives;
            Person.Speeds = Speeds;

            DialogResult = DialogResult.OK;
        }

        private void PersonEditor_Load(object sender, EventArgs e)
        {
            try
            {
                name.DataBindings.Add("Text", Person, "Name");
                age.DataBindings.Add("Value", Person, "Age");
                level.DataBindings.Add("Value", Person, "Level");
                employment.DataBindings.Add("Text", Person, "Employment");
                alignment.DataBindings.Add("SelectedItem", Person, "Alignment");
                race.DataBindings.Add("Text", Person, "Race");
                weight.DataBindings.Add("Text", Person, "Weight");
                height.DataBindings.Add("Text", Person, "Height");
                skin.DataBindings.Add("Text", Person, "Skin");
                hair.DataBindings.Add("Text", Person, "Hair");
                eyes.DataBindings.Add("Text", Person, "Eyes");

                ac.DataBindings.Add("Value", Person, "AC");
                maxHP.DataBindings.Add("Value", Person, "MaxHP");
                hp.DataBindings.Add("Value", Person, "HP");
                tempHP.DataBindings.Add("Value", Person, "TempHP");

                spellcastingAbility.DataBindings.Add("SelectedItem", Person, "SpellcastingAbility");
                spellAttackBonus.DataBindings.Add("Value", Person, "SpellAttackBonus");
                spellSaveDC.DataBindings.Add("Value", Person, "SpellSaveDC");

                strScore.DataBindings.Add("Value", Person, "StrengthScore");
                dexScore.DataBindings.Add("Value", Person, "DexterityScore");
                conScore.DataBindings.Add("Value", Person, "ConstitutionScore");
                intScore.DataBindings.Add("Value", Person, "IntelligenceScore");
                wisScore.DataBindings.Add("Value", Person, "WisdomScore");
                chaScore.DataBindings.Add("Value", Person, "CharismaScore");

                description.DataBindings.Add("Text", Person, "Description");
                inventory.DataBindings.Add("Text", Person, "Inventory");
                attacksLabel.DataBindings.Add("Text", Person, "Attacks");
                specialFeatures.DataBindings.Add("Text", Person, "SpecialFeatures");
                vulnerabilities.DataBindings.Add("Text", Person, "Vulnerabilities");
                resistances.DataBindings.Add("Text", Person, "Resistances");
                immunities.DataBindings.Add("Text", Person, "Immunities");
                languageProficiencies.DataBindings.Add("Text", Person, "LanguageProficiencies");
                toolProficiencies.DataBindings.Add("Text", Person, "ToolProficiencies");

                overrideMods.DataBindings.Add("Checked", Person, "OverrideCalculations");

                classResource1.DataBindings.Add("Text", ClassResource1, "Name");
                maxResource1.DataBindings.Add("Value", ClassResource1, "Max");
                remainingResource1.DataBindings.Add("Value", ClassResource1, "Current");

                classResource2.DataBindings.Add("Text", ClassResource2, "Name");
                maxResource2.DataBindings.Add("Value", ClassResource2, "Max");
                remainingResource2.DataBindings.Add("Value", ClassResource2, "Current");


                Image = Person.Photo;
                Image2 = Person.SecondPhoto;

                if (Person.Speeds != null)
                {
                    Speeds[0] = Person.Speeds[0];
                    Speeds[1] = Person.Speeds[1];
                    Speeds[2] = Person.Speeds[2];
                }

                if (Person.Passives != null)
                {
                    Passives[0] = Person.Passives[0];
                    Passives[1] = Person.Passives[1];
                    Passives[2] = Person.Passives[2];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void upload2_Click(object sender, EventArgs e)
        {

        }

        private void upload_Click(object sender, EventArgs e)
        {

        }

        private void overrideMods_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkbox_Changed(object sender, EventArgs e)
        {
            var ele = sender as CheckBox;
            var eleName = ele.Name.Substring(ele.Name.Length - 5);
            var prof = proficienciesList.Where(l => l.Name == eleName).FirstOrDefault();
            if( prof != null)
            {
                prof.Proficient = !prof.Proficient;

            }
        }
    }
}
