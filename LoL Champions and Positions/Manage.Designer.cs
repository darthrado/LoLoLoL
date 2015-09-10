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
            this.ListBox.Location = new System.Drawing.Point(12, 43);
            this.ListBox.Name = "ListBox";
            this.ListBox.Size = new System.Drawing.Size(123, 355);
            this.ListBox.TabIndex = 0;
            this.ListBox.Click += new System.EventHandler(this.ListBox_Click);
            this.ListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // Ok
            // 
            this.Ok.Location = new System.Drawing.Point(141, 375);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(120, 23);
            this.Ok.TabIndex = 2;
            this.Ok.Text = "Ok";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // SearchBar
            // 
            this.SearchBar.Location = new System.Drawing.Point(12, 12);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(123, 20);
            this.SearchBar.TabIndex = 4;
            this.SearchBar.Text = "Search...";
            this.SearchBar.TextChanged += new System.EventHandler(this.SearchBar_TextChanged);
            // 
            // AddNew
            // 
            this.AddNew.Location = new System.Drawing.Point(140, 7);
            this.AddNew.Name = "AddNew";
            this.AddNew.Size = new System.Drawing.Size(120, 23);
            this.AddNew.TabIndex = 5;
            this.AddNew.Text = "Add New";
            this.AddNew.UseVisualStyleBackColor = true;
            this.AddNew.Click += new System.EventHandler(this.AddNew_Click);
            // 
            // DeleteItem
            // 
            this.DeleteItem.Location = new System.Drawing.Point(140, 37);
            this.DeleteItem.Name = "DeleteItem";
            this.DeleteItem.Size = new System.Drawing.Size(121, 23);
            this.DeleteItem.TabIndex = 6;
            this.DeleteItem.Text = "Delete";
            this.DeleteItem.UseVisualStyleBackColor = true;
            this.DeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Name:";
            // 
            // ItemName
            // 
            this.ItemName.Location = new System.Drawing.Point(140, 156);
            this.ItemName.Name = "ItemName";
            this.ItemName.Size = new System.Drawing.Size(122, 20);
            this.ItemName.TabIndex = 8;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(141, 113);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(59, 23);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(202, 113);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(59, 23);
            this.BackButton.TabIndex = 10;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Picture Name:";
            // 
            // PictureName
            // 
            this.PictureName.Location = new System.Drawing.Point(140, 194);
            this.PictureName.Name = "PictureName";
            this.PictureName.Size = new System.Drawing.Size(121, 20);
            this.PictureName.TabIndex = 12;
            // 
            // Picture
            // 
            this.Picture.Image = ((System.Drawing.Image)(resources.GetObject("Picture.Image")));
            this.Picture.Location = new System.Drawing.Point(141, 219);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(120, 120);
            this.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Picture.TabIndex = 13;
            this.Picture.TabStop = false;
            // 
            // ReloadImage
            // 
            this.ReloadImage.Location = new System.Drawing.Point(140, 345);
            this.ReloadImage.Name = "ReloadImage";
            this.ReloadImage.Size = new System.Drawing.Size(121, 23);
            this.ReloadImage.TabIndex = 14;
            this.ReloadImage.Text = "Reload Image";
            this.ReloadImage.UseVisualStyleBackColor = true;
            this.ReloadImage.Click += new System.EventHandler(this.ReloadImage_Click);
            // 
            // EditItem
            // 
            this.EditItem.Location = new System.Drawing.Point(141, 65);
            this.EditItem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EditItem.Name = "EditItem";
            this.EditItem.Size = new System.Drawing.Size(119, 22);
            this.EditItem.TabIndex = 15;
            this.EditItem.Text = "Edit";
            this.EditItem.UseVisualStyleBackColor = true;
            this.EditItem.Click += new System.EventHandler(this.EditItem_Click);
            // 
            // Manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 413);
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