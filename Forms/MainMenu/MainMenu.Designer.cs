
namespace CampaignGUI.Forms.MainMenu
{
    partial class MainMenu
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
            this.newCampaign = new System.Windows.Forms.Button();
            this.loadCampaign = new System.Windows.Forms.Button();
            this.exitApp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newCampaign
            // 
            this.newCampaign.Location = new System.Drawing.Point(315, 102);
            this.newCampaign.Name = "newCampaign";
            this.newCampaign.Size = new System.Drawing.Size(191, 46);
            this.newCampaign.TabIndex = 0;
            this.newCampaign.Text = "New Campaign";
            this.newCampaign.UseVisualStyleBackColor = true;
            this.newCampaign.Click += new System.EventHandler(this.newCampaign_Click);
            // 
            // loadCampaign
            // 
            this.loadCampaign.Location = new System.Drawing.Point(315, 171);
            this.loadCampaign.Name = "loadCampaign";
            this.loadCampaign.Size = new System.Drawing.Size(191, 45);
            this.loadCampaign.TabIndex = 1;
            this.loadCampaign.Text = "Load Campaign";
            this.loadCampaign.UseVisualStyleBackColor = true;
            this.loadCampaign.Click += new System.EventHandler(this.loadCampaign_Click);
            // 
            // exitApp
            // 
            this.exitApp.Location = new System.Drawing.Point(315, 242);
            this.exitApp.Name = "exitApp";
            this.exitApp.Size = new System.Drawing.Size(191, 47);
            this.exitApp.TabIndex = 2;
            this.exitApp.Text = "Exit App";
            this.exitApp.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exitApp);
            this.Controls.Add(this.loadCampaign);
            this.Controls.Add(this.newCampaign);
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newCampaign;
        private System.Windows.Forms.Button loadCampaign;
        private System.Windows.Forms.Button exitApp;
    }
}