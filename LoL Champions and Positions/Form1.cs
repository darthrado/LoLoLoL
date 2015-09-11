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

            playablePositions.Items.Clear();

            championImages = new Dictionary<Guid, PictureBox>();
            championTooltips = new Dictionary<Guid, ToolTip>();
            /*First time till I fix data*/

            this.controlPanel.Controls.Clear();
            Engine.LoadFromFile("rekt.gg");
            PictureListFill();
            initListCollection(); //Initializes the champion collection List

            PrintList(Engine.SelectedChampionList.UniqueID, textSeaarchBox.Text);

        }
        #endregion

        #region ClassVariables
        //List<ChampionCollection> collectionList;
        //ChampionCollection selectedCollection;
        //ChampionCollection allChampionsCollection;
        //ChampionContainer selectedChampion;
        Guid rightClickedPicture;
        Guid visibleListID;
        bool displayChampionMatchupsList;

        Dictionary<Guid, PictureBox> championImages;
        Dictionary<Guid, ToolTip> championTooltips;
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
                controlPanel.Controls.Add(pictureBox);

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
            controlPanel.Controls.Add(pictureBox);

            toolTip.SetToolTip(pictureBox, Engine.AllChampionsList.ListOfChampions[championUID].Name);
        }
        private void RemovePictureBox(Guid championUID)
        {
            controlPanel.Controls.Remove(championImages[championUID]);
            championImages.Remove(championUID);
            championTooltips.Remove(championUID);
            
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

            int X = controlPanel.DisplayRectangle.Left + Constants.CHAMPION_HORIZONTAL_OFFSET;
            int Y = controlPanel.DisplayRectangle.Top + Constants.CHAMPION_VERTICAL_OFFSET;

            if (searchText == Constants.SEARCH_TEXT)
            {
                searchText = "";
            }

            foreach(Guid key in Engine.ChampionListCollection[listUID].ListOfChampions.Keys)
            {

                // If Name or Search tag contains Search Value or Search Value is Empty
                if (Engine.ChampionListCollection[listUID].ListOfChampions[key].Name.ToUpper().Contains(searchText.ToUpper()) || Engine.ChampionListCollection[listUID].ListOfChampions[key].SearchTag.ToUpper() == searchText.ToUpper() || searchText == "")
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

                if (X + 2 * (Constants.CHAMPION_HORIZONTAL_OFFSET + Constants.CHAMPION_FRAME_WIDTH) > controlPanel.DisplayRectangle.Left + controlPanel.Width)
                {
                    X = controlPanel.DisplayRectangle.Left + Constants.CHAMPION_HORIZONTAL_OFFSET;
                    Y += (Constants.CHAMPION_FRAME_HEIGHT + Constants.CHAMPION_VERTICAL_OFFSET);
                }
                else
                {
                    X += (Constants.CHAMPION_FRAME_WIDTH + Constants.CHAMPION_HORIZONTAL_OFFSET);
                }
            }
            AttachPictureBoxAttributes(listUID);
        }
        #endregion

        private void AttachPictureBoxAttributes(Guid listUID)
        {
            //champion.PictureBox.ContextMenuStrip
            foreach (Guid key in Engine.ChampionListCollection[listUID].ListOfChampions.Keys)
            {
                if (listUID == Engine.AllChampionsList.UniqueID)
                {
                    championImages[key].ContextMenuStrip = this.AllChampsContextMenu;
                }
                else
                {
                    championImages[key].ContextMenuStrip = this.CustomListsStrip;
                }
            }
        }
        
        /// <summary>
        /// initListCollection assumes that the clast list collection has not been loaded or has just been reloaded from a file.
        /// It's job is to set all apropriate variables correctly, unsuring that the screen will load correctly with the new data.
        /// </summary>
        private void initListCollection()
        {
            /*
            if (collectionList == null)
            {
                MessageBox.Show("Awww shit nigga");
            }
            else
            {
                foreach (ChampionCollection List in collectionList)
                {

                    List.AddControlPanel(ref this.controlPanel);
                    List.AddFormReference(this);

                    if (List.Name == Constants.ALL_CHAMPIONS)
                    {
                        List.AddContextMenu(this.AllChampsContextMenu);
                        selectedCollection = List;
                        allChampionsCollection = List;
                        allChampionsCollection.Sort();

                    }
                    else
                    {
                        List.AddContextMenu(this.CustomListsStrip);
                    }
                }

            }

            selectedChampion = null;*/
            RebuildElements();
            SetFormState(Form1State.InitialView);

            PrintList(Engine.SelectedChampionList.UniqueID, textSeaarchBox.Text);
        }

        private void RebuildElements()
        {
            updateListCollectionDropdown();
            updatePositionsDropdown();
            BuildContextMenu();
        }

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
        private void updatePositionsDropdown()
        {
            playablePositions.Items.Clear();
            foreach (string position in Engine.ListPositions)
            {
                playablePositions.Items.Add(position);
            }
        }
        private void BuildContextMenu()
        {


            toolStripMenuItem3.DropDownItems.Clear();

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
                foreach (ToolStripMenuItem menuItems in toolStripMenuItem3.DropDownItems)
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
                    toolStripMenuItem3.DropDownItems.Add(newItem);

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

            return Engine.GetListReference(championListCollection.Items[championListCollection.SelectedIndex].ToString(),playablePositions.Items[playablePositions.SelectedIndex].ToString());
        }
        

        public void ProcessChampionPictureClick(Guid clickedChampionUID)
        {
            if (displayChampionMatchupsList == false)
            {
                Engine.SetSelectedChampion(clickedChampionUID);
                if (clickedChampionUID != Guid.Empty)
                {
                    pictureSelectedChamp.Image = HelpMethods.getImageFromLocalDirectory(Engine.SelectedChampion.Image,false);
                    selectedChampTextBox.Text = Engine.SelectedChampion.Name;

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
            if (formState == Form1State.ChampionSelected)
            {
                if (Engine.SelectedChampion == null)
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
                if (Engine.SelectedChampionList == null)
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

                groupBox1.Text = Engine.SelectedChampionList.Name + "/" + Engine.SelectedChampionList.Role;

                if (displayChampionMatchupsList)
                {
                    displayChampionMatchupsList = false;
                    ManagePositionsButton.Enabled = true;
                    buttonManageLists.Enabled = true;
                    buttonManageChamp.Enabled = true;
                    //TODO once matchup collection is implemented: matchupCollection hide
                    PrintList(Engine.SelectedChampionList.UniqueID, textSeaarchBox.Text);
                }
            }
            if (formState == Form1State.InitialView)
            {
                displayChampionMatchupsList = false;

                ManagePositionsButton.Enabled = true;
                buttonManageLists.Enabled = true;
                buttonManageChamp.Enabled = true;

                championListCollection.Enabled = true;
                playablePositions.Enabled = true;

                pictureSelectedChamp.Enabled = false;
                selectedChampTextBox.Visible = false;
                ChampionDetailsButton.Enabled = false;
                ButtonMatchupDetails.Enabled = false;
                BackButton.Enabled = false;

                groupBox1.Text = Constants.ALL_CHAMPIONS + "/" + Constants.CUSTOM_LIST_ALL;
                //championListCollection.SelectedIndex = 0;
               // playablePositions.SelectedIndex = 0;

            }
        }

        #endregion

        #region EventHandlers

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (Engine.SelectedChampionList != null)
            {

                System.Drawing.Point gbLocation = groupBox1.Location;

                int initialSize = (controlPanel.Width - Constants.CHAMPION_HORIZONTAL_OFFSET) / (Constants.CHAMPION_FRAME_WIDTH + Constants.CHAMPION_HORIZONTAL_OFFSET);

                groupBox1.Height = this.ClientSize.Height - gbLocation.Y - Constants.GROUP_BOX_BORDER_OFFSET;
                groupBox1.Width = this.ClientSize.Width - gbLocation.X - Constants.GROUP_BOX_BORDER_OFFSET;
                controlPanel.Height = groupBox1.Height;
                controlPanel.Width = groupBox1.Width - Constants.GROUP_BOX_BORDER_OFFSET;

                int afterSize = (controlPanel.Width - Constants.CHAMPION_HORIZONTAL_OFFSET) / (Constants.CHAMPION_FRAME_WIDTH + Constants.CHAMPION_HORIZONTAL_OFFSET);

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
                        Engine.CreateChampion(new Champion(response.Name,response.Picture,"",""));

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
                SetFormState(Form1State.ListsView);
            }
            SetFormState(Form1State.ListsView);
        }

        public void newItem_Click(object sender, EventArgs e)
        {
            
            ToolStripMenuItem clickedMenu = (ToolStripMenuItem)sender;

            //we already have the clicked champion ID in rightClickedPicture

            //Get chosen list and it's All counterpart's ID
            Guid listUID = Engine.GetListReference(clickedMenu.OwnerItem.Name, clickedMenu.Name);
            Guid listAllUID = Engine.GetListReference(clickedMenu.OwnerItem.Name, Constants.CUSTOM_LIST_ALL);

            //if List doesn't already contain the champion, add it to the list
            if (Engine.ChampionListCollection[listUID].ListOfChampions.ContainsKey(rightClickedPicture) == false)
            {
                Engine.ChampionListCollection[listUID].ListOfChampions.Add(rightClickedPicture, Engine.AllChampionsList.ListOfChampions[rightClickedPicture]);
            }
            if (Engine.ChampionListCollection[listAllUID].ListOfChampions.ContainsKey(rightClickedPicture) == false)
            {
                Engine.ChampionListCollection[listAllUID].ListOfChampions.Add(rightClickedPicture, Engine.AllChampionsList.ListOfChampions[rightClickedPicture]);
            }
            
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
            /*
            ChampionContainer clickedChampion = null;
            foreach (ChampionContainer champion in selectedCollection.ContainedChampions())
            {
                if (champion.PictureBox == rightClickedControl)
                {
                    clickedChampion = champion;
                }
            }*/
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
            /*
            allChampionsCollection.AddContextMenu(AllChampsContextMenu);
            allChampionsCollection.Hide();
            */
            SetFormState(Form1State.ListsView);

        }

        private void ButtonMatchupDetails_Click(object sender, EventArgs e)
        {
            displayChampionMatchupsList = true;
            groupBox1.Text = Engine.SelectedChampion.Name + " Matchups Info";
            ManagePositionsButton.Enabled = false;
            buttonManageLists.Enabled = false;
            buttonManageChamp.Enabled = false;
            //allChampionsCollection.AddContextMenu(null);
            //selectedCollection.Hide();
            //allChampionsCollection.Print(textSeaarchBox.Text);
            //allChampionsCollection.AddControlPanel(ref controlPanel); // TOTOTO


        }
        #endregion

        private void textSeaarchBox_TextChanged(object sender, EventArgs e)
        {
            //selectedCollection.Print(textSeaarchBox.Text);
            PrintList(visibleListID, textSeaarchBox.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Engine.SaveToFile("rekt.gg");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.controlPanel.Controls.Clear();
            //collectionList.Clear();
            Engine.LoadFromFile("rekt.gg");

            PictureListFill();
            initListCollection(); //Initializes the champion collection List

            PrintList(Engine.SelectedChampionList.UniqueID, textSeaarchBox.Text);
            //Warning: When Loading a List, you must reset all variables connected with that list
            //When Using the Add% functions on a list, Print of the currently selected list should be called so that posible data changes are updated
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

        private void button3_Click(object sender, EventArgs e)
        {
            Guid Result;

            Result = Engine.GetListReference("List1", Constants.CUSTOM_LIST_ALL);

            return;
        }

    }
}
