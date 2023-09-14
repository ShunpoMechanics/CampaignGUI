
namespace CampaignGUI.Forms.LocationDisplay
{
    partial class LocationDisplay
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.locationNameLabel = new System.Windows.Forms.Label();
            this.locationNameValue = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(170, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(607, 390);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // locationNameLabel
            // 
            this.locationNameLabel.AutoSize = true;
            this.locationNameLabel.Location = new System.Drawing.Point(22, 33);
            this.locationNameLabel.Name = "locationNameLabel";
            this.locationNameLabel.Size = new System.Drawing.Size(72, 13);
            this.locationNameLabel.TabIndex = 1;
            this.locationNameLabel.Text = "locationName";
            // 
            // locationNameValue
            // 
            this.locationNameValue.Location = new System.Drawing.Point(25, 65);
            this.locationNameValue.Name = "locationNameValue";
            this.locationNameValue.Size = new System.Drawing.Size(100, 20);
            this.locationNameValue.TabIndex = 2;
            this.locationNameValue.TextChanged += new System.EventHandler(this.locationNameValue_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(25, 141);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // LocationDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.locationNameValue);
            this.Controls.Add(this.locationNameLabel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "LocationDisplay";
            this.Text = "LocationDisplay";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LocationDisplay_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.LocationDisplay_Load);
            this.Enter += new System.EventHandler(this.LocationDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label locationNameLabel;
        private System.Windows.Forms.TextBox locationNameValue;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}