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
            this.controlPanel = new System.Windows.Forms.Panel();
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
            this.button3 = new System.Windows.Forms.Button();
            this.ManagePositionsButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.AllChampsContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSelectedChamp)).BeginInit();
            this.CustomListsStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
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
            this.playablePositions.Location = new System.Drawing.Point(11, 218);
            this.playablePositions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playablePositions.Name = "playablePositions";
            this.playablePositions.Size = new System.Drawing.Size(161, 24);
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
            this.championListCollection.Location = new System.Drawing.Point(9, 155);
            this.championListCollection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.championListCollection.Name = "championListCollection";
            this.championListCollection.Size = new System.Drawing.Size(159, 24);
            this.championListCollection.TabIndex = 2;
            this.championListCollection.SelectionChangeCommitted += new System.EventHandler(this.ListCollection_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.controlPanel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(181, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(939, 585);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text";
            // 
            // controlPanel
            // 
            this.controlPanel.AutoScroll = true;
            this.controlPanel.Location = new System.Drawing.Point(7, 16);
            this.controlPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(925, 563);
            this.controlPanel.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 1;
            // 
            // AllChampsContextMenu
            // 
            this.AllChampsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3});
            this.AllChampsContextMenu.Name = "contextMenuStrip1";
            this.AllChampsContextMenu.Size = new System.Drawing.Size(205, 28);
            this.AllChampsContextMenu.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(204, 24);
            this.toolStripMenuItem3.Text = "Add to Custom List";
            // 
            // textSeaarchBox
            // 
            this.textSeaarchBox.Location = new System.Drawing.Point(13, 257);
            this.textSeaarchBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textSeaarchBox.Name = "textSeaarchBox";
            this.textSeaarchBox.Size = new System.Drawing.Size(159, 22);
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
            this.buttonManageChamp.Location = new System.Drawing.Point(9, 14);
            this.buttonManageChamp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonManageChamp.Name = "buttonManageChamp";
            this.buttonManageChamp.Size = new System.Drawing.Size(160, 28);
            this.buttonManageChamp.TabIndex = 5;
            this.buttonManageChamp.Text = "Manage Champions";
            this.buttonManageChamp.UseVisualStyleBackColor = true;
            this.buttonManageChamp.Click += new System.EventHandler(this.manageChamp_Click);
            // 
            // buttonManageLists
            // 
            this.buttonManageLists.Location = new System.Drawing.Point(9, 54);
            this.buttonManageLists.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonManageLists.Name = "buttonManageLists";
            this.buttonManageLists.Size = new System.Drawing.Size(160, 28);
            this.buttonManageLists.TabIndex = 6;
            this.buttonManageLists.Text = "Manage Lists";
            this.buttonManageLists.UseVisualStyleBackColor = true;
            this.buttonManageLists.Click += new System.EventHandler(this.manageLists_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 127);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "List:";
            // 
            // pictureSelectedChamp
            // 
            this.pictureSelectedChamp.Location = new System.Drawing.Point(12, 307);
            this.pictureSelectedChamp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureSelectedChamp.Name = "pictureSelectedChamp";
            this.pictureSelectedChamp.Size = new System.Drawing.Size(160, 148);
            this.pictureSelectedChamp.TabIndex = 8;
            this.pictureSelectedChamp.TabStop = false;
            // 
            // ChampionDetailsButton
            // 
            this.ChampionDetailsButton.Location = new System.Drawing.Point(9, 529);
            this.ChampionDetailsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChampionDetailsButton.Name = "ChampionDetailsButton";
            this.ChampionDetailsButton.Size = new System.Drawing.Size(163, 28);
            this.ChampionDetailsButton.TabIndex = 9;
            this.ChampionDetailsButton.Text = "Details";
            this.ChampionDetailsButton.UseVisualStyleBackColor = true;
            this.ChampionDetailsButton.Click += new System.EventHandler(this.ChampionDetailsButton_Click);
            // 
            // selectedChampTextBox
            // 
            this.selectedChampTextBox.Location = new System.Drawing.Point(13, 463);
            this.selectedChampTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectedChampTextBox.Name = "selectedChampTextBox";
            this.selectedChampTextBox.ReadOnly = true;
            this.selectedChampTextBox.Size = new System.Drawing.Size(159, 22);
            this.selectedChampTextBox.TabIndex = 10;
            this.selectedChampTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(7, 565);
            this.BackButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(165, 28);
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
            this.CustomListsStrip.Size = new System.Drawing.Size(197, 28);
            this.CustomListsStrip.Opened += new System.EventHandler(this.CustomListsStrip_Opened);
            // 
            // removeFromListToolStripMenuItem
            // 
            this.removeFromListToolStripMenuItem.Name = "removeFromListToolStripMenuItem";
            this.removeFromListToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.removeFromListToolStripMenuItem.Text = "Remove From List";
            this.removeFromListToolStripMenuItem.Click += new System.EventHandler(this.removeFromListToolStripMenuItem_Click);
            // 
            // ButtonMatchupDetails
            // 
            this.ButtonMatchupDetails.Location = new System.Drawing.Point(11, 493);
            this.ButtonMatchupDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonMatchupDetails.Name = "ButtonMatchupDetails";
            this.ButtonMatchupDetails.Size = new System.Drawing.Size(163, 28);
            this.ButtonMatchupDetails.TabIndex = 12;
            this.ButtonMatchupDetails.Text = "Matchup Details";
            this.ButtonMatchupDetails.UseVisualStyleBackColor = true;
            this.ButtonMatchupDetails.Click += new System.EventHandler(this.ButtonMatchupDetails_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1163, 52);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1167, 105);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 14;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1163, 151);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 15;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ManagePositionsButton
            // 
            this.ManagePositionsButton.Location = new System.Drawing.Point(12, 92);
            this.ManagePositionsButton.Name = "ManagePositionsButton";
            this.ManagePositionsButton.Size = new System.Drawing.Size(157, 23);
            this.ManagePositionsButton.TabIndex = 16;
            this.ManagePositionsButton.Text = "Manage Positions";
            this.ManagePositionsButton.UseVisualStyleBackColor = true;
            this.ManagePositionsButton.Click += new System.EventHandler(this.ManagePositionsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 682);
            this.Controls.Add(this.ManagePositionsButton);
            this.Controls.Add(this.button3);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button ManagePositionsButton;
    }
}

