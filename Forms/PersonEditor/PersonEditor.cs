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
        private void PersonEditor_Load(object sender, EventArgs e)
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
            //upload.DataBindings.Add("Image", Person, "Photo");
            //additionalImage.DataBindings.Add("Image", Person, "SecondPhoto");
            ac.DataBindings.Add("Value", Person, "AC");
            maxHP.DataBindings.Add("Value", Person, "MaxHP");
            hp.DataBindings.Add("Value", Person, "HP");
            tempHP.DataBindings.Add("Value", Person, "TempHP");

            //flyingSpeed.DataBindings.Add("Value", Person, "Speeds[0]");
            //flyingSpeed.BindingContext[Person].Position = 0;

            //walkSpeed.DataBindings.Add("Value", Person, "Speeds");
            //walkSpeed.BindingContext[Person].Position = 1;

            //swimSpeed.DataBindings.Add("Value", Person, "Speeds");
            //swimSpeed.BindingContext[Person].Position = 2;

            spellcastingAbility.DataBindings.Add("SelectedItem", Person, "SpellcastingAbility");
            spellAttackBonus.DataBindings.Add("Value", Person, "SpellAttackBonus");
            spellSaveDC.DataBindings.Add("Value", Person, "SpellSaveDC");

            //passivePerception.DataBindings.Add("Value", Person, "Passives");
            //passivePerception.BindingContext[Person].Position = 0;

            //passiveInvestigation.DataBindings.Add("Value", Person, "Passives");
            //passiveInvestigation.BindingContext[Person].Position = 1;

            //passiveInsight.DataBindings.Add("Value", Person, "Passives");
            //passiveInsight.BindingContext[Person].Position = 2;

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

            var list = Controls.OfType<NumericUpDown>().ToList();
            var list2 = Controls.OfType<CheckBox>().Where(w => !w.Name.ToLower().Contains("death") && !w.Name.ToLower().Contains("override")).ToList();
            var list3 = Controls.OfType<TextBox>().Where(l => l.Name.ToLower().Contains("customskill")).ToList();
            var proficiencies = new List<Proficiency>();

            foreach (var item in list2)
            {
                Proficiency prof = new Proficiency();
                prof.Name = item.Text;
                prof.Proficient = item.Checked;
                if (item.Text == "")
                {
                    prof.Name = item.Name;
                    var label = list3.Where(i => i.Name == prof.Name + "Label").First();
                    var stat = label.Text.Substring(label.Text.Length - 4, 3).ToLower();
                    prof.Stat = _stats.Where(s => s.Acroynm == stat).First().Name;
                }        
                else
                {
                    var stat = item.Text.Substring(prof.Name.Length - 4, 3).ToLower();
                    prof.Stat = _stats.Where(s => s.Acroynm == stat).First().Name;
                }
                proficiencies.Add(prof);
            }

            proficienciesList = proficiencies;
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

        private void performance_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dexSave_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void conSave_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void wisSave_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void intSave_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chaSave_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void athletics_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void acrobatics_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void sleightOfHand_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void stealth_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void animalHandling_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void insight_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void medicine_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void perception_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void survival_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void arcana_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void history_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void investigation_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void nature_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void religion_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void deception_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void intimidation_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void persuasion_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void strSave_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void customSkill5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void customSkill4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void customSkill3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void customSkill2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void customSkill1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void customSkillLabel1_TextChanged(object sender, EventArgs e)
        {

        }

        private void customSkill5Label_TextChanged(object sender, EventArgs e)
        {

        }

        private void customSkill4Label_TextChanged(object sender, EventArgs e)
        {

        }

        private void customSkillLabel3_TextChanged(object sender, EventArgs e)
        {

        }

        private void customSkillLabel2_TextChanged(object sender, EventArgs e)
        {

        }

        private void quests_Click(object sender, EventArgs e)
        {

        }

        private void relationships_Click(object sender, EventArgs e)
        {

        }

        private void chaScore_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dexScore_ValueChanged(object sender, EventArgs e)
        {

        }

        private void conScore_ValueChanged(object sender, EventArgs e)
        {

        }

        private void intScore_ValueChanged(object sender, EventArgs e)
        {

        }

        private void wisScore_ValueChanged(object sender, EventArgs e)
        {

        }

        private void strScore_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void level_ValueChanged(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            Person.ClassResource1 = ClassResource1;
            Person.ClassResource2 = ClassResource2;

            DialogResult = DialogResult.OK;
        }
    }
}
