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
    public partial class Form1 : Form
    {
        #region Form1Constructor
        public Form1()
        {
            InitializeComponent();
            //ListPositions
            playablePositions.Items.Clear();
            foreach (Enums.ListPositions position in Enum.GetValues(typeof(Enums.ListPositions)))
            {
                playablePositions.Items.Add(position.ToString());
            }

            initListCollection(); //Initializes the champion collection List

            selectedCollection.Print(textSeaarchBox.Text);

            saveFile = new ChampionToFile();
        }
        #endregion

        #region ClassVariables
        List<ChampionCollection> collectionList;
        ChampionCollection selectedCollection;
        ChampionCollection allChampionsCollection;
        ChampionContainer selectedChampion;
        Control rightClickedControl;
        bool displayChampionMatchupsList;

        ChampionToFile saveFile;
        #endregion


        #region Enums
        enum Form1State
        {
            ListsView,
            ChampionSelected,
            InitialView
        };
        #endregion

        #region Methods
        /// <summary>
        /// initListCollection assumes that the clast list collection has not been loaded or has just been reloaded from a file.
        /// It's job is to set all apropriate variables correctly, unsuring that the screen will load correctly with the new data.
        /// </summary>
        private void initListCollection()
        {
            if (collectionList == null)
            {
                // Temporary init for test purpouses.
                collectionList = new List<ChampionCollection>();
                selectedCollection = new ChampionCollection(Constants.ALL_CHAMPIONS, Enums.ListPositions.All.ToString()/*, AllChampsContextMenu, groupBox1, this*/);
                collectionList.Add(selectedCollection);
                allChampionsCollection = collectionList[0];

                Champion newCHamp = new Champion("Thresh", "Thresh.png", "", "Muh best support");
                selectedCollection.Add(newCHamp);
                newCHamp = new Champion("Ezreal", "Ezreal.png", "", "Gay");
                selectedCollection.Add(newCHamp);
                newCHamp = new Champion("Taric", "Taric.png", "", "HA GAYYYYYYY");
                selectedCollection.Add(newCHamp);
                newCHamp = new Champion("Ahri", "Ahri.png", "", "Foxy lady");
                selectedCollection.Add(newCHamp);
                newCHamp = new Champion("Nami", "Nami.png", "", "Sushi");
                selectedCollection.Add(newCHamp);
                newCHamp = new Champion("Tryndamere", "Tryndamere.png", "", "Wanker");
                selectedCollection.Add(newCHamp);
                newCHamp = new Champion("Fiora", "Fiora.png", "", "I loooooong for a wortzy opponenet");
                selectedCollection.Add(newCHamp);
                newCHamp = new Champion("Elise", "Elise.png", "", "Spider Woman");
                selectedCollection.Add(newCHamp);
                newCHamp = new Champion("Draven", "Draven.png", "", "League of DRAVEEEEEN");
                selectedCollection.Add(newCHamp);

                selectedCollection.AddContextMenu(AllChampsContextMenu);
                selectedCollection.AddGroupBox(ref groupBox1);
                selectedCollection.AddFormReference(this);
            }
            else
            {
                foreach (ChampionCollection List in collectionList)
                {

                    List.AddGroupBox(ref this.groupBox1);
                    List.AddFormReference(this);

                    if (List.Name == Constants.ALL_CHAMPIONS)
                    {
                        List.AddContextMenu(this.AllChampsContextMenu);
                        selectedCollection = List;
                        allChampionsCollection = List;
                    }
                    else
                    {
                        List.AddContextMenu(this.CustomListsStrip);
                    }
                }

            }

            selectedChampion = null;
            updateListCollectionDropdown();
            BuildContextMenu();
            SetFormState(Form1State.InitialView);

            selectedCollection.Print("");
        }

        private void updateListCollectionDropdown()
        {
            championListCollection.Items.Clear();
            foreach (ChampionCollection champList in collectionList)
            {
                if (champList.Role == Enums.ListPositions.All.ToString())
                {
                    championListCollection.Items.Add(champList.Name);
                }
            }
        }

        /// <summary>
        /// Depending on the selected values in ComboBox List and Position - gets the corresponding ChampionCollection from the list of Collections
        /// </summary>
        /// <returns>ChampionCollection</returns>
        ChampionCollection getSelectedList()
        {
            if (championListCollection.SelectedIndex == -1 || playablePositions.SelectedIndex == -1)
                return null;

            foreach (ChampionCollection ListEntry in collectionList)
            {
                if (ListEntry.Name == championListCollection.Items[championListCollection.SelectedIndex].ToString() && ListEntry.Role == playablePositions.Items[playablePositions.SelectedIndex].ToString())
                {
                    return ListEntry;
                }
            }
            return null;
        }

        public void ProcessChampionPictureClick(ChampionContainer selChamp)
        {
            if (displayChampionMatchupsList == false)
            {
                selectedChampion = selChamp;
                if (selChamp != null)
                {
                    pictureSelectedChamp.Image = HelpMethods.getImageFromLocalDirectory(selChamp.Image);
                    selectedChampTextBox.Text = selChamp.Name;

                    SetFormState(Form1State.ChampionSelected);
                }
                else
                {
                    pictureSelectedChamp.Image = Properties.Resources.DefaultImage;
                    selectedChampTextBox.Text = "";

                    SetFormState(Form1State.ListsView);
                }
            }
            else
            {
                MessageBox.Show("Penis");
            }

        }

        private void BuildContextMenu()
        {


            toolStripMenuItem3.DropDownItems.Clear();

            foreach (ChampionCollection list in collectionList)
            {
                if (list.Name == Constants.ALL_CHAMPIONS || list.Role == Enums.ListPositions.All.ToString())
                {
                    continue;
                }

                ToolStripMenuItem roleItem = new ToolStripMenuItem();
                roleItem.Name = list.Role;
                roleItem.Text = list.Role;
                roleItem.Click += new EventHandler(newItem_Click);

                ToolStripMenuItem newItem = null;
                foreach (ToolStripMenuItem menuItems in toolStripMenuItem3.DropDownItems)
                {
                    if (menuItems.Text == list.Name)
                    {
                        newItem = menuItems;
                    }
                }

                if (newItem == null)
                {
                    newItem = new ToolStripMenuItem();

                    newItem.Name = list.Name;
                    newItem.Text = list.Name;
                    //newItem.OwnerItem = toolStripMenuItem3;
                    //roleItem.Owner = newItem;

                    newItem.DropDownItems.Add(roleItem);
                    toolStripMenuItem3.DropDownItems.Add(newItem);

                }
                else
                {
                    newItem.DropDownItems.Add(roleItem);
                }
            }
        }

        void SetFormState(Form1State formState)
        {
            if (formState == Form1State.ChampionSelected)
            {
                if (selectedChampion == null)
                {
                    throw new Exception("No Selected Champion");
                }

                championListCollection.Enabled = false;
                playablePositions.Enabled = false;

                pictureSelectedChamp.Enabled = true;
                selectedChampTextBox.Visible = true;
                ChampionDetailsButton.Enabled = true;
                ButtonMatchupDetails.Enabled = true;
                BackButton.Enabled = true;

            }
            if (formState == Form1State.ListsView)
            {
                if (selectedCollection == null)
                {
                    throw new Exception("No selected List");
                }

                championListCollection.Enabled = true;
                playablePositions.Enabled = true;

                pictureSelectedChamp.Enabled = false;
                selectedChampTextBox.Visible = false;
                ChampionDetailsButton.Enabled = false;
                ButtonMatchupDetails.Enabled = false;
                BackButton.Enabled = false;

                groupBox1.Text = selectedCollection.Name + "/" + selectedCollection.Role;

                if (displayChampionMatchupsList)
                {
                    displayChampionMatchupsList = false;

                    //TODO once matchup collection is implemented: matchupCollection hide
                    selectedCollection.Print(textSeaarchBox.Text);
                }
            }
            if (formState == Form1State.InitialView)
            {
                displayChampionMatchupsList = false;

                championListCollection.Enabled = true;
                playablePositions.Enabled = true;

                pictureSelectedChamp.Enabled = false;
                selectedChampTextBox.Visible = false;
                ChampionDetailsButton.Enabled = false;
                ButtonMatchupDetails.Enabled = false;
                BackButton.Enabled = false;

                groupBox1.Text = Constants.ALL_CHAMPIONS + "/" + Enums.ListPositions.All.ToString();
                championListCollection.SelectedIndex = 0;
                playablePositions.SelectedIndex = 0;

            }
        }

        #endregion

        #region EventHandlers

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (selectedCollection != null)
            {
                System.Drawing.Point gbLocation = groupBox1.Location;

                int initialSize = (groupBox1.Width - Constants.CHAMPION_HORIZONTAL_OFFSET) / (Constants.CHAMPION_FRAME_WIDTH + Constants.CHAMPION_HORIZONTAL_OFFSET);

                groupBox1.Height = this.ClientSize.Height - gbLocation.Y - Constants.GROUP_BOX_BORDER_OFFSET;
                groupBox1.Width = this.ClientSize.Width - gbLocation.X - Constants.GROUP_BOX_BORDER_OFFSET;

                int afterSize = (groupBox1.Width - Constants.CHAMPION_HORIZONTAL_OFFSET) / (Constants.CHAMPION_FRAME_WIDTH + Constants.CHAMPION_HORIZONTAL_OFFSET);

                if (initialSize != afterSize)
                {
                    selectedCollection.Print(textSeaarchBox.Text);
                }
            }
        }

        private void manageChamp_Click(object sender, EventArgs e)
        {
            Manage manageChamp = new Manage(collectionList, Enums.ManageDialogue.Champion);

            manageChamp.ShowDialog();

            if (manageChamp.FormResponse.Count > 0)
            {
                foreach (ManageFormResponse response in manageChamp.FormResponse)
                {
                    if (response.RespondCommand == Enums.ManageFormState.New)
                    {
                        foreach (ChampionCollection collectionItem in collectionList)
                        {
                            if (collectionItem.Name == Constants.ALL_CHAMPIONS)
                            {
                                collectionItem.Add(new Champion(response.Name, response.Picture, "", ""));

                                break;
                            }
                        }
                    }
                    else if (response.RespondCommand == Enums.ManageFormState.Edit)
                    {
                        foreach (ChampionCollection collectionItem in collectionList)
                        {
                            foreach (ChampionContainer containedChampion in collectionItem.ContainedChampions())
                            {
                                if (containedChampion.Name == response.Name)
                                {
                                    containedChampion.Name = response.NewName;
                                    containedChampion.Image = response.Picture;
                                    break; // Champion names should be unique so it should be safe to use break here;
                                }

                            }
                        }
                    }
                    else if (response.RespondCommand == Enums.ManageFormState.Delete)
                    {
                        foreach (ChampionCollection collectionItem in collectionList)
                        {
                            collectionItem.Remove(response.Name);
                        }
                    }
                    else
                    {
                        throw new Exception("Incorrect Form Response Command");
                    }
                }
            }
            else
            {
                MessageBox.Show("No changes were made");
            }

            //View newly added/edite champions
            selectedCollection.Print(textSeaarchBox.Text);

            //Save changes to file
            saveFile.ImportLines(collectionList);
            saveFile.saveToFile("rekt.gg");

        }

        private void manageLists_Click(object sender, EventArgs e)
        {
            Manage manageList = new Manage(collectionList, Enums.ManageDialogue.List);

            manageList.ShowDialog();

            if (manageList.FormResponse.Count > 0)
            {
                foreach (ManageFormResponse response in manageList.FormResponse)
                {
                    if (response.RespondCommand == Enums.ManageFormState.New)
                    {
                        foreach (Enums.ListPositions position in Enum.GetValues(typeof(Enums.ListPositions)))
                        {
                            collectionList.Add(new ChampionCollection(response.Name, position.ToString(), CustomListsStrip, groupBox1, this));
                        }
                    }
                    else if (response.RespondCommand == Enums.ManageFormState.Edit)
                    {
                        foreach (ChampionCollection collectionItem in collectionList)
                        {
                            if (response.Name == collectionItem.Name)
                            {
                                collectionItem.Name = response.NewName;
                            }
                        }
                    }
                    else if (response.RespondCommand == Enums.ManageFormState.Delete)
                    {
                        for (int i = collectionList.Count - 1; i >= 0; i--)
                        {
                            if (response.Name == collectionList[i].Name)
                            {
                                collectionList.RemoveAt(i);
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Incorrect Form Response Command");
                    }
                }
            }
            else
            {
                MessageBox.Show("No changes were made");
            }

            //Update the dropdown with the newly added/edited lists and rebuild the context menu
            updateListCollectionDropdown();
            BuildContextMenu();

            //Save changes to file
            saveFile.ImportLines(collectionList);
            saveFile.saveToFile("rekt.gg");
        }

        private void ListCollection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (selectedCollection != null)
            {
                ChampionCollection newCollection = getSelectedList();

                if (newCollection != null)
                {

                    selectedCollection.Hide();

                    selectedCollection = newCollection;

                    selectedCollection.Print(textSeaarchBox.Text);
                }
            }
            SetFormState(Form1State.ListsView);
        }

        private void Positions_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (selectedCollection != null)
            {
                ChampionCollection newCollection = getSelectedList();

                if (newCollection != null)
                {

                    selectedCollection.Hide();

                    selectedCollection = newCollection;

                    selectedCollection.Print(textSeaarchBox.Text);
                }
            }
            SetFormState(Form1State.ListsView);
        }

        public void newItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedMenu = (ToolStripMenuItem)sender;

            ChampionContainer clickedChampion = null;
            foreach (ChampionContainer champion in selectedCollection.ContainedChampions())
            {
                if (champion.PictureBox == rightClickedControl)
                {
                    clickedChampion = champion;
                }
            }

            if (clickedChampion == null)
            {
                MessageBox.Show("If you are here it means that the developer is an idiot");
                return;
            }

            foreach (ChampionCollection List in collectionList)
            {
                if (List.Name == clickedMenu.OwnerItem.Name && (List.Role == clickedMenu.Name || List.Role == Enums.ListPositions.All.ToString()))
                {
                    if (List.GetChampion(clickedChampion.Name) != null)
                    {
                        continue;
                    }

                    List.Add(new Champion(clickedChampion.Name, clickedChampion.Image, clickedChampion.SearchTag, clickedChampion.Description));
                }
            }

            //Save changes to file
            saveFile.ImportLines(collectionList);
            saveFile.saveToFile("rekt.gg");
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            rightClickedControl = AllChampsContextMenu.SourceControl;
        }

        private void removeFromListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChampionContainer clickedChampion = null;
            foreach (ChampionContainer champion in selectedCollection.ContainedChampions())
            {
                if (champion.PictureBox == rightClickedControl)
                {
                    clickedChampion = champion;
                }
            }

            ChampionCollection tempForDelete = null; //used to store the All Champions from a set of lists with the Same name/Different role. If the removed champion is present only in the list we are removing it from, remove it from All as well
            int deleteCounter = 0;

            foreach (ChampionCollection List in collectionList)
            {

                if (selectedCollection.Role == Enums.ListPositions.All.ToString())
                {

                    if (List.Name == selectedCollection.Name)
                    {
                        List.Remove(clickedChampion.Name);
                    }

                }
                else
                {
                    if (List.Name == selectedCollection.Name && List.Role == Enums.ListPositions.All.ToString())
                    {
                        tempForDelete = List;
                    }
                    else if (List.Name == selectedCollection.Name && List.Role != Enums.ListPositions.All.ToString())
                    {
                        ChampionContainer hasChampion = List.GetChampion(clickedChampion.Name);

                        if (List.Role == selectedCollection.Role && hasChampion != null)
                        {
                            List.Remove(clickedChampion.Name);
                            deleteCounter++;

                        }
                        else if (List.Role != selectedCollection.Role && hasChampion != null)
                        {
                            deleteCounter++;
                        }

                    }
                }

            }

            if (deleteCounter == 1)
            {
                tempForDelete.Remove(clickedChampion.Name);
            }
            selectedCollection.Print(textSeaarchBox.Text);

            //Save changes to file
            saveFile.ImportLines(collectionList);
            saveFile.saveToFile("rekt.gg");

        }

        private void CustomListsStrip_Opened(object sender, EventArgs e)
        {
            rightClickedControl = CustomListsStrip.SourceControl;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            allChampionsCollection.AddContextMenu(AllChampsContextMenu);
            allChampionsCollection.Hide();

            SetFormState(Form1State.ListsView);

        }

        private void ButtonMatchupDetails_Click(object sender, EventArgs e)
        {
            displayChampionMatchupsList = true;
            groupBox1.Text = selectedChampion.Name + " Matchups Info";
            allChampionsCollection.AddContextMenu(null);
            selectedCollection.Hide();
            allChampionsCollection.Print(textSeaarchBox.Text);
            allChampionsCollection.AddGroupBox(ref groupBox1); // TOTOTO

            if (true)
            {
                MessageBox.Show(allChampionsCollection.GetChampion("Nami").Visible.ToString());
            }
            //TODO once ChampionMatchupsList is implemented do stuff here

        }
        #endregion

        private void textSeaarchBox_TextChanged(object sender, EventArgs e)
        {
            selectedCollection.Print(textSeaarchBox.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFile.ImportLines(collectionList);
            saveFile.saveToFile("rekt.gg");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFile.getFromFile("rekt.gg");
            this.groupBox1.Controls.Clear();
            collectionList.Clear();
            collectionList = saveFile.ExportLines();

            initListCollection();
            //Warning: When Loading a List, you must reset all variables connected with that list
            //When Using the Add% functions on a list, Print of the currently selected list should be called so that posible data changes are updated
        }

        private void ChampionDetailsButton_Click(object sender, EventArgs e)
        {
            if (selectedChampion != null)
            {
                ChampionDetails championDialog = new ChampionDetails(selectedChampion);

                championDialog.ShowDialog();

                if (championDialog.ChangesMade)
                {
                    selectedChampion = championDialog.Result;
                    saveFile.ImportLines(collectionList);
                    saveFile.saveToFile("rekt.gg");
                }
            }
        }


    }
}
