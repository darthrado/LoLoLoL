namespace LoL_Champions_and_Positions
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.playablePositions = new System.Windows.Forms.ComboBox();
            this.championListCollection = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AllChampsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.textSeaarchBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonManageChamp = new System.Windows.Forms.Button();
            this.buttonManageLists = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureSelectedChamp = new System.Windows.Forms.PictureBox();
            this.ChampionDetailsButton = new System.Windows.Forms.Button();
            this.selectedChampTextBox = new System.Windows.Forms.TextBox();
            this.BackButton = new System.Windows.Forms.Button();
            this.CustomListsStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeFromListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonMatchupDetails = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.AllChampsContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSelectedChamp)).BeginInit();
            this.CustomListsStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Position:";
            // 
            // playablePositions
            // 
            this.playablePositions.FormattingEnabled = true;
            this.playablePositions.Items.AddRange(new object[] {
            "All",
            "Top",
            "Jungle",
            "Mid",
            "AD Carry",
            "Support"});
            this.playablePositions.Location = new System.Drawing.Point(7, 123);
            this.playablePositions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.playablePositions.Name = "playablePositions";
            this.playablePositions.Size = new System.Drawing.Size(122, 21);
            this.playablePositions.TabIndex = 1;
            this.playablePositions.SelectionChangeCommitted += new System.EventHandler(this.Positions_SelectionChangeCommitted);
            // 
            // championListCollection
            // 
            this.championListCollection.AllowDrop = true;
            this.championListCollection.FormattingEnabled = true;
            this.championListCollection.Items.AddRange(new object[] {
            "I play",
            "I train"});
            this.championListCollection.Location = new System.Drawing.Point(7, 85);
            this.championListCollection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.championListCollection.Name = "championListCollection";
            this.championListCollection.Size = new System.Drawing.Size(120, 21);
            this.championListCollection.TabIndex = 2;
            this.championListCollection.SelectionChangeCommitted += new System.EventHandler(this.ListCollection_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(136, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(704, 420);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 1;
            // 
            // AllChampsContextMenu
            // 
            this.AllChampsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3});
            this.AllChampsContextMenu.Name = "contextMenuStrip1";
            this.AllChampsContextMenu.Size = new System.Drawing.Size(177, 26);
            this.AllChampsContextMenu.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem3.Text = "Add to Custom List";
            // 
            // textSeaarchBox
            // 
            this.textSeaarchBox.Location = new System.Drawing.Point(9, 148);
            this.textSeaarchBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textSeaarchBox.Name = "textSeaarchBox";
            this.textSeaarchBox.Size = new System.Drawing.Size(120, 20);
            this.textSeaarchBox.TabIndex = 4;
            this.textSeaarchBox.Text = "Search...";
            this.textSeaarchBox.TextChanged += new System.EventHandler(this.textSeaarchBox_TextChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 50;
            // 
            // buttonManageChamp
            // 
            this.buttonManageChamp.Location = new System.Drawing.Point(7, 11);
            this.buttonManageChamp.Name = "buttonManageChamp";
            this.buttonManageChamp.Size = new System.Drawing.Size(120, 23);
            this.buttonManageChamp.TabIndex = 5;
            this.buttonManageChamp.Text = "Manage Champions";
            this.buttonManageChamp.UseVisualStyleBackColor = true;
            this.buttonManageChamp.Click += new System.EventHandler(this.manageChamp_Click);
            // 
            // buttonManageLists
            // 
            this.buttonManageLists.Location = new System.Drawing.Point(7, 44);
            this.buttonManageLists.Name = "buttonManageLists";
            this.buttonManageLists.Size = new System.Drawing.Size(120, 23);
            this.buttonManageLists.TabIndex = 6;
            this.buttonManageLists.Text = "Manage Lists";
            this.buttonManageLists.UseVisualStyleBackColor = true;
            this.buttonManageLists.Click += new System.EventHandler(this.manageLists_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "List:";
            // 
            // pictureSelectedChamp
            // 
            this.pictureSelectedChamp.Location = new System.Drawing.Point(8, 187);
            this.pictureSelectedChamp.Name = "pictureSelectedChamp";
            this.pictureSelectedChamp.Size = new System.Drawing.Size(120, 120);
            this.pictureSelectedChamp.TabIndex = 8;
            this.pictureSelectedChamp.TabStop = false;
            // 
            // ChampionDetailsButton
            // 
            this.ChampionDetailsButton.Location = new System.Drawing.Point(7, 378);
            this.ChampionDetailsButton.Name = "ChampionDetailsButton";
            this.ChampionDetailsButton.Size = new System.Drawing.Size(122, 23);
            this.ChampionDetailsButton.TabIndex = 9;
            this.ChampionDetailsButton.Text = "Details";
            this.ChampionDetailsButton.UseVisualStyleBackColor = true;
            // 
            // selectedChampTextBox
            // 
            this.selectedChampTextBox.Location = new System.Drawing.Point(8, 314);
            this.selectedChampTextBox.Name = "selectedChampTextBox";
            this.selectedChampTextBox.ReadOnly = true;
            this.selectedChampTextBox.Size = new System.Drawing.Size(120, 20);
            this.selectedChampTextBox.TabIndex = 10;
            this.selectedChampTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(7, 407);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(124, 23);
            this.BackButton.TabIndex = 11;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // CustomListsStrip
            // 
            this.CustomListsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeFromListToolStripMenuItem});
            this.CustomListsStrip.Name = "CustomListsStrip";
            this.CustomListsStrip.Size = new System.Drawing.Size(170, 26);
            this.CustomListsStrip.Opened += new System.EventHandler(this.CustomListsStrip_Opened);
            // 
            // removeFromListToolStripMenuItem
            // 
            this.removeFromListToolStripMenuItem.Name = "removeFromListToolStripMenuItem";
            this.removeFromListToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.removeFromListToolStripMenuItem.Text = "Remove From List";
            this.removeFromListToolStripMenuItem.Click += new System.EventHandler(this.removeFromListToolStripMenuItem_Click);
            // 
            // ButtonMatchupDetails
            // 
            this.ButtonMatchupDetails.Location = new System.Drawing.Point(9, 349);
            this.ButtonMatchupDetails.Name = "ButtonMatchupDetails";
            this.ButtonMatchupDetails.Size = new System.Drawing.Size(122, 23);
            this.ButtonMatchupDetails.TabIndex = 12;
            this.ButtonMatchupDetails.Text = "Matchup Details";
            this.ButtonMatchupDetails.UseVisualStyleBackColor = true;
            this.ButtonMatchupDetails.Click += new System.EventHandler(this.ButtonMatchupDetails_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(872, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(875, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 432);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ButtonMatchupDetails);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.selectedChampTextBox);
            this.Controls.Add(this.ChampionDetailsButton);
            this.Controls.Add(this.pictureSelectedChamp);
            this.Controls.Add(this.playablePositions);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonManageLists);
            this.Controls.Add(this.buttonManageChamp);
            this.Controls.Add(this.textSeaarchBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.championListCollection);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.AllChampsContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureSelectedChamp)).EndInit();
            this.CustomListsStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox playablePositions;
        private System.Windows.Forms.ComboBox championListCollection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textSeaarchBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip AllChampsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonManageChamp;
        private System.Windows.Forms.Button buttonManageLists;
        private System.Windows.Forms.Label label3;/*
        private System.Windows.Forms.ToolStripMenuItem list1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jungleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem midToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aDCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supportToolStripMenuItem;*/
        private System.Windows.Forms.PictureBox pictureSelectedChamp;
        private System.Windows.Forms.Button ChampionDetailsButton;
        private System.Windows.Forms.TextBox selectedChampTextBox;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.ContextMenuStrip CustomListsStrip;
        private System.Windows.Forms.ToolStripMenuItem removeFromListToolStripMenuItem;
        private System.Windows.Forms.Button ButtonMatchupDetails;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

