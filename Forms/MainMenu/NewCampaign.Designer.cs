
namespace CampaignGUI.Forms.MainMenu
{
    partial class NewCampaign
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
            this.campaignNameValue = new System.Windows.Forms.TextBox();
            this.campaignNameLabel = new System.Windows.Forms.Label();
            this.createCampaign = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // campaignNameValue
            // 
            this.campaignNameValue.Location = new System.Drawing.Point(292, 120);
            this.campaignNameValue.Name = "campaignNameValue";
            this.campaignNameValue.Size = new System.Drawing.Size(170, 20);
            this.campaignNameValue.TabIndex = 0;
            // 
            // campaignNameLabel
            // 
            this.campaignNameLabel.AutoSize = true;
            this.campaignNameLabel.Location = new System.Drawing.Point(194, 127);
            this.campaignNameLabel.Name = "campaignNameLabel";
            this.campaignNameLabel.Size = new System.Drawing.Size(85, 13);
            this.campaignNameLabel.TabIndex = 1;
            this.campaignNameLabel.Text = "Campaign Name";
            // 
            // createCampaign
            // 
            this.createCampaign.Location = new System.Drawing.Point(387, 268);
            this.createCampaign.Name = "createCampaign";
            this.createCampaign.Size = new System.Drawing.Size(75, 23);
            this.createCampaign.TabIndex = 2;
            this.createCampaign.Text = "Create";
            this.createCampaign.UseVisualStyleBackColor = true;
            this.createCampaign.Click += new System.EventHandler(this.createCampaign_Click);
            // 
            // NewCampaign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.createCampaign);
            this.Controls.Add(this.campaignNameLabel);
            this.Controls.Add(this.campaignNameValue);
            this.Name = "NewCampaign";
            this.Text = "New Campaign";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox campaignNameValue;
        private System.Windows.Forms.Label campaignNameLabel;
        private System.Windows.Forms.Button createCampaign;
    }
}