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
            saveFile = new ChampionToFile();
            saveFile.getFromFile("rekt.gg");
            this.controlPanel.Controls.Clear();
            Engine.fillListCollection(saveFile.ExportLines());

            initListCollection(); //Initializes the champion collection List

            //selectedCollection.Print(textSeaarchBox.Text);

        }
        #endregion

        #region ClassVariables
        //List<ChampionCollection> collectionList;
        //ChampionCollection selectedCollection;
        //ChampionCollection allChampionsCollection;
        //ChampionContainer selectedChampion;
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
            updateListCollectionDropdown();
            BuildContextMenu();
            SetFormState(Form1State.InitialView);

            //selectedCollection.Print("");
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
                        saveFile.ImportLines(Engine.ChampionListCollection);
                        saveFile.saveToFile("rekt.gg");
                    }
                }
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

                    //TODO once matchup collection is implemented: matchupCollection hide
                    //selectedCollection.Print(textSeaarchBox.Text);
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

                groupBox1.Text = Constants.ALL_CHAMPIONS + "/" + Constants.CUSTOM_LIST_ALL;
                championListCollection.SelectedIndex = 0;
                playablePositions.SelectedIndex = 0;

            }
        }

        #endregion

        #region EventHandlers

        private void Form1_Resize(object sender, EventArgs e)
        {
            /*
            if (selectedCollection != null)
            {
                System.Drawing.Point gbLocation = groupBox1.Location;

                int initialSize = (controlPanel.Width - Constants.CHAMPION_HORIZONTAL_OFFSET) / (Constants.CHAMPION_FRAME_WIDTH + Constants.CHAMPION_HORIZONTAL_OFFSET);

                groupBox1.Height = this.ClientSize.Height - gbLocation.Y - Constants.GROUP_BOX_BORDER_OFFSET;
                groupBox1.Width = this.ClientSize.Width - gbLocation.X - Constants.GROUP_BOX_BORDER_OFFSET;
                controlPanel.Height = groupBox1.Height ;
                controlPanel.Width = groupBox1.Width - Constants.GROUP_BOX_BORDER_OFFSET;

                int afterSize = (controlPanel.Width - Constants.CHAMPION_HORIZONTAL_OFFSET) / (Constants.CHAMPION_FRAME_WIDTH + Constants.CHAMPION_HORIZONTAL_OFFSET);

                if (initialSize != afterSize)
                {
                    selectedCollection.Print(textSeaarchBox.Text);
                }
            }*/
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
                    }
                    else if (response.RespondCommand == Enums.ManageFormState.Edit)
                    {
                        Champion forEdit = Engine.AllChampionsList.ListOfChampions[response.UniqueID];

                        forEdit.Name = response.Name;
                        forEdit.Image = response.Picture;
                    }
                    else if (response.RespondCommand == Enums.ManageFormState.Delete)
                    {
                        Engine.DeleteChampion(response.UniqueID);
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
            //selectedCollection.Print(textSeaarchBox.Text);

            //Save changes to file
            saveFile.ImportLines(Engine.ChampionListCollection);
            saveFile.saveToFile("rekt.gg");

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
            updateListCollectionDropdown();
            BuildContextMenu();

            //Save changes to file
            saveFile.ImportLines(Engine.ChampionListCollection);
            saveFile.saveToFile("rekt.gg");
        }

        private void ListCollection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Guid selectionUID = getSelectedList();

            if (selectionUID != Guid.Empty)
            {

                //selectedCollection.Hide();

                Engine.SetSelectedList(selectionUID);

                //selectedCollection.Print(textSeaarchBox.Text);

                //TO DO PRINT
            }
            SetFormState(Form1State.ListsView);
        }

        private void Positions_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Engine.SelectedChampionList != null)
            {
                // TO DO PRINT
                /* wow such a bad code
                ChampionCollection newCollection = getSelectedList();

                if (newCollection != null)
                {

                    selectedCollection.Hide();

                    selectedCollection = newCollection;

                    selectedCollection.Print(textSeaarchBox.Text);
                }*/
            }
            SetFormState(Form1State.ListsView);
        }

        public void newItem_Click(object sender, EventArgs e)
        {
            /*
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
            */
            //Save changes to file
            saveFile.ImportLines(Engine.ChampionListCollection);
            saveFile.saveToFile("rekt.gg");
             
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            rightClickedControl = AllChampsContextMenu.SourceControl;
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
            Guid forRemoveID = Guid.Empty; // TO DO get rightclicked champion picture UID

            Engine.RemoveChampionFromList(Engine.SelectedChampionList.UniqueID, forRemoveID);

            //Save changes to file
            saveFile.ImportLines(Engine.ChampionListCollection);
            saveFile.saveToFile("rekt.gg");

        }

        private void CustomListsStrip_Opened(object sender, EventArgs e)
        {
            rightClickedControl = CustomListsStrip.SourceControl;
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
            //allChampionsCollection.AddContextMenu(null);
            //selectedCollection.Hide();
            //allChampionsCollection.Print(textSeaarchBox.Text);
            //allChampionsCollection.AddControlPanel(ref controlPanel); // TOTOTO


        }
        #endregion

        private void textSeaarchBox_TextChanged(object sender, EventArgs e)
        {
            //selectedCollection.Print(textSeaarchBox.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFile.ImportLines(Engine.ChampionListCollection);
            saveFile.saveToFile("rekt.gg");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFile.getFromFile("rekt.gg");
            this.controlPanel.Controls.Clear();
            //collectionList.Clear();
            Engine.fillListCollection(saveFile.ExportLines());

            initListCollection();
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
                    saveFile.ImportLines(Engine.ChampionListCollection);
                    saveFile.saveToFile("rekt.gg");
                }
            }
        }


    }
}
