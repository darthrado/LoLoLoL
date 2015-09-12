using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BanKaiEngine;

namespace LoL_Champions_and_Positions
{
    public partial class Form1 : Form
    {
        #region Form1Constructor
        public Form1()
        {
            InitializeComponent();

            playablePositions.Items.Clear();

            championImages = new Dictionary<Guid, PictureBox>();
            championTooltips = new Dictionary<Guid, ToolTip>();

            this.ControlPanel.Controls.Clear();
            Engine.LoadFromFile("rekt.gg");
            PictureListFill();
            InitListCollection(); //Initializes the champion collection List

            PrintList(Engine.SelectedChampionList.UniqueID, textSeaarchBox.Text);

        }
        #endregion

        #region ClassVariables
        Guid rightClickedPicture;
        Guid visibleListID;
        Form1State currentFormState;

        Dictionary<Guid, PictureBox> championImages;
        Dictionary<Guid, ToolTip> championTooltips;
        #endregion

        #region Enums
        /// <summary>
        /// Contains States the Form can be in
        /// </summary>
        enum Form1State
        {
            ListsView,
            ChampionSelected,
            MatchupDetails,
            InitialView
        };
        #endregion

        #region Methods

        #region Picture_Box_Manipulation_Methods
        private void PictureListFill()
        {
            foreach (Guid key in Engine.AllChampionsList.ListOfChampions.Keys)
            {
                System.Windows.Forms.PictureBox pictureBox = new System.Windows.Forms.PictureBox();
                System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();

                championImages.Add(key, pictureBox);
                championTooltips.Add(key, toolTip);

                pictureBox.Image = HelpMethods.getImageFromLocalDirectory(Engine.AllChampionsList.ListOfChampions[key].Image, true);
                pictureBox.Location = new System.Drawing.Point(0, 0);
                pictureBox.Name = "pictureBox" + Engine.AllChampionsList.ListOfChampions[key].Name;
                pictureBox.Size = new System.Drawing.Size(60, 60);
                pictureBox.TabIndex = 0;
                pictureBox.TabStop = false;
                pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
                pictureBox.Visible = false;
                pictureBox.Click += new EventHandler(pictureBox_Click);
                ControlPanel.Controls.Add(pictureBox);

                toolTip.SetToolTip(pictureBox, Engine.AllChampionsList.ListOfChampions[key].Name);
            }
        }
        private void AddNewPictureBox(Guid championUID)
        {
            System.Windows.Forms.PictureBox pictureBox = new System.Windows.Forms.PictureBox();
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();

            championImages.Add(championUID, pictureBox);
            championTooltips.Add(championUID, toolTip);

            pictureBox.Image = HelpMethods.getImageFromLocalDirectory(Engine.AllChampionsList.ListOfChampions[championUID].Image,true);
            pictureBox.Location = new System.Drawing.Point(0, 0);
            pictureBox.Name = "pictureBox" + Engine.AllChampionsList.ListOfChampions[championUID].Name;
            pictureBox.Size = new System.Drawing.Size(60, 60);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
            pictureBox.Visible = false;
            pictureBox.Click += new EventHandler(pictureBox_Click);
            ControlPanel.Controls.Add(pictureBox);

            toolTip.SetToolTip(pictureBox, Engine.AllChampionsList.ListOfChampions[championUID].Name);
        }
        private void RemovePictureBox(Guid championUID)
        {
            if (championImages.ContainsKey(championUID))
            {
                ControlPanel.Controls.Remove(championImages[championUID]);
                championImages.Remove(championUID);
                championTooltips.Remove(championUID);
            }
            
        }
        private void EditPictureBox(Guid championUID)
        {
            championImages[championUID].Name = "pictureBox" + Engine.AllChampionsList.ListOfChampions[championUID].Name;
            championImages[championUID].Image = HelpMethods.getImageFromLocalDirectory(Engine.AllChampionsList.ListOfChampions[championUID].Image, true);
            championTooltips[championUID].SetToolTip(championImages[championUID], Engine.AllChampionsList.ListOfChampions[championUID].Name);
        }
        private void HideList()
        {
            foreach (Guid key in championImages.Keys)
            {
                championImages[key].Visible = false;
            }
        }
        private void PrintList(Guid listUID, string searchText)
        {
            if (championImages.Count == 0)
            {
                return;
            }

            HideList();
            visibleListID = listUID;

            int X = ControlPanel.DisplayRectangle.Left + Constants.CHAMPION_HORIZONTAL_OFFSET;
            int Y = ControlPanel.DisplayRectangle.Top + Constants.CHAMPION_VERTICAL_OFFSET;

            if (searchText == Constants.SEARCH_TEXT)
            {
                searchText = Constants.STRING_EMPTY;
            }

            foreach(Guid key in Engine.ChampionListCollection[listUID].ListOfChampions.Keys)
            {

                // If Name or Search tag contains Search Value or Search Value is Empty
                if (Engine.ChampionListCollection[listUID].ListOfChampions[key].Name.ToUpper().Contains(searchText.ToUpper()) || Engine.ChampionListCollection[listUID].ListOfChampions[key].SearchTag.ToUpper() == searchText.ToUpper() || searchText == Constants.STRING_EMPTY)
                {
                    //Set Location + make visible
                    championImages[key].Location = new Point(X, Y);
                    championImages[key].Visible = true;
                }
                else
                {
                    //Clear Location + make invisible
                    championImages[key].Visible = false;
                    continue;
                }

                if (X + 2 * (Constants.CHAMPION_HORIZONTAL_OFFSET + Constants.CHAMPION_FRAME_WIDTH) > ControlPanel.DisplayRectangle.Left + ControlPanel.Width)
                {
                    X = ControlPanel.DisplayRectangle.Left + Constants.CHAMPION_HORIZONTAL_OFFSET;
                    Y += (Constants.CHAMPION_FRAME_HEIGHT + Constants.CHAMPION_VERTICAL_OFFSET);
                }
                else
                {
                    X += (Constants.CHAMPION_FRAME_WIDTH + Constants.CHAMPION_HORIZONTAL_OFFSET);
                }
            }
            AttachPictureBoxAttributes(listUID);
        }
        private void AttachPictureBoxAttributes(Guid listUID)
        {
            //champion.PictureBox.ContextMenuStrip
            foreach (Guid key in Engine.ChampionListCollection[listUID].ListOfChampions.Keys)
            {
                if (listUID == Engine.AllChampionsList.UniqueID)
                {
                    if (currentFormState == Form1State.MatchupDetails)
                    {
                        championImages[key].ContextMenuStrip = null;
                    }
                    else
                    {
                        championImages[key].ContextMenuStrip = this.AllChampsContextMenu;
                    }
                }
                else
                {
                    championImages[key].ContextMenuStrip = this.CustomListsStrip;
                }
            }
        }
        #endregion


        
        /// <summary>
        /// initListCollection assumes that the clast list collection has not been loaded or has just been reloaded from a file.
        /// It's job is to set all apropriate variables correctly, insuring that the screen will load correctly with the new data.
        /// </summary>
        private void InitListCollection()
        {
            RebuildElements();
            SetFormState(Form1State.InitialView);
            championListCollection.SelectedIndex = 0;
            playablePositions.SelectedIndex = 0;
            PrintList(Engine.SelectedChampionList.UniqueID, textSeaarchBox.Text);
        }

        /// <summary>
        /// Updates the List and Position Dropdowns and Rebuilds the Champion Image Context Menus
        /// </summary>
        private void RebuildElements()
        {
            updateListCollectionDropdown();
            updatePositionsDropdown();
            BuildContextMenu();
        }

        /// <summary>
        /// Updates the List Collection Dropdown based on the current lists contained in the Engine Class
        /// </summary>
        private void updateListCollectionDropdown()
        {
            championListCollection.Items.Clear();
            foreach (Guid key in Engine.ChampionListCollection.Keys)
            {
                if (Engine.ChampionListCollection[key].Role == Constants.CUSTOM_LIST_ALL)
                {
                    championListCollection.Items.Add(Engine.ChampionListCollection[key].Name);
                }
            }
        }

        /// <summary>
        /// Updates the Positions Dropdown based on the Listed Positions as well as the current List selection
        /// </summary>
        private void updatePositionsDropdown()
        {
            playablePositions.Items.Clear();
            if (championListCollection.SelectedIndex!=-1 && championListCollection.Items[championListCollection.SelectedIndex].ToString() == Constants.ALL_CHAMPIONS)
            {
                playablePositions.Items.Add(Constants.CUSTOM_LIST_ALL);
            }
            else
            {
                foreach (string position in Engine.ListPositions)
                {
                    playablePositions.Items.Add(position);
                }
            }
            playablePositions.SelectedIndex = 0;

        }

        /// <summary>
        /// Builds the All Champions Image Context Menu.
        /// </summary>
        private void BuildContextMenu()
        {


            AddChampionToListMenuItem.DropDownItems.Clear();

            foreach (Guid key in Engine.ChampionListCollection.Keys)
            {
                if (Engine.ChampionListCollection[key].Name == Constants.ALL_CHAMPIONS || Engine.ChampionListCollection[key].Role == Constants.CUSTOM_LIST_ALL)
                {
                    continue;
                }

                ToolStripMenuItem roleItem = new ToolStripMenuItem();
                roleItem.Name = Engine.ChampionListCollection[key].Role;
                roleItem.Text = Engine.ChampionListCollection[key].Role;
                roleItem.Click += new EventHandler(newItem_Click);

                ToolStripMenuItem newItem = null;
                foreach (ToolStripMenuItem menuItems in AddChampionToListMenuItem.DropDownItems)
                {
                    if (menuItems.Text == Engine.ChampionListCollection[key].Name)
                    {
                        newItem = menuItems;
                    }
                }

                if (newItem == null)
                {
                    newItem = new ToolStripMenuItem();

                    newItem.Name = Engine.ChampionListCollection[key].Name;
                    newItem.Text = Engine.ChampionListCollection[key].Name;
                    //newItem.OwnerItem = toolStripMenuItem3;
                    //roleItem.Owner = newItem;

                    newItem.DropDownItems.Add(roleItem);
                    AddChampionToListMenuItem.DropDownItems.Add(newItem);

                }
                else
                {
                    newItem.DropDownItems.Add(roleItem);
                }
            }
        }


        /// <summary>
        /// Depending on the selected values in ComboBox List and Position - gets the corresponding ChampionCollection from the list of Collections
        /// </summary>
        /// <returns>ChampionCollection</returns>
        Guid getSelectedList()
        {
            if (championListCollection.SelectedIndex == -1 || playablePositions.SelectedIndex == -1)
                return Guid.Empty;

            string selectedListName = championListCollection.Items[championListCollection.SelectedIndex].ToString();
            string selectedPositionName = playablePositions.Items[playablePositions.SelectedIndex].ToString();

            return Engine.GetListReference(selectedListName, selectedPositionName);
        }
        
        public void ProcessChampionPictureClick(Guid clickedChampionUID)
        {
            if (currentFormState != Form1State.MatchupDetails)
            {
                Engine.SetSelectedChampion(clickedChampionUID);
                if (clickedChampionUID != Guid.Empty)
                {
                    PictureSelectedChamp.Image = HelpMethods.getImageFromLocalDirectory(Engine.SelectedChampion.Image,false);
                    SelectedChampTextBox.Text = Engine.SelectedChampion.Name;
                    SetFormState(Form1State.ChampionSelected);
                }
                else
                {
                    PictureSelectedChamp.Image = Properties.Resources.DefaultImage;
                    SelectedChampTextBox.Text = Constants.STRING_EMPTY;
                }
            }
            else
            {
                if (Engine.SelectedChampion != null)
                {
                    MatchupDetails championDialog = new MatchupDetails(Engine.SelectedChampion,Engine.AllChampionsList.ListOfChampions[clickedChampionUID]);

                    championDialog.ShowDialog();

                    if (championDialog.ChangesMade)
                    {
                        //HelpMethods.UpdateChampionAcrossAllCollections(ref collectionList,championDialog.Result);
                        Engine.SaveToFile("rekt.gg");
                    }
                }
            }

        }

        void SetFormState(Form1State formState)
        {
            currentFormState = formState;

            bool listsAndManageFlag;
            bool championSelectedControlsFlag;

            if (formState == Form1State.ListsView || formState == Form1State.ChampionSelected || formState == Form1State.InitialView)
            {
                if (Engine.SelectedChampionList != null)
                {
                    groupBoxChampions.Text = Engine.SelectedChampionList.Name + "/" + Engine.SelectedChampionList.Role;
                }
                else
                {
                    groupBoxChampions.Text = Constants.ALL_CHAMPIONS + "/" + Constants.CUSTOM_LIST_ALL;
                }

                listsAndManageFlag = true;
            }
            else
            {
                if (Engine.SelectedChampion == null)
                {
                    throw new Exception("No Selected Champion");
                }

                groupBoxChampions.Text = Engine.SelectedChampion.Name + " Matchups Info";

                listsAndManageFlag = false;
            }

            if (formState == Form1State.ListsView || formState == Form1State.InitialView)
            {
                championSelectedControlsFlag = false;
            }
            else
            {
                championSelectedControlsFlag = true;
            }

            ManagePositionsButton.Enabled = listsAndManageFlag;
            ButtonManageLists.Enabled = listsAndManageFlag;
            ButtonManageChamp.Enabled = listsAndManageFlag;

            championListCollection.Enabled = listsAndManageFlag;
            playablePositions.Enabled = listsAndManageFlag;

            PictureSelectedChamp.Visible = championSelectedControlsFlag;
            SelectedChampTextBox.Visible = championSelectedControlsFlag;
            ChampionDetailsButton.Enabled = championSelectedControlsFlag;
            ButtonMatchupDetails.Enabled = championSelectedControlsFlag;
            BackButton.Enabled = championSelectedControlsFlag;
        }

        #endregion

        #region EventHandlers

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (Engine.SelectedChampionList != null)
            {

                System.Drawing.Point gbLocation = groupBoxChampions.Location;

                int initialSize = (ControlPanel.Width - Constants.CHAMPION_HORIZONTAL_OFFSET) / (Constants.CHAMPION_FRAME_WIDTH + Constants.CHAMPION_HORIZONTAL_OFFSET);

                groupBoxChampions.Height = this.ClientSize.Height - gbLocation.Y - Constants.GROUP_BOX_BORDER_OFFSET;
                groupBoxChampions.Width = this.ClientSize.Width - gbLocation.X - Constants.GROUP_BOX_BORDER_OFFSET;
                ControlPanel.Height = groupBoxChampions.Height;
                ControlPanel.Width = groupBoxChampions.Width - Constants.GROUP_BOX_BORDER_OFFSET;

                int afterSize = (ControlPanel.Width - Constants.CHAMPION_HORIZONTAL_OFFSET) / (Constants.CHAMPION_FRAME_WIDTH + Constants.CHAMPION_HORIZONTAL_OFFSET);

                if (initialSize != afterSize)
                {
                    PrintList(Engine.SelectedChampionList.UniqueID, textSeaarchBox.Text);
                }
            }
        }

        private void manageChamp_Click(object sender, EventArgs e)
        {
            Manage manageChamp = new Manage(Enums.ManageDialogue.Champion);

            manageChamp.ShowDialog();

            if (manageChamp.FormResponse.Count > 0)
            {
                foreach (ManageFormResponse response in manageChamp.FormResponse)
                {
                    if (response.RespondCommand == Enums.ManageFormState.New)
                    {
                        Engine.CreateChampion(new Champion(response.Name, response.Picture, Constants.STRING_EMPTY, Constants.STRING_EMPTY));

                        AddNewPictureBox(Engine.AllChampionsList.GetChampionID(response.Name));
                    }
                    else if (response.RespondCommand == Enums.ManageFormState.Edit)
                    {
                        Champion forEdit = Engine.AllChampionsList.ListOfChampions[response.UniqueID];

                        forEdit.Name = response.Name;
                        forEdit.Image = response.Picture;

                        EditPictureBox(response.UniqueID);
                    }
                    else if (response.RespondCommand == Enums.ManageFormState.Delete)
                    {
                        Engine.DeleteChampion(response.UniqueID);

                        RemovePictureBox(response.UniqueID);
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
            PrintList(Engine.SelectedChampionList.UniqueID, textSeaarchBox.Text);

            //Save changes to file
            Engine.SaveToFile("rekt.gg");

        }

        private void ManagePositionsButton_Click(object sender, EventArgs e)
        {
            Manage manageList = new Manage(Enums.ManageDialogue.Position);

            manageList.ShowDialog();

            if (manageList.FormResponse.Count > 0)
            {
                foreach (ManageFormResponse response in manageList.FormResponse)
                {
                    if (response.RespondCommand == Enums.ManageFormState.New)
                    {
                        Engine.AddPosition(response.Name);
                    }
                    else if (response.RespondCommand == Enums.ManageFormState.Edit)
                    {
                        //Engine.RenameList(Engine.GetAllListsWithName(Engine.ChampionListCollection[response.UniqueID].Name), response.Name);
                        Engine.EditPosition(response.OldName, response.Name);

                    }
                    else if (response.RespondCommand == Enums.ManageFormState.Delete)
                    {
                        //Engine.RemoveList(Engine.GetAllListsWithName(response.Name));
                        Engine.RemovePosition(response.Name);
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
            RebuildElements();

            //Save changes to file
            Engine.SaveToFile("rekt.gg");
        }

        private void manageLists_Click(object sender, EventArgs e)
        {
            Manage manageList = new Manage(Enums.ManageDialogue.List);

            manageList.ShowDialog();

            if (manageList.FormResponse.Count > 0)
            {
                foreach (ManageFormResponse response in manageList.FormResponse)
                {
                    if (response.RespondCommand == Enums.ManageFormState.New)
                    {
                        Engine.AddList(response.Name);
                    }
                    else if (response.RespondCommand == Enums.ManageFormState.Edit)
                    {
                        Engine.RenameList(Engine.GetAllListsWithName(Engine.ChampionListCollection[response.UniqueID].Name), response.Name);
                       

                    }
                    else if (response.RespondCommand == Enums.ManageFormState.Delete)
                    {
                        Engine.RemoveList(Engine.GetAllListsWithName(response.Name));
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
            RebuildElements();

            //Save changes to file
            Engine.SaveToFile("rekt.gg");
        }

        private void ListCollection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            updatePositionsDropdown();

            Guid selectionUID = getSelectedList();

            if (selectionUID != Guid.Empty)
            {
                Engine.SetSelectedList(selectionUID);

                PrintList(Engine.SelectedChampionList.UniqueID, textSeaarchBox.Text);
            }
            SetFormState(Form1State.ListsView);
        }

        private void Positions_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Engine.SelectedChampionList != null)
            {
                Guid selectionUID = getSelectedList();

                if (selectionUID != Guid.Empty)
                {
                    Engine.SetSelectedList(selectionUID);

                    PrintList(Engine.SelectedChampionList.UniqueID, textSeaarchBox.Text);
                }
            }
            SetFormState(Form1State.ListsView);
        }

        public void newItem_Click(object sender, EventArgs e)
        {
            
            ToolStripMenuItem clickedMenu = (ToolStripMenuItem)sender;

            //we already have the clicked champion ID in rightClickedPicture

            //Get chosen list and it's All counterpart's ID
            Guid listUID = Engine.GetListReference(clickedMenu.OwnerItem.Name, clickedMenu.Name);
            Engine.AddChampionToList(listUID, rightClickedPicture);
            
            //Save changes to file
            Engine.SaveToFile("rekt.gg");
             
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            foreach(Guid key in championImages.Keys)
            {
                if(championImages[key] == AllChampsContextMenu.SourceControl)
                {
                    rightClickedPicture = key;
                    break;
                }
            }
        }

        private void removeFromListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guid forRemoveID = rightClickedPicture;

            Engine.RemoveChampionFromList(Engine.SelectedChampionList.UniqueID, forRemoveID);

            PrintList(Engine.SelectedChampionList.UniqueID, textSeaarchBox.Text);

            //Save changes to file
            Engine.SaveToFile("rekt.gg");

        }

        private void CustomListsStrip_Opened(object sender, EventArgs e)
        {
            foreach (Guid key in championImages.Keys)
            {
                if (championImages[key] == CustomListsStrip.SourceControl)
                {
                    rightClickedPicture = key;
                    break;
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            SetFormState(Form1State.ChampionSelected);
            PrintList(Engine.SelectedChampionList.UniqueID, textSeaarchBox.Text);
        }

        private void ButtonMatchupDetails_Click(object sender, EventArgs e)
        {
            SetFormState(Form1State.MatchupDetails);
            PrintList(Engine.AllChampionsList.UniqueID, textSeaarchBox.Text);

        }

        private void textSeaarchBox_TextChanged(object sender, EventArgs e)
        {
            //selectedCollection.Print(textSeaarchBox.Text);
            PrintList(visibleListID, textSeaarchBox.Text);
        }

        private void ChampionDetailsButton_Click(object sender, EventArgs e)
        {
            if (Engine.SelectedChampion != null)
            {
                ChampionDetails championDialog = new ChampionDetails();

                championDialog.ShowDialog();

                if (championDialog.ChangesMade)
                {
                    //HelpMethods.UpdateChampionAcrossAllCollections(ref collectionList, championDialog.Result);
                    Engine.SaveToFile("rekt.gg");
                }
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (championImages.ContainsValue((PictureBox)sender))
            {
                foreach (Guid key in championImages.Keys)
                {
                    if (championImages[key] == (PictureBox)sender)
                    {
                        ProcessChampionPictureClick(key);
                    }
                }
            }
            else
            {
                throw new Exception("champion images don't contain this image??");
            }
        }
        #endregion




    }
}
