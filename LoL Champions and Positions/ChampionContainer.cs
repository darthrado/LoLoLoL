using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoL_Champions_and_Positions
{
    /// <summary>
    /// 
    /// </summary>
    public class ChampionContainer
    {
        public ChampionContainer(Champion champion)
        {
            _champion = champion;
            pictureBox = new System.Windows.Forms.PictureBox();
            toolTip = new System.Windows.Forms.ToolTip();

            this.pictureBox.Image = HelpMethods.getImageFromLocalDirectory(champion.Image);
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox"+champion.Name;
            this.pictureBox.Size = new System.Drawing.Size(60, 60);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.Click+=new EventHandler(pictureBox_Click);

            this.toolTip.SetToolTip(pictureBox, champion.Tooltip);
        }
        public ChampionContainer(Champion champion,Form1 mainForm)
        {
            _champion = champion;
            _mainForm = mainForm;
            pictureBox = new System.Windows.Forms.PictureBox();
            toolTip = new System.Windows.Forms.ToolTip();

            this.pictureBox.Image = HelpMethods.getImageFromLocalDirectory(champion.Image);
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox" + champion.Name;
            this.pictureBox.Size = new System.Drawing.Size(60, 60);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.Click += new EventHandler(pictureBox_Click);

            this.toolTip.SetToolTip(pictureBox, champion.Tooltip);
        }

        private Champion _champion;

        private Form1 _mainForm;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolTip toolTip;

        //public Champion ChampionPr { get { return _champion; } }
        public string Name { get { return _champion.Name; } set { _champion.Name = value; } }
        public string Image { get { return _champion.Image; } set { _champion.Image = value; pictureBox.Image = HelpMethods.getImageFromLocalDirectory(value); } }
        public string SearchTag { get { return _champion.SearchTag; } set { _champion.SearchTag = value; } }
        public string Tooltip { get { return _champion.Tooltip; } set { _champion.Tooltip = value; } }

        public int X { get { return pictureBox.Location.X; } }
        public int Y { get { return pictureBox.Location.Y; } }
        public bool Visible { get { return pictureBox.Visible; } set { pictureBox.Visible = value; } }
        public void SetLocation(int x, int y)
        {
            pictureBox.Location = new System.Drawing.Point(x,y);
        }
        public System.Windows.Forms.PictureBox PictureBox { get { return pictureBox; } }
        public void setMainForm(Form1 mainForm)
        {
            _mainForm=mainForm;
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (_mainForm != null)
            {
                _mainForm.SetSelectedChampion(this);
            }
        }

    }
}
