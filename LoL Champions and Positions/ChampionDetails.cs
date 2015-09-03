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
        public ChampionDetails(ChampionContainer champion)
        {
            InitializeComponent();
            pictureBox1.Image = HelpMethods.getImageFromLocalDirectory(champion.Image);
            championName.Text = champion.Name;
            championDetailsText.Text = champion.Description;
            searchTag.Text = champion.SearchTag;
            ChangesMade = false;

            resultChampion = champion;
        }

        private ChampionContainer resultChampion;
        public bool ChangesMade { get; private set;}
        public ChampionContainer Result { get { return resultChampion; } }

        private void editButton_Click(object sender, EventArgs e)
        {
            saveButton.Enabled = true;
            backButton.Enabled = true;
            championDetailsText.ReadOnly = false;
            searchTag.ReadOnly = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (resultChampion.Description != championDetailsText.Text || resultChampion.SearchTag != searchTag.Text)
            {

                resultChampion.Description = championDetailsText.Text;
                resultChampion.SearchTag = searchTag.Text;
                ChangesMade = true;

                saveButton.Enabled = false;
                backButton.Enabled = false;
                championDetailsText.ReadOnly = true;
                searchTag.ReadOnly = true;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            championDetailsText.Text = resultChampion.Description;
            searchTag.Text = resultChampion.SearchTag;

            saveButton.Enabled = false;
            backButton.Enabled = false;
            championDetailsText.ReadOnly = true;
            searchTag.ReadOnly = true;
        }
    }
}
