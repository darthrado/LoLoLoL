﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoL_Champions_and_Positions
{
    public partial class MatchupDetails : Form
    {
        public MatchupDetails(Champion champion,Champion enemyChampion)
        {
            InitializeComponent();
            matchupDetails = champion.MatchupList[enemyChampion.Name].MatchInformation;
            enemyChampionName = enemyChampion.Name;
            resultChampion = champion;
            ChangesMade = false;
            championImage.Image = HelpMethods.getImageFromLocalDirectory(champion.Image,false);
            enemyImage.Image = HelpMethods.getImageFromLocalDirectory(enemyChampion.Image,false);
            championName.Text = champion.Name;
            enemyName.Text = enemyChampionName;
            if (matchupDetailsText != null)
            {
                matchupDetailsText.Text = matchupDetails;
            }

        }
        string enemyChampionName;
        string matchupDetails;
        Champion resultChampion;
        public bool ChangesMade { get; private set; }
        public Champion Result { get { return resultChampion; } }

        private void editButton_Click(object sender, EventArgs e)
        {
            editButton.Enabled = false;
            saveButton.Enabled = true;
            backButton.Enabled = true;
            matchupDetailsText.ReadOnly = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (matchupDetails != null)
            {
                resultChampion.EditMatchup(enemyChampionName, matchupDetailsText.Text);
            }
            else
            {
                resultChampion.AddMatchup(enemyChampionName, matchupDetailsText.Text);
            }
            matchupDetails = matchupDetailsText.Text;
            ChangesMade = true;

            editButton.Enabled = true;
            saveButton.Enabled = false;
            backButton.Enabled = false;
            matchupDetailsText.ReadOnly = true;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (matchupDetails != null)
            {
                matchupDetailsText.Text = matchupDetails;
            }
            else
            {
                matchupDetailsText.Text = "";
            }

            editButton.Enabled = true;
            saveButton.Enabled = false;
            backButton.Enabled = false;
            matchupDetailsText.ReadOnly = true;
        }
        
    }
}
