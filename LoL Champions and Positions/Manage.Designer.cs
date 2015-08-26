namespace LoL_Champions_and_Positions
{
    partial class Manage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manage));
            this.ListBox = new System.Windows.Forms.ListBox();
            this.Ok = new System.Windows.Forms.Button();
            this.SearchBar = new System.Windows.Forms.TextBox();
            this.AddNew = new System.Windows.Forms.Button();
            this.DeleteItem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ItemName = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PictureName = new System.Windows.Forms.TextBox();
            this.Picture = new System.Windows.Forms.PictureBox();
            this.ReloadImage = new System.Windows.Forms.Button();
            this.EditItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // ListBox
            // 
            this.ListBox.FormattingEnabled = true;
            this.ListBox.ItemHeight = 16;
            this.ListBox.Location = new System.Drawing.Point(16, 53);
            this.ListBox.Margin = new System.Windows.Forms.Padding(4);
            this.ListBox.Name = "ListBox";
            this.ListBox.Size = new System.Drawing.Size(163, 436);
            this.ListBox.TabIndex = 0;
            this.ListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // Ok
            // 
            this.Ok.Location = new System.Drawing.Point(188, 462);
            this.Ok.Margin = new System.Windows.Forms.Padding(4);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(160, 28);
            this.Ok.TabIndex = 2;
            this.Ok.Text = "Ok";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // SearchBar
            // 
            this.SearchBar.Location = new System.Drawing.Point(16, 15);
            this.SearchBar.Margin = new System.Windows.Forms.Padding(4);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(163, 22);
            this.SearchBar.TabIndex = 4;
            this.SearchBar.Text = "Search...";
            this.SearchBar.TextChanged += new System.EventHandler(this.SearchBar_TextChanged);
            // 
            // AddNew
            // 
            this.AddNew.Location = new System.Drawing.Point(187, 9);
            this.AddNew.Margin = new System.Windows.Forms.Padding(4);
            this.AddNew.Name = "AddNew";
            this.AddNew.Size = new System.Drawing.Size(160, 28);
            this.AddNew.TabIndex = 5;
            this.AddNew.Text = "Add New";
            this.AddNew.UseVisualStyleBackColor = true;
            this.AddNew.Click += new System.EventHandler(this.AddNew_Click);
            // 
            // DeleteItem
            // 
            this.DeleteItem.Location = new System.Drawing.Point(187, 46);
            this.DeleteItem.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteItem.Name = "DeleteItem";
            this.DeleteItem.Size = new System.Drawing.Size(161, 28);
            this.DeleteItem.TabIndex = 6;
            this.DeleteItem.Text = "Delete";
            this.DeleteItem.UseVisualStyleBackColor = true;
            this.DeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 171);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Name:";
            // 
            // ItemName
            // 
            this.ItemName.Location = new System.Drawing.Point(187, 192);
            this.ItemName.Margin = new System.Windows.Forms.Padding(4);
            this.ItemName.Name = "ItemName";
            this.ItemName.Size = new System.Drawing.Size(161, 22);
            this.ItemName.TabIndex = 8;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(188, 139);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(79, 28);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(269, 139);
            this.BackButton.Margin = new System.Windows.Forms.Padding(4);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(79, 28);
            this.BackButton.TabIndex = 10;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 218);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Picture Name:";
            // 
            // PictureName
            // 
            this.PictureName.Location = new System.Drawing.Point(187, 239);
            this.PictureName.Margin = new System.Windows.Forms.Padding(4);
            this.PictureName.Name = "PictureName";
            this.PictureName.Size = new System.Drawing.Size(160, 22);
            this.PictureName.TabIndex = 12;
            // 
            // Picture
            // 
            this.Picture.Image = ((System.Drawing.Image)(resources.GetObject("Picture.Image")));
            this.Picture.Location = new System.Drawing.Point(188, 270);
            this.Picture.Margin = new System.Windows.Forms.Padding(4);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(160, 148);
            this.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Picture.TabIndex = 13;
            this.Picture.TabStop = false;
            // 
            // ReloadImage
            // 
            this.ReloadImage.Location = new System.Drawing.Point(187, 425);
            this.ReloadImage.Margin = new System.Windows.Forms.Padding(4);
            this.ReloadImage.Name = "ReloadImage";
            this.ReloadImage.Size = new System.Drawing.Size(161, 28);
            this.ReloadImage.TabIndex = 14;
            this.ReloadImage.Text = "Reload Image";
            this.ReloadImage.UseVisualStyleBackColor = true;
            this.ReloadImage.Click += new System.EventHandler(this.ReloadImage_Click);
            // 
            // EditItem
            // 
            this.EditItem.Location = new System.Drawing.Point(188, 80);
            this.EditItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EditItem.Name = "EditItem";
            this.EditItem.Size = new System.Drawing.Size(159, 27);
            this.EditItem.TabIndex = 15;
            this.EditItem.Text = "Edit";
            this.EditItem.UseVisualStyleBackColor = true;
            this.EditItem.Click += new System.EventHandler(this.EditItem_Click);
            // 
            // Manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 508);
            this.Controls.Add(this.EditItem);
            this.Controls.Add(this.ReloadImage);
            this.Controls.Add(this.Picture);
            this.Controls.Add(this.PictureName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ItemName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DeleteItem);
            this.Controls.Add(this.AddNew);
            this.Controls.Add(this.SearchBar);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.ListBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Manage";
            this.Text = "Manage";
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBox;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.TextBox SearchBar;
        private System.Windows.Forms.Button AddNew;
        private System.Windows.Forms.Button DeleteItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ItemName;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PictureName;
        private System.Windows.Forms.PictureBox Picture;
        private System.Windows.Forms.Button ReloadImage;
        private System.Windows.Forms.Button EditItem;
    }
}