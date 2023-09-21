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
            Person = new People(true);
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

                var scoreList = Controls.OfType<NumericUpDown>().Where(n => n.Name.ToLower().Contains("score")).ToList();
                scoreList.ForEach(score =>
                {
                    score.ValueChanged += new EventHandler(score_Changed);
                    string eleName = score.Name.Substring(0, 3) + "Mod";
                    var mod = Controls.OfType<TextBox>().Where(n => n.Name == eleName).FirstOrDefault();
                    if (mod != null)
                    {
                        mod.Text = CalculateModifier((double)score.Value).ToString();
                    }
                });

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

                var list = Controls.OfType<CheckBox>().Where(l => !l.Name.ToLower().Contains("death") && !l.Name.ToLower().Contains("override")).ToList();
                var list2 = Controls.OfType<NumericUpDown>().Where(p => p.Name.Contains("Mod")).ToList();

                foreach (var prof in Person.Proficiencies)
                {
                    var checkbox = list.Where(l => prof.Name.ToLower().Trim().Contains(l.Name.ToLower())).FirstOrDefault();
                    var numeric = list2.Where(l => prof.Name.Substring(0, prof.Name.Length - 6).ToLower() + "Mod" == l.Name).FirstOrDefault();
                    if (checkbox != null)
                        checkbox.Checked = prof.Proficient;
                    if (numeric != null)
                        numeric.Value = prof.Value;
                }

                proficienciesList = Person.Proficiencies;

                list.ForEach(checkbox => {
                    checkbox.CheckedChanged += new EventHandler(checkbox_Changed);
                });

                list2.ForEach(numeric =>
                {
                    numeric.ValueChanged += new EventHandler(proficiency_Changed);
                });

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

                if(!Person.OverrideCalculations)
                {
                    list2.ForEach(item =>
                    {
                        item.Enabled = false;
                    });
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

        private void proficiency_Changed(object sender, EventArgs e)
        {
            if (Person.OverrideCalculations)
            {
                var ele = sender as NumericUpDown;
                var name = ele.Name.Substring(0, ele.Name.Length - 3);
                var index = proficienciesList.FindIndex(p => p.Name.ToLower().Replace(" ", "").Contains(name));
                if (index != -1)
                    proficienciesList[index].Value = (int)ele.Value;
            }
        }

        private void overrideMods_CheckedChanged(object sender, EventArgs e)
        {
            var list2 = Controls.OfType<NumericUpDown>().Where(p => p.Name.Contains("Mod")).ToList();
            list2.ForEach(item =>
            {
                item.Enabled = !item.Enabled;
            });
        }

        private void score_Changed(object sender, EventArgs e)
        {
            NumericUpDown ele = sender as NumericUpDown;
            int oldMod = 0;
            string eleName = ele.Name.Substring(0, 3) + "Mod";
            var mod = Controls.OfType<TextBox>().Where(n => n.Name == eleName).FirstOrDefault();
            oldMod = int.Parse(mod.Text);
            if (mod != null)
            {
                mod.Text = CalculateModifier((double)ele.Value).ToString();
            }
            var score = _stats.Where(s => s.Acroynm.ToLower() == ele.Name.Substring(0, 3)).First();
            var list = Controls.OfType<CheckBox>().Where(l => l.Text.ToLower().Contains(score.Acroynm)).ToList();

            var list2 = Controls.OfType<NumericUpDown>().Where(n => n.Name.Contains("Mod")).ToList();
            list.ForEach(item =>
            {
                NumericUpDown num =  list2.Where(n => n.Name.ToLower().Substring(0, n.Name.Length - 3) == item.Name.ToLower()).FirstOrDefault();
                num.ValueChanged -= new EventHandler(proficiency_Changed);
                num.Value -= oldMod;
                num.Value += int.Parse(mod.Text);
                num.ValueChanged += new EventHandler(proficiency_Changed);
                if (!Person.OverrideCalculations)
                {
                    var name = num.Name.Substring(0, num.Name.Length - 3);
                    var index = proficienciesList.FindIndex(p => p.Name.ToLower().Replace(" ", "").Contains(name));
                    if (index != -1)
                        proficienciesList[index].Value = (int)ele.Value;
                }
            });
        }

        private int CalculateModifier(double score)
        {
            return (int)Math.Floor((score - 10) / 2);
        }

        private void checkbox_Changed(object sender, EventArgs e)
        {
            CheckBox ele = sender as CheckBox;
            string eleName = ele.Name;
            Stat stat = _stats.Where(s => eleName.ToLower().Contains(s.Acroynm)).FirstOrDefault();
            bool isSave = stat != null;
            if (isSave && eleName != "intimidation")
                eleName = stat.Name;
            var prof = proficienciesList.Where(l => l.Name.ToLower().Replace(" ", "").Contains(eleName.ToLower())).FirstOrDefault();
            var index = proficienciesList.IndexOf(prof);
            if( prof != null)
            {
                prof.Proficient = !prof.Proficient;
                NumericUpDown num = Controls.OfType<NumericUpDown>().Where(n => n.Name.ToLower().Contains(eleName.ToLower())).FirstOrDefault();
                if(isSave)
                    num = Controls.OfType<NumericUpDown>().Where(n => n.Name.ToLower().Contains(stat.Acroynm.ToLower()) && !n.Name.ToLower().Contains("intimidation")).FirstOrDefault();
                if (prof.Proficient)
                {                                        
                    num.Value += Person.ProficiencyBonus;
                    prof.Value += Person.ProficiencyBonus;                    
                }
                else
                {
                    num.Value -= Person.ProficiencyBonus;
                    prof.Value -= Person.ProficiencyBonus;
                }
                proficienciesList[index] = prof;
            }
        }

        private void dexMod_TextChanged(object sender, EventArgs e)
        {

        }

        private void strMod_TextChanged(object sender, EventArgs e)
        {

        }

        private void conMod_TextChanged(object sender, EventArgs e)
        {

        }

        private void intMod_TextChanged(object sender, EventArgs e)
        {

        }

        private void wisMod_TextChanged(object sender, EventArgs e)
        {

        }

        private void chaMod_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
