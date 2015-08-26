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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            /*
            this.list1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jungleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.midToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aDCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
             * */
            this.textSeaarchBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonManageChamp = new System.Windows.Forms.Button();
            this.buttonManageLists = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureSelectedChamp = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.selectedChampTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSelectedChamp)).BeginInit();
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
            this.playablePositions.Margin = new System.Windows.Forms.Padding(2);
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
            this.championListCollection.Margin = new System.Windows.Forms.Padding(2);
            this.championListCollection.Name = "championListCollection";
            this.championListCollection.Size = new System.Drawing.Size(120, 21);
            this.championListCollection.TabIndex = 2;
            this.championListCollection.SelectionChangeCommitted += new System.EventHandler(this.ListCollection_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(136, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(704, 382);
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(177, 26);
            // 
            // toolStripMenuItem3
            // 
            /*this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.list1ToolStripMenuItem});*/
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem3.Text = "Add to Custom List";
            // 
            // list1ToolStripMenuItem
            /*/ 
            this.list1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topToolStripMenuItem,
            this.jungleToolStripMenuItem,
            this.midToolStripMenuItem,
            this.aDCToolStripMenuItem,
            this.supportToolStripMenuItem});
            this.list1ToolStripMenuItem.Name = "list1ToolStripMenuItem";
            this.list1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.list1ToolStripMenuItem.Text = "List1";
            // 
            // topToolStripMenuItem
            // 
            this.topToolStripMenuItem.Name = "topToolStripMenuItem";
            this.topToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.topToolStripMenuItem.Text = "Top";
            // 
            // jungleToolStripMenuItem
            // 
            this.jungleToolStripMenuItem.Name = "jungleToolStripMenuItem";
            this.jungleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.jungleToolStripMenuItem.Text = "Jungle";
            // 
            // midToolStripMenuItem
            // 
            this.midToolStripMenuItem.Name = "midToolStripMenuItem";
            this.midToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.midToolStripMenuItem.Text = "Mid";
            // 
            // aDCToolStripMenuItem
            // 
            this.aDCToolStripMenuItem.Name = "aDCToolStripMenuItem";
            this.aDCToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aDCToolStripMenuItem.Text = "ADC";
            // 
            // supportToolStripMenuItem
            // 
            this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
            this.supportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.supportToolStripMenuItem.Text = "Support";*/
            // 
            // textSeaarchBox
            // 
            this.textSeaarchBox.Location = new System.Drawing.Point(9, 148);
            this.textSeaarchBox.Margin = new System.Windows.Forms.Padding(2);
            this.textSeaarchBox.Name = "textSeaarchBox";
            this.textSeaarchBox.Size = new System.Drawing.Size(120, 20);
            this.textSeaarchBox.TabIndex = 4;
            this.textSeaarchBox.Text = "Search...";
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Details";
            this.button1.UseVisualStyleBackColor = true;
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 370);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 407);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.selectedChampTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureSelectedChamp);
            this.Controls.Add(this.playablePositions);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonManageLists);
            this.Controls.Add(this.buttonManageChamp);
            this.Controls.Add(this.textSeaarchBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.championListCollection);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureSelectedChamp)).EndInit();
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox selectedChampTextBox;
        private System.Windows.Forms.Button button2;
    }
}

