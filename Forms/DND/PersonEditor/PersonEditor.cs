using CampaignGUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampaignGUI.Forms.DND.PersonEditor
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
                strScore.Value = Person.StrengthScore;
                dexScore.DataBindings.Add("Value", Person, "DexterityScore");
                dexScore.Value = Person.DexterityScore;
                conScore.DataBindings.Add("Value", Person, "ConstitutionScore");
                conScore.Value = Person.ConstitutionScore;
                intScore.DataBindings.Add("Value", Person, "IntelligenceScore");
                intScore.Value = Person.IntelligenceScore;
                wisScore.DataBindings.Add("Value", Person, "WisdomScore");
                wisScore.Value = Person.WisdomScore;
                chaScore.DataBindings.Add("Value", Person, "CharismaScore");
                chaScore.Value = Person.CharismaScore;

                level.DataBindings.Add("Value", Person, "Level");

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
                attacks.DataBindings.Add("Text", Person, "Attacks");
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
                    var checkbox = list.Where(l => prof.Name.ToLower().Replace(" ", "").Contains(l.Name.ToLower())).FirstOrDefault();
                    var numeric = list2.Where(l => prof.Name.Substring(0, prof.Name.Length - 6).Replace(" ", "").ToLower() + "mod" == l.Name.ToLower()).FirstOrDefault();
                    if (checkbox != null)
                    {
                        var checkState = 0;
                        if (prof.Proficient)
                            checkState += 1;
                        if (prof.Expertise)
                            checkState += 1;
                        checkbox.CheckState = (CheckState)checkState;
                    }   
                    if (Person.OverrideCalculations)
                    {
                        if (numeric != null)
                            numeric.Value = prof.Value;
                    }
                    else
                    {
                        var score = scoreList.Where(s => s.Name.Contains(prof.Stat.Substring(0,3).ToLower())).FirstOrDefault();
                        var mod = CalculateModifier((double)score.Value);
                        if (numeric != null)
                        {
                            numeric.Value = mod;
                            if (prof.Proficient)
                                numeric.Value += Person.ProficiencyBonus;
                            if (prof.Expertise)
                                numeric.Value += Person.ProficiencyBonus;
                        }
                    }
                }

                proficienciesList = Person.Proficiencies;

                list.ForEach(checkbox => {
                    checkbox.CheckStateChanged += new EventHandler(checkbox_Changed);
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
                else
                {
                    list2.ForEach(item =>
                    {
                        item.Enabled = true;
                    });
                }

                var path = Path.Combine(Utils.GetPeoplePath(), Person.Id.ToString(), "photo1.jpg");
                if (File.Exists(path))
                {
                    Image image = Image.FromFile(path);
                    image = Utils.ResizeImage(image, 257, 382);
                    Person.Photo = image;
                    peopleImage.Image = image;
                    peopleImage.Width = image.Width;
                    peopleImage.Height = image.Height;
                }

                path = Path.Combine(Utils.GetPeoplePath(), Person.Id.ToString(), "photo2.jpg");
                if (File.Exists(path))
                {
                    Image image2 = Image.FromFile(path);
                    image2 = Utils.ResizeImage(image2, 257, 220);
                    Person.Photo = image2;
                    additionalImage.Image = image2;
                    additionalImage.Width = image2.Width;
                    additionalImage.Height = image2.Height;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void upload2_Click(object sender, EventArgs e)
        {
            additionalImage_Click(sender, e);
        }

        private void upload_Click(object sender, EventArgs e)
        {
            peopleImage_Click(sender, e);
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
            try
            {
                if (!Person.OverrideCalculations)
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
                        NumericUpDown num = list2.Where(n => n.Name.ToLower().Substring(0, n.Name.Length - 3) == item.Name.ToLower()).FirstOrDefault();
                        num.ValueChanged -= new EventHandler(proficiency_Changed);
                        var value = 0;
                        if (item.CheckState == CheckState.Checked)
                            value += Person.ProficiencyBonus;
                        if (item.CheckState == CheckState.Indeterminate)
                            value += Person.ProficiencyBonus*2;
                        value += int.Parse(mod.Text);
                        num.Value = value;
                        num.ValueChanged += new EventHandler(proficiency_Changed);
                        
                        var name = num.Name.Substring(0, num.Name.Length - 3);
                        var index = proficienciesList.FindIndex(p => p.Name.ToLower().Replace(" ", "").Contains(name.ToLower()));
                        if (index != -1)
                            proficienciesList[index].Value = int.Parse(mod.Text);                        
                    });
                }
            }
            catch (Exception ex)
            {

            }
        }

        private int CalculateModifier(double score)
        {
            return (int)Math.Floor((score - 10) / 2);
        }

        private void checkbox_Changed(object sender, EventArgs e)
        {
            if (!Person.OverrideCalculations)
            {
                CheckBox ele = sender as CheckBox;
                string eleName = ele.Name;
                Stat stat = _stats.Where(s => eleName.ToLower().Contains(s.Acroynm)).FirstOrDefault();
                bool isSave = stat != null;
                if (isSave && eleName != "intimidation")
                    eleName = stat.Name;
                var prof = proficienciesList.Where(l => l.Name.ToLower().Replace(" ", "").Contains(eleName.ToLower())).FirstOrDefault();
                var index = proficienciesList.IndexOf(prof);
                if (prof != null)
                {
                    prof.Proficient = ele.CheckState == CheckState.Checked || ele.CheckState == CheckState.Indeterminate;
                    prof.Expertise = ele.CheckState == CheckState.Indeterminate;

                    NumericUpDown num = Controls.OfType<NumericUpDown>().Where(n => n.Name.ToLower().Contains(eleName.ToLower())).FirstOrDefault();
                    if (isSave)
                        num = Controls.OfType<NumericUpDown>().Where(n => n.Name.ToLower().Contains(stat.Acroynm.ToLower()) && !n.Name.ToLower().Contains("intimidation")).FirstOrDefault();
                    if (prof.Proficient || prof.Expertise)
                    {
                        num.Value += Person.ProficiencyBonus;
                        prof.Value += Person.ProficiencyBonus;
                    }
                    else
                    {
                        num.Value -= Person.ProficiencyBonus*2;
                        prof.Value -= Person.ProficiencyBonus*2;

                        proficienciesList[index] = prof;
                    }
                }
            }
        }

        private void peopleImage_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = dialog.FileName;

                    //image1.ImageLocation = imageLocation;
                    Image image = Image.FromFile(dialog.FileName);
                    image = Utils.ResizeImage(image, 257, 382);                    
                    Person.Photo = image;
                    peopleImage.Image = image;
                    peopleImage.Width = image.Width;
                    peopleImage.Height = image.Height;
                    Utils.CopyUploadedImage(imageLocation, Path.Combine(Utils.GetPeoplePath(), Person.Id.ToString()), "photo1.jpg");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void additionalImage_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = dialog.FileName;

                    //image1.ImageLocation = imageLocation;
                    Image image = Image.FromFile(dialog.FileName);
                    image = Utils.ResizeImage(image, 257, 220);

                    Person.Photo = image;
                    additionalImage.Image = image;
                    additionalImage.Width = image.Width;
                    additionalImage.Height = image.Height;
                    Utils.CopyUploadedImage(imageLocation, Path.Combine(Utils.GetPeoplePath(), Person.Id.ToString()), "photo2.jpg");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void level_ValueChanged(object sender, EventArgs e)
        {
            var ele = sender as NumericUpDown;
            var proficiencyBonus = People.CalculateProficiencyBonus((int)ele.Value);
            Person.ProficiencyBonus = proficiencyBonus;
            var list = Controls.OfType<NumericUpDown>().Where(m => m.Name.Contains("Score")).ToList();
            list.ForEach(item => {
                item.Value -= 1;
                item.Value += 1;
            }); 
        }

        private void flyingSpeed_ValueChanged(object sender, EventArgs e)
        {
            var ele = sender as NumericUpDown;
            Person.Speeds[0] = (int)ele.Value;
        }

        private void walkSpeed_ValueChanged(object sender, EventArgs e)
        {
            var ele = sender as NumericUpDown;
            Person.Speeds[1] = (int)ele.Value;
        }

        private void swimSpeed_ValueChanged(object sender, EventArgs e)
        {
            var ele = sender as NumericUpDown;
            Person.Speeds[2] = (int)ele.Value;
        }
    }
}
