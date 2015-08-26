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
        public Form1()
        {
            InitializeComponent();
            collectionList = new List<ChampionCollection>();
            selectedCollection = new ChampionCollection(Constants.ALL_CHAMPIONS, ListPositions.All.ToString(),contextMenuStrip1,groupBox1,this);
            collectionList.Add(selectedCollection);

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
            selectedCollection.Print(textSeaarchBox.Text);

            selectedChampion = null;
            selectedCollection.AddContextMenu(contextMenuStrip1);
            selectedCollection.AddGroupBox(groupBox1);
            selectedCollection.AddFormReference(this);

            updateListCollectionDropdown();
            championListCollection.SelectedIndex = 0;
            playablePositions.SelectedIndex = 0;

        }

        private void updateListCollectionDropdown()
        {
            championListCollection.Items.Clear();
            foreach (ChampionCollection champList in collectionList)
            {
                if (champList.Role == ListPositions.All.ToString())
                {
                    championListCollection.Items.Add(champList.Name);
                }
            }
        }
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

        private void Form1_Resize(object sender, EventArgs e)
        {
            System.Drawing.Point gbLocation = groupBox1.Location;

            int initialSize = (groupBox1.Width - Constants.CHAMPION_HORIZONTAL_OFFSET) / (Constants.CHAMPION_FRAME_WIDTH + Constants.CHAMPION_HORIZONTAL_OFFSET);

            groupBox1.Height = this.ClientSize.Height - gbLocation.Y-Constants.GROUP_BOX_BORDER_OFFSET;
            groupBox1.Width = this.ClientSize.Width - gbLocation.X-Constants.GROUP_BOX_BORDER_OFFSET;

            int afterSize = (groupBox1.Width - Constants.CHAMPION_HORIZONTAL_OFFSET) / (Constants.CHAMPION_FRAME_WIDTH + Constants.CHAMPION_HORIZONTAL_OFFSET);

            if (initialSize != afterSize)
            {
                selectedCollection.Print(textSeaarchBox.Text);
            }
            
        }
        List<ChampionCollection> collectionList;
        ChampionCollection selectedCollection;
        ChampionContainer selectedChampion;
        Control rightClickedControl;
        

        private void manageChamp_Click(object sender, EventArgs e)
        {
            Manage manageChamp = new Manage(collectionList, ManageDialogue.Champion);

            manageChamp.ShowDialog();

            if (manageChamp.FormResponse.Count > 0)
            {
                foreach (ManageFormResponse response in manageChamp.FormResponse)
                {
                    if (response.RespondCommand == ManageFormState.New)
                    {
                        foreach (ChampionCollection collectionItem in collectionList)
                        {
                            if (collectionItem.Name == Constants.ALL_CHAMPIONS)
                            {
                                collectionItem.Add(new Champion(response.Name,response.Picture,"",""));

                                break;
                            }
                        }
                    }
                    else if (response.RespondCommand == ManageFormState.Edit)
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
                    else if (response.RespondCommand == ManageFormState.Delete)
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
            selectedCollection.Print(textSeaarchBox.Text);

        }

        private void manageLists_Click(object sender, EventArgs e)
        {
            Manage manageList = new Manage(collectionList, ManageDialogue.List);

            manageList.ShowDialog();

            if (manageList.FormResponse.Count>0)
            {
                foreach (ManageFormResponse response in manageList.FormResponse)
                {
                    if (response.RespondCommand == ManageFormState.New)
                    {
                        foreach (ListPositions position in Enum.GetValues(typeof(ListPositions)))
                        {
                            collectionList.Add(new ChampionCollection(response.Name, position.ToString(), ContextMenuStrip, groupBox1,this));
                        }
                    }
                    else if (response.RespondCommand == ManageFormState.Edit)
                    {
                        foreach (ChampionCollection collectionItem in collectionList)
                        {
                            if (response.Name == collectionItem.Name)
                            {
                                collectionItem.Name = response.NewName;
                            }
                        }
                    }
                    else if (response.RespondCommand == ManageFormState.Delete)
                    { 
                        for (int i=collectionList.Count-1; i>=0; i--)
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
            updateListCollectionDropdown();
            BuildContextMenu();
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
        }
        public void SetSelectedChampion(ChampionContainer selChamp)
        {
            selectedChampion = selChamp;
            if (selChamp != null)
            {
                pictureSelectedChamp.Image = HelpMethods.getImageFromLocalDirectory(selChamp.Image);
                selectedChampTextBox.Text = selChamp.Name;
            }
            else
            {
                pictureSelectedChamp.Image = Properties.Resources.DefaultImage;
                selectedChampTextBox.Text = "";
            }

        }
        private void BuildContextMenu()
        {
            toolStripMenuItem3.DropDownItems.Clear();
            List<System.Windows.Forms.ToolStripMenuItem> ToolStriListMenu= new List<ToolStripMenuItem>();
            foreach (ChampionCollection list in collectionList)
            {
                if (list.Name == Constants.ALL_CHAMPIONS || list.Role == ListPositions.All.ToString())
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

        public void newItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedMenu = (ToolStripMenuItem)sender;

            ChampionContainer clickedChampion = null;
            foreach (ChampionContainer champion in selectedCollection.ContainedChampions())
            {
                if(champion.PictureBox == rightClickedControl)
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
                if (List.Name == clickedMenu.OwnerItem.Name  && (List.Role == clickedMenu.Name || List.Role == ListPositions.All.ToString()) )
                {
                    //To Do filter double champions

                    List.Add(new Champion(clickedChampion.Name,clickedChampion.Image,clickedChampion.SearchTag,clickedChampion.Tooltip));
                }
            }

            //MessageBox.Show(clickedMenu.OwnerItem.Name + " " + clickedMenu.Name + " " + holyshitName); //here we get the 
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
             rightClickedControl = contextMenuStrip1.SourceControl;
        }
    }
}
