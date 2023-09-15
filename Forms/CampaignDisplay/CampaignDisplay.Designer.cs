
namespace CampaignGUI
{
    partial class CampaignDisplay
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
            this.image1 = new System.Windows.Forms.PictureBox();
            this.upload = new System.Windows.Forms.Button();
            this.campaignName = new System.Windows.Forms.Label();
            this.campaignNameValue = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Button();
            this.upscale = new System.Windows.Forms.CheckBox();
            this.peopleLibrary = new System.Windows.Forms.Button();
            this.monsterLibrary = new System.Windows.Forms.Button();
            this.itemLibrary = new System.Windows.Forms.Button();
            this.questLibrary = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.image1)).BeginInit();
            this.SuspendLayout();
            // 
            // image1
            // 
            this.image1.Location = new System.Drawing.Point(257, 34);
            this.image1.Name = "image1";
            this.image1.Size = new System.Drawing.Size(1327, 553);
            this.image1.TabIndex = 0;
            this.image1.TabStop = false;
            this.image1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // upload
            // 
            this.upload.Location = new System.Drawing.Point(12, 34);
            this.upload.Name = "upload";
            this.upload.Size = new System.Drawing.Size(168, 23);
            this.upload.TabIndex = 1;
            this.upload.Text = "Upload a Map";
            this.upload.UseVisualStyleBackColor = true;
            this.upload.Click += new System.EventHandler(this.upload_Click);
            // 
            // campaignName
            // 
            this.campaignName.AutoSize = true;
            this.campaignName.Location = new System.Drawing.Point(9, 93);
            this.campaignName.Name = "campaignName";
            this.campaignName.Size = new System.Drawing.Size(85, 13);
            this.campaignName.TabIndex = 2;
            this.campaignName.Text = "Campaign Name";
            // 
            // campaignNameValue
            // 
            this.campaignNameValue.Location = new System.Drawing.Point(12, 118);
            this.campaignNameValue.Name = "campaignNameValue";
            this.campaignNameValue.Size = new System.Drawing.Size(200, 20);
            this.campaignNameValue.TabIndex = 3;
            this.campaignNameValue.TextChanged += new System.EventHandler(this.campaignNamValue_TextChanged);
            this.campaignNameValue.Leave += new System.EventHandler(this.campaignNamValue_TextChanged);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(15, 479);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 4;
            this.save.Text = "Save Changes";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // upscale
            // 
            this.upscale.AutoSize = true;
            this.upscale.Location = new System.Drawing.Point(15, 63);
            this.upscale.Name = "upscale";
            this.upscale.Size = new System.Drawing.Size(71, 17);
            this.upscale.TabIndex = 5;
            this.upscale.Text = "Upscale?";
            this.upscale.UseVisualStyleBackColor = true;
            // 
            // peopleLibrary
            // 
            this.peopleLibrary.Location = new System.Drawing.Point(12, 171);
            this.peopleLibrary.Name = "peopleLibrary";
            this.peopleLibrary.Size = new System.Drawing.Size(98, 23);
            this.peopleLibrary.TabIndex = 6;
            this.peopleLibrary.Text = "People Library";
            this.peopleLibrary.UseVisualStyleBackColor = true;
            this.peopleLibrary.Click += new System.EventHandler(this.peopleLibrary_Click);
            // 
            // monsterLibrary
            // 
            this.monsterLibrary.Location = new System.Drawing.Point(116, 171);
            this.monsterLibrary.Name = "monsterLibrary";
            this.monsterLibrary.Size = new System.Drawing.Size(96, 23);
            this.monsterLibrary.TabIndex = 7;
            this.monsterLibrary.Text = "Monster Library";
            this.monsterLibrary.UseVisualStyleBackColor = true;
            this.monsterLibrary.Click += new System.EventHandler(this.monsterLibrary_Click);
            // 
            // itemLibrary
            // 
            this.itemLibrary.Location = new System.Drawing.Point(12, 200);
            this.itemLibrary.Name = "itemLibrary";
            this.itemLibrary.Size = new System.Drawing.Size(98, 23);
            this.itemLibrary.TabIndex = 8;
            this.itemLibrary.Text = "Item Library";
            this.itemLibrary.UseVisualStyleBackColor = true;
            this.itemLibrary.Click += new System.EventHandler(this.itemLibrary_Click);
            // 
            // questLibrary
            // 
            this.questLibrary.Location = new System.Drawing.Point(116, 200);
            this.questLibrary.Name = "questLibrary";
            this.questLibrary.Size = new System.Drawing.Size(96, 23);
            this.questLibrary.TabIndex = 9;
            this.questLibrary.Text = "Quest Library";
            this.questLibrary.UseVisualStyleBackColor = true;
            this.questLibrary.Click += new System.EventHandler(this.questLibrary_Click);
            // 
            // CampaignDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1625, 608);
            this.Controls.Add(this.questLibrary);
            this.Controls.Add(this.itemLibrary);
            this.Controls.Add(this.monsterLibrary);
            this.Controls.Add(this.peopleLibrary);
            this.Controls.Add(this.upscale);
            this.Controls.Add(this.save);
            this.Controls.Add(this.campaignNameValue);
            this.Controls.Add(this.campaignName);
            this.Controls.Add(this.upload);
            this.Controls.Add(this.image1);
            this.Name = "CampaignDisplay";
            this.Text = "CampaignGUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.image1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox image1;
        private System.Windows.Forms.Button upload;
        private System.Windows.Forms.Label campaignName;
        private System.Windows.Forms.TextBox campaignNameValue;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.CheckBox upscale;
        private System.Windows.Forms.Button peopleLibrary;
        private System.Windows.Forms.Button monsterLibrary;
        private System.Windows.Forms.Button itemLibrary;
        private System.Windows.Forms.Button questLibrary;
    }
}

