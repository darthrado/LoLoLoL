namespace LoL_Champions_and_Positions
{
    partial class MatchupDetails
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
            this.championImage = new System.Windows.Forms.PictureBox();
            this.enemyImage = new System.Windows.Forms.PictureBox();
            this.editButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.matchupDetailsText = new System.Windows.Forms.RichTextBox();
            this.championName = new System.Windows.Forms.TextBox();
            this.enemyName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.championImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyImage)).BeginInit();
            this.SuspendLayout();
            // 
            // championImage
            // 
            this.championImage.Location = new System.Drawing.Point(12, 12);
            this.championImage.Name = "championImage";
            this.championImage.Size = new System.Drawing.Size(120, 120);
            this.championImage.TabIndex = 0;
            this.championImage.TabStop = false;
            // 
            // enemyImage
            // 
            this.enemyImage.Location = new System.Drawing.Point(219, 12);
            this.enemyImage.Name = "enemyImage";
            this.enemyImage.Size = new System.Drawing.Size(120, 120);
            this.enemyImage.TabIndex = 1;
            this.enemyImage.TabStop = false;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(138, 12);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(138, 41);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // backButton
            // 
            this.backButton.Enabled = false;
            this.backButton.Location = new System.Drawing.Point(138, 70);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 4;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // matchupDetailsText
            // 
            this.matchupDetailsText.Location = new System.Drawing.Point(12, 174);
            this.matchupDetailsText.Name = "matchupDetailsText";
            this.matchupDetailsText.ReadOnly = true;
            this.matchupDetailsText.Size = new System.Drawing.Size(327, 274);
            this.matchupDetailsText.TabIndex = 5;
            this.matchupDetailsText.Text = "";
            // 
            // championName
            // 
            this.championName.Location = new System.Drawing.Point(12, 138);
            this.championName.Name = "championName";
            this.championName.ReadOnly = true;
            this.championName.Size = new System.Drawing.Size(120, 22);
            this.championName.TabIndex = 6;
            // 
            // enemyName
            // 
            this.enemyName.Location = new System.Drawing.Point(219, 143);
            this.enemyName.Name = "enemyName";
            this.enemyName.ReadOnly = true;
            this.enemyName.Size = new System.Drawing.Size(120, 22);
            this.enemyName.TabIndex = 7;
            // 
            // MatchupDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 460);
            this.Controls.Add(this.enemyName);
            this.Controls.Add(this.championName);
            this.Controls.Add(this.matchupDetailsText);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.enemyImage);
            this.Controls.Add(this.championImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MatchupDetails";
            this.Text = "MatchupDetails";
            ((System.ComponentModel.ISupportInitialize)(this.championImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox championImage;
        private System.Windows.Forms.PictureBox enemyImage;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.RichTextBox matchupDetailsText;
        private System.Windows.Forms.TextBox championName;
        private System.Windows.Forms.TextBox enemyName;
    }
}