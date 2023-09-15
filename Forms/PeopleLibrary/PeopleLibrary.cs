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
using CampaignGUI.Models;

namespace CampaignGUI.Forms.PeopleLibrary
{
    public partial class PeopleLibrary : Form
    {
        //public List<People> People { get; set; }
        public CampaignDisplay CampaignDisplay { get; set; }
        BindingList<People> People = new BindingList<People>();
        public string Filepath { get; set; }
        public PeopleLibrary()
        {
            InitializeComponent();
            People = new BindingList<People>();
            ShowData();
            Filepath = Utils.GetPeoplePath();
        }

        public PeopleLibrary(CampaignDisplay campaignDisplay)
        {
            InitializeComponent();
            CampaignDisplay = campaignDisplay;
            People = new BindingList<People>();
            Filepath = Utils.GetPeoplePath();
            ShowData();
        }

        private void ShowData()
        {
            personList.DataSource = null;
            personList.DataSource = People;
            personList.DisplayMember = "Name";
            personList.ValueMember = "Id";
        }

        private void PeopleLibrary_Load(object sender, EventArgs e)
        {
            People = new BindingList<People>(CampaignDisplay.Campaign.PeopleLibrary);
            ShowData();
        }

        private void newPerson_Click(object sender, EventArgs e)
        {
            PersonEditor.PersonEditor editor = new PersonEditor.PersonEditor();
            if (editor.ShowDialog() == DialogResult.OK)
            {
                People person = editor.Person;
                if(person != null)
                    People.Add(person);

                if (!Directory.Exists($"{Filepath}\\{person.Id}"))
                    Directory.CreateDirectory($"{Filepath}\\{person.Id}");
                // Save person to File
                Utils.SaveFile(ref person, $"{Filepath}\\{person.Id}\\{person.Id}.txt"); 
                ShowData();
            }    

        }

        private void editPerson_Click(object sender, EventArgs e)
        {
            People person = (People)personList.SelectedItem;
            PersonEditor.PersonEditor editor = new PersonEditor.PersonEditor(person);
            
            if (editor.ShowDialog() == DialogResult.OK)
            {
                var index = People.IndexOf(person);
                person = editor.Person;
                People[index] = person;

                if (!Directory.Exists($"{Filepath}\\{person.Id}"))
                    Directory.CreateDirectory($"{Filepath}\\{person.Id}");

                // Save person to File
                Utils.SaveFile(ref person, $"{Filepath}\\{person.Id}\\{person.Id}.txt");
                ShowData();
            };
        }

        private void deletePerson_Click(object sender, EventArgs e)
        {
            People person = (People)personList.SelectedItem;
            var confirmSave = MessageBox.Show($"Are you sure you want to delete {person.Name}?",
                                                 "Confirm Deletion of Person",
                                                 MessageBoxButtons.YesNo);
            if (confirmSave == DialogResult.Yes)
            {
                string path = $"{Filepath}\\{person.Id}";
                Utils.DeleteFile(ref person, path);
                People.Remove(person);
                ShowData();
            }
            else
            {
                // If 'No', do something here.
            }
        }
    }
}
