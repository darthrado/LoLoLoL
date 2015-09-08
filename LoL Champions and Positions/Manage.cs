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
    public partial class Manage : Form
    {
        public Manage(List<ChampionCollection> InputList, Enums.ManageDialogue launchMode)
        {
            InitializeComponent();

            _intputList = new List<ListEntry>();
            _launchMode = launchMode;
            _formResponseList = new List<ManageFormResponse>();
            FormResponse = new List<ManageFormResponse>();

            FillList(InputList, launchMode);
            SetListBox(SearchBar.Text);

            if (_launchMode == Enums.ManageDialogue.List)
            {
                Picture.Visible = false;
                PictureName.Visible = false;
                label3.Visible = false;
            }

            SetState(Enums.ManageFormState.None);
            
        }

        Enums.ManageDialogue _launchMode;
        Enums.ManageFormState _formState;
        Enums.ManageFormState _previousState;
        List<ListEntry> _intputList;

        /// <summary>
        /// List containing the response commands that should be processed by the caller of this form after it's closed
        /// </summary>
        List<ManageFormResponse> _formResponseList;
        public List<ManageFormResponse> FormResponse { get; private set; }

        /// <summary>
        /// "Local Values List" class contains the essential information needed for a list item to be created/edited
        /// </summary>
        private class ListEntry
        {
            public ListEntry(string name,bool warning)
            {
                Name = name;
            }
            public ListEntry(string name, string picture, bool warning)
            {
                Name = name;
                PictureName = picture;
                Warning = warning;
            }
            public bool Warning { get; private set; }
            public string Name { get; private set; }
            public string PictureName { get; private set; }
            public void EditEntry(string name,string picture)
            {
                Name = name;
                PictureName = picture;
            }
        }

        /// <summary>
        /// Fills the "Local Values List" with items based on the passed input list and form launch mode
        /// </summary>
        /// <param name="inputList">List(ChampionCollection) - Contains basically all List and Champion data in the app </param>
        /// <param name="launchMode">Launch mode depending on whether the form is called to insert champions or lists</param>
        void FillList(List<ChampionCollection> inputList, Enums.ManageDialogue launchMode)
        {
            if (launchMode == Enums.ManageDialogue.Champion)
            {

                foreach (ChampionCollection InputListEntry in inputList)
                {
                    if (InputListEntry.Name == Constants.ALL_CHAMPIONS && InputListEntry.Role == Enums.ListPositions.All.ToString())
                    {
                        List<ChampionContainer> tempChampList = InputListEntry.ContainedChampions();
                        foreach (ChampionContainer champion in tempChampList)
                        {
                            _intputList.Add(new ListEntry(champion.Name, champion.Image, true));
                        }
                    }
                }
            }
            else if (launchMode == Enums.ManageDialogue.List)
            {
                foreach (ChampionCollection InputListEntry in inputList)
                {
                    if (InputListEntry.Name != Constants.ALL_CHAMPIONS && InputListEntry.Role == Enums.ListPositions.All.ToString())
                    {
                        bool notEmptyWarning;
                        if(InputListEntry.ContainedChampions() != null)
                        {
                            notEmptyWarning = true;
                        }
                        else
                        {
                            notEmptyWarning = false;
                        }
                        _intputList.Add(new ListEntry(InputListEntry.Name,notEmptyWarning));
                    }
                }
            }
            else
            {
                //mandatory something happaned something happaned dialogue
            }
        }
        /// <summary>
        /// Returns an enty from the "Local Values List" that contains the name passed as a parameter
        /// </summary>
        /// <param name="name">Name of the item, that we are searching for</param>
        /// <returns>ListEntry item, if match, else null</returns>
        ListEntry GetListEntry(string name)
        {
            foreach (ListEntry item in _intputList)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }
        /// <summary>
        /// Sets the state of the form and enables/disables the appropriate fields
        /// </summary>
        /// <param name="newState">ManageFormState enum - this will be the new form state</param>
        void SetState(Enums.ManageFormState newState)
        {
            if (newState == Enums.ManageFormState.New || newState == Enums.ManageFormState.Edit)
            {
                ListBox.Enabled = false;

                AddNew.Enabled = false;
                EditItem.Enabled = false;
                DeleteItem.Enabled = false;
                Ok.Enabled = false;

                BackButton.Enabled = true;
                SaveButton.Enabled = true;

                ItemName.ReadOnly = false;
                PictureName.ReadOnly = false;


            }
            else if (newState == Enums.ManageFormState.Delete)
            {
                if (_formState != Enums.ManageFormState.ItemSelected)
                {
                    return;
                }
            }
            else if (newState == Enums.ManageFormState.None)
            {
                ListBox.Enabled = true;

                AddNew.Enabled = true;
                EditItem.Enabled = true;
                DeleteItem.Enabled = false;
                Ok.Enabled = true;

                BackButton.Enabled = false;
                SaveButton.Enabled = false;

                ItemName.Text = "";
                PictureName.Text = "";
                Picture.Image = Properties.Resources.DefaultImage;

                ItemName.ReadOnly = true;
                PictureName.ReadOnly = true;

                ListBox.ClearSelected();
            }
            else if (newState == Enums.ManageFormState.ItemSelected)
            {
                DeleteItem.Enabled = true;
            }
            else
            {
                // mandatory something happaned something happaned
            }
            _previousState = _formState;
            _formState = newState;
        }
        /// <summary>
        /// Fills in the form list box with items from "Local Values List" that match the search phrase
        /// </summary>
        /// <param name="searchPhrase">search phrase - duh</param>
        void SetListBox(string searchPhrase)
        {
            ListBox.Items.Clear();
            foreach (ListEntry item in _intputList)
            {
                if (item.Name.ToUpper().Contains(searchPhrase.ToUpper()) || searchPhrase == "" || searchPhrase == Constants.SEARCH_TEXT)
                {
                    ListBox.Items.Add(item.Name);
                }
            }
        }


        private void AddNew_Click(object sender, EventArgs e)
        {
            SetState(Enums.ManageFormState.New);

            ItemName.Text = "";
            PictureName.Text = "";
            Picture.Image = Properties.Resources.DefaultImage;

            ListBox.ClearSelected();
            //Listbox disabled for select
       
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            bool warningDialogResult = false;

            SetState(Enums.ManageFormState.Delete);

            ListEntry itemToDelete = GetListEntry(ItemName.Text);

            if (itemToDelete == null)
            {
                throw new Exception("Attempting to delete nonexistent item");
            }

            if (itemToDelete.Warning != false)
            {
                string warningMessage = "";
                if (_launchMode == Enums.ManageDialogue.Champion)
                {
                    warningMessage = "If you delete this champion, it will be deleted across all lists along with any Hints on him. Continue?";
                }
                else if (_launchMode == Enums.ManageDialogue.List)
                {
                    warningMessage = "List is not empty! Continue anyway?";
                }

                DialogResult dialogResult = MessageBox.Show(warningMessage, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    warningDialogResult = true;
                }
            }

            if (warningDialogResult== true || itemToDelete.Warning == false) //if warning message ok
            {
                _formResponseList.Add(new ManageFormResponse(_formState, ItemName.Text, PictureName.Text));
                _intputList.Remove(itemToDelete);
                SetListBox("");
            }
            else
            {
                SetState(_previousState);
            }
        }

        private void EditItem_Click(object sender, EventArgs e)
        {
            SetState(Enums.ManageFormState.Edit);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {

            int index = ListBox.SelectedIndex;
            if (index != -1)
            {
                SetState(_previousState);
                ListEntry selectedItem = GetListEntry(ListBox.Items[index].ToString());

                if (selectedItem != null)
                {
                    ItemName.Text = selectedItem.Name;
                    PictureName.Text = selectedItem.PictureName;
                    Picture.Image = HelpMethods.getImageFromLocalDirectory(selectedItem.PictureName,false);
                }
            }
            else
            {
                SetState(Enums.ManageFormState.None);
            }


        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            if (_formState == Enums.ManageFormState.New)
            {
                if (GetListEntry(ItemName.Text) == null && (!Constants.IsReservedWord(ItemName.Text)))
                {
                    _formResponseList.Add(new ManageFormResponse(_formState, ItemName.Text, PictureName.Text));
                    _intputList.Add(new ListEntry(ItemName.Text,PictureName.Text,false));
                }
                else
                {
                    string errorMessage;
                    if (Constants.IsReservedWord(ItemName.Text))
                    {
                        errorMessage = "Don't use reserves words, onegaishimasu!";
                    }
                    else
                    {
                        errorMessage="Item name already exists";
                    }

                    MessageBox.Show(errorMessage);
                    return;
                }
            }
            else if (_formState == Enums.ManageFormState.Edit)
            {
                string oldItem = ListBox.Items[ListBox.SelectedIndex].ToString();
                if ((GetListEntry(ItemName.Text) != null && ItemName.Text != oldItem) || Constants.IsReservedWord(ItemName.Text))
                {
                    string errorMessage;
                    if (Constants.IsReservedWord(ItemName.Text))
                    {
                        errorMessage="Don't use reserves words, onegaishimasu!";
                    }
                    else
                    {
                        errorMessage="Can't change item name to an existing one";
                    }

                    MessageBox.Show(errorMessage);
                    return;
                }
                else
                {
                    _formResponseList.Add(new ManageFormResponse(_formState, oldItem, PictureName.Text, ItemName.Text));
                    GetListEntry(oldItem).EditEntry(ItemName.Text,PictureName.Text);
                    
                }
            }
            SetListBox(SearchBar.Text);
            SetState(Enums.ManageFormState.None);
        }

        private void ReloadImage_Click(object sender, EventArgs e)
        {
            Picture.Image = HelpMethods.getImageFromLocalDirectory(PictureName.Text,false);
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            FormResponse = _formResponseList;
            this.Close();

        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = ListBox.SelectedIndex;
            if (index != -1)
            {
                ListEntry selectedItem = GetListEntry(ListBox.Items[index].ToString());

                if (selectedItem != null)
                {
                    ItemName.Text = selectedItem.Name;
                    PictureName.Text = selectedItem.PictureName;
                    Picture.Image = HelpMethods.getImageFromLocalDirectory(selectedItem.PictureName,false);
                }
                SetState(Enums.ManageFormState.ItemSelected);
            }
        }

        private void SearchBar_TextChanged(object sender, EventArgs e)
        {
            SetListBox(SearchBar.Text);
        }
    }
}
