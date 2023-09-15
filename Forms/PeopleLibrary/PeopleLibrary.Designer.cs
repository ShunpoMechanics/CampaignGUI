
namespace CampaignGUI.Forms.PeopleLibrary
{
    partial class PeopleLibrary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.personList = new System.Windows.Forms.ListBox();
            this.newPerson = new System.Windows.Forms.Button();
            this.editPerson = new System.Windows.Forms.Button();
            this.deletePerson = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // personList
            // 
            this.personList.FormattingEnabled = true;
            this.personList.Location = new System.Drawing.Point(32, 30);
            this.personList.Name = "personList";
            this.personList.Size = new System.Drawing.Size(236, 394);
            this.personList.TabIndex = 0;
            // 
            // newPerson
            // 
            this.newPerson.Location = new System.Drawing.Point(364, 30);
            this.newPerson.Name = "newPerson";
            this.newPerson.Size = new System.Drawing.Size(75, 23);
            this.newPerson.TabIndex = 1;
            this.newPerson.Text = "New";
            this.newPerson.UseVisualStyleBackColor = true;
            this.newPerson.Click += new System.EventHandler(this.newPerson_Click);
            // 
            // editPerson
            // 
            this.editPerson.Location = new System.Drawing.Point(364, 79);
            this.editPerson.Name = "editPerson";
            this.editPerson.Size = new System.Drawing.Size(75, 23);
            this.editPerson.TabIndex = 2;
            this.editPerson.Text = "Edit";
            this.editPerson.UseVisualStyleBackColor = true;
            this.editPerson.Click += new System.EventHandler(this.editPerson_Click);
            // 
            // deletePerson
            // 
            this.deletePerson.Location = new System.Drawing.Point(364, 126);
            this.deletePerson.Name = "deletePerson";
            this.deletePerson.Size = new System.Drawing.Size(75, 23);
            this.deletePerson.TabIndex = 3;
            this.deletePerson.Text = "Delete";
            this.deletePerson.UseVisualStyleBackColor = true;
            this.deletePerson.Click += new System.EventHandler(this.deletePerson_Click);
            // 
            // PeopleLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 450);
            this.Controls.Add(this.deletePerson);
            this.Controls.Add(this.editPerson);
            this.Controls.Add(this.newPerson);
            this.Controls.Add(this.personList);
            this.Name = "PeopleLibrary";
            this.Text = "People Library";
            this.Load += new System.EventHandler(this.PeopleLibrary_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox personList;
        private System.Windows.Forms.Button newPerson;
        private System.Windows.Forms.Button editPerson;
        private System.Windows.Forms.Button deletePerson;
    }
}