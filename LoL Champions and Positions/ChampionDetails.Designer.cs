namespace LoL_Champions_and_Positions
{
    partial class ChampionDetails
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 120);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(12, 192);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(120, 120);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(152, 41);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(225, 271);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(152, 12);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(271, 12);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(106, 23);
            this.editButton.TabIndex = 4;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // ChampionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 322);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ChampionDetails";
            this.Text = "ChampionDetails";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button editButton;
    }
}