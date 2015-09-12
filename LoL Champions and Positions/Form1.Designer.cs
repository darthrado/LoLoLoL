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
            this.groupBoxChampions = new System.Windows.Forms.GroupBox();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.AllChampsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddChampionToListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textSeaarchBox = new System.Windows.Forms.TextBox();
            this.ChampionNameTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.ButtonManageChamp = new System.Windows.Forms.Button();
            this.ButtonManageLists = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PictureSelectedChamp = new System.Windows.Forms.PictureBox();
            this.ChampionDetailsButton = new System.Windows.Forms.Button();
            this.SelectedChampTextBox = new System.Windows.Forms.TextBox();
            this.BackButton = new System.Windows.Forms.Button();
            this.CustomListsStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RemoveFromListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonMatchupDetails = new System.Windows.Forms.Button();
            this.ManagePositionsButton = new System.Windows.Forms.Button();
            this.groupBoxChampions.SuspendLayout();
            this.AllChampsContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureSelectedChamp)).BeginInit();
            this.CustomListsStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 163);
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
            this.playablePositions.Location = new System.Drawing.Point(4, 182);
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
            this.championListCollection.Location = new System.Drawing.Point(9, 137);
            this.championListCollection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.championListCollection.Name = "championListCollection";
            this.championListCollection.Size = new System.Drawing.Size(159, 24);
            this.championListCollection.TabIndex = 2;
            this.championListCollection.SelectionChangeCommitted += new System.EventHandler(this.ListCollection_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBoxChampions.Controls.Add(this.ControlPanel);
            this.groupBoxChampions.Controls.Add(this.label2);
            this.groupBoxChampions.Location = new System.Drawing.Point(181, 14);
            this.groupBoxChampions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxChampions.Name = "groupBox1";
            this.groupBoxChampions.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxChampions.Size = new System.Drawing.Size(939, 543);
            this.groupBoxChampions.TabIndex = 3;
            this.groupBoxChampions.TabStop = false;
            this.groupBoxChampions.Text = "Text";
            // 
            // controlPanel
            // 
            this.ControlPanel.AutoScroll = true;
            this.ControlPanel.Location = new System.Drawing.Point(7, 16);
            this.ControlPanel.Margin = new System.Windows.Forms.Padding(4);
            this.ControlPanel.Name = "controlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(925, 516);
            this.ControlPanel.TabIndex = 2;
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
            this.AddChampionToListMenuItem});
            this.AllChampsContextMenu.Name = "contextMenuStrip1";
            this.AllChampsContextMenu.Size = new System.Drawing.Size(205, 28);
            this.AllChampsContextMenu.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
            // 
            // toolStripMenuItem3
            // 
            this.AddChampionToListMenuItem.Name = "toolStripMenuItem3";
            this.AddChampionToListMenuItem.Size = new System.Drawing.Size(204, 24);
            this.AddChampionToListMenuItem.Text = "Add to Custom List";
            // 
            // textSeaarchBox
            // 
            this.textSeaarchBox.Location = new System.Drawing.Point(6, 219);
            this.textSeaarchBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textSeaarchBox.Name = "textSeaarchBox";
            this.textSeaarchBox.Size = new System.Drawing.Size(159, 22);
            this.textSeaarchBox.TabIndex = 4;
            this.textSeaarchBox.Text = "Search...";
            this.textSeaarchBox.TextChanged += new System.EventHandler(this.textSeaarchBox_TextChanged);
            // 
            // toolTip1
            // 
            this.ChampionNameTooltip.AutomaticDelay = 50;
            // 
            // buttonManageChamp
            // 
            this.ButtonManageChamp.Location = new System.Drawing.Point(4, 13);
            this.ButtonManageChamp.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonManageChamp.Name = "buttonManageChamp";
            this.ButtonManageChamp.Size = new System.Drawing.Size(160, 28);
            this.ButtonManageChamp.TabIndex = 5;
            this.ButtonManageChamp.Text = "Manage Champions";
            this.ButtonManageChamp.UseVisualStyleBackColor = true;
            this.ButtonManageChamp.Click += new System.EventHandler(this.manageChamp_Click);
            // 
            // buttonManageLists
            // 
            this.ButtonManageLists.Location = new System.Drawing.Point(4, 50);
            this.ButtonManageLists.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonManageLists.Name = "buttonManageLists";
            this.ButtonManageLists.Size = new System.Drawing.Size(160, 28);
            this.ButtonManageLists.TabIndex = 6;
            this.ButtonManageLists.Text = "Manage Lists";
            this.ButtonManageLists.UseVisualStyleBackColor = true;
            this.ButtonManageLists.Click += new System.EventHandler(this.manageLists_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "List:";
            // 
            // pictureSelectedChamp
            // 
            this.PictureSelectedChamp.Location = new System.Drawing.Point(9, 247);
            this.PictureSelectedChamp.Margin = new System.Windows.Forms.Padding(4);
            this.PictureSelectedChamp.Name = "pictureSelectedChamp";
            this.PictureSelectedChamp.Size = new System.Drawing.Size(160, 148);
            this.PictureSelectedChamp.TabIndex = 8;
            this.PictureSelectedChamp.TabStop = false;
            // 
            // ChampionDetailsButton
            // 
            this.ChampionDetailsButton.Location = new System.Drawing.Point(9, 482);
            this.ChampionDetailsButton.Margin = new System.Windows.Forms.Padding(4);
            this.ChampionDetailsButton.Name = "ChampionDetailsButton";
            this.ChampionDetailsButton.Size = new System.Drawing.Size(163, 28);
            this.ChampionDetailsButton.TabIndex = 9;
            this.ChampionDetailsButton.Text = "Details";
            this.ChampionDetailsButton.UseVisualStyleBackColor = true;
            this.ChampionDetailsButton.Click += new System.EventHandler(this.ChampionDetailsButton_Click);
            // 
            // selectedChampTextBox
            // 
            this.SelectedChampTextBox.Location = new System.Drawing.Point(10, 403);
            this.SelectedChampTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SelectedChampTextBox.Name = "selectedChampTextBox";
            this.SelectedChampTextBox.ReadOnly = true;
            this.SelectedChampTextBox.Size = new System.Drawing.Size(159, 22);
            this.SelectedChampTextBox.TabIndex = 10;
            this.SelectedChampTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(6, 518);
            this.BackButton.Margin = new System.Windows.Forms.Padding(4);
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
            this.RemoveFromListToolStripMenuItem});
            this.CustomListsStrip.Name = "CustomListsStrip";
            this.CustomListsStrip.Size = new System.Drawing.Size(197, 28);
            this.CustomListsStrip.Opened += new System.EventHandler(this.CustomListsStrip_Opened);
            // 
            // removeFromListToolStripMenuItem
            // 
            this.RemoveFromListToolStripMenuItem.Name = "removeFromListToolStripMenuItem";
            this.RemoveFromListToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.RemoveFromListToolStripMenuItem.Text = "Remove From List";
            this.RemoveFromListToolStripMenuItem.Click += new System.EventHandler(this.removeFromListToolStripMenuItem_Click);
            // 
            // ButtonMatchupDetails
            // 
            this.ButtonMatchupDetails.Location = new System.Drawing.Point(9, 446);
            this.ButtonMatchupDetails.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonMatchupDetails.Name = "ButtonMatchupDetails";
            this.ButtonMatchupDetails.Size = new System.Drawing.Size(163, 28);
            this.ButtonMatchupDetails.TabIndex = 12;
            this.ButtonMatchupDetails.Text = "Matchup Details";
            this.ButtonMatchupDetails.UseVisualStyleBackColor = true;
            this.ButtonMatchupDetails.Click += new System.EventHandler(this.ButtonMatchupDetails_Click);
            // 
            // ManagePositionsButton
            // 
            this.ManagePositionsButton.Location = new System.Drawing.Point(4, 85);
            this.ManagePositionsButton.Name = "ManagePositionsButton";
            this.ManagePositionsButton.Size = new System.Drawing.Size(157, 30);
            this.ManagePositionsButton.TabIndex = 16;
            this.ManagePositionsButton.Text = "Manage Positions";
            this.ManagePositionsButton.UseVisualStyleBackColor = true;
            this.ManagePositionsButton.Click += new System.EventHandler(this.ManagePositionsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 567);
            this.Controls.Add(this.ManagePositionsButton);
            this.Controls.Add(this.ButtonMatchupDetails);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.SelectedChampTextBox);
            this.Controls.Add(this.ChampionDetailsButton);
            this.Controls.Add(this.PictureSelectedChamp);
            this.Controls.Add(this.playablePositions);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ButtonManageLists);
            this.Controls.Add(this.ButtonManageChamp);
            this.Controls.Add(this.textSeaarchBox);
            this.Controls.Add(this.groupBoxChampions);
            this.Controls.Add(this.championListCollection);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBoxChampions.ResumeLayout(false);
            this.groupBoxChampions.PerformLayout();
            this.AllChampsContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureSelectedChamp)).EndInit();
            this.CustomListsStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox playablePositions;
        private System.Windows.Forms.ComboBox championListCollection;
        private System.Windows.Forms.GroupBox groupBoxChampions;
        private System.Windows.Forms.TextBox textSeaarchBox;
        private System.Windows.Forms.ToolTip ChampionNameTooltip;
        private System.Windows.Forms.ContextMenuStrip AllChampsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem AddChampionToListMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonManageChamp;
        private System.Windows.Forms.Button ButtonManageLists;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox PictureSelectedChamp;
        private System.Windows.Forms.Button ChampionDetailsButton;
        private System.Windows.Forms.TextBox SelectedChampTextBox;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.ContextMenuStrip CustomListsStrip;
        private System.Windows.Forms.ToolStripMenuItem RemoveFromListToolStripMenuItem;
        private System.Windows.Forms.Button ButtonMatchupDetails;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.Button ManagePositionsButton;
    }
}

