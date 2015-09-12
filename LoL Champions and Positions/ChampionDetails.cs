using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoL_Champions_and_Positions
{
    public partial class ChampionDetails : Form
    {
        public ChampionDetails()
        {
            if (Engine.SelectedChampion == null)
            {
                throw new Exception("No selected Champion");
            }

            InitializeComponent();

            pictureBox1.Image = HelpMethods.getImageFromLocalDirectory(Engine.SelectedChampion.Image, false);
            championName.Text = Engine.SelectedChampion.Name;
            championDetailsText.Text = Engine.SelectedChampion.Description;
            searchTag.Text = Engine.SelectedChampion.SearchTag;
            ChangesMade = false;

            this.Text = championName.Text;
        }
        public bool ChangesMade { get; private set;}

        private void editButton_Click(object sender, EventArgs e)
        {
            saveButton.Enabled = true;
            backButton.Enabled = true;
            championDetailsText.ReadOnly = false;
            searchTag.ReadOnly = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (Engine.SelectedChampion.Description != championDetailsText.Text || Engine.SelectedChampion.SearchTag != searchTag.Text)
            {

                Engine.SelectedChampion.Description = championDetailsText.Text;
                Engine.SelectedChampion.SearchTag = searchTag.Text;
                ChangesMade = true;

                saveButton.Enabled = false;
                backButton.Enabled = false;
                championDetailsText.ReadOnly = true;
                searchTag.ReadOnly = true;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            championDetailsText.Text = Engine.SelectedChampion.Description;
            searchTag.Text = Engine.SelectedChampion.SearchTag;

            saveButton.Enabled = false;
            backButton.Enabled = false;
            championDetailsText.ReadOnly = true;
            searchTag.ReadOnly = true;
        }
    }
}
