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
        public Manage(Enums.ManageDialogue launchMode)
        {
            InitializeComponent();

            _intputList = new List<ListEntry>();
            _launchMode = launchMode;
            _formResponseList = new List<ManageFormResponse>();

            //Initialize it separately from _formResponseList. That way it will still be initialized
            //And changes will only be remembered on OK button click
            FormResponse = new List<ManageFormResponse>();

            FillList(launchMode);
            SetListBox(SearchBar.Text);

            if (_launchMode == Enums.ManageDialogue.List || _launchMode == Enums.ManageDialogue.Position)
            {
                Picture.Visible = false;
                PictureName.Visible = false;
                ReloadImage.Visible = false;
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
            public ListEntry(Guid uniqueID, string name,bool warning)
            {
                UniqueID = uniqueID;
                Name = name;
            }
            public ListEntry(Guid uniqueID,string name, string picture, bool warning)
            {
                UniqueID = uniqueID;
                Name = name;
                PictureName = picture;
                Warning = warning;
            }
            public Guid UniqueID { get; private set; }
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
        void FillList(Enums.ManageDialogue launchMode)
        {
            if (launchMode == Enums.ManageDialogue.Champion)
            {
                foreach (Guid key in Engine.AllChampionsList.ListOfChampions.Keys)
                {
                    _intputList.Add(new ListEntry(key,Engine.AllChampionsList.ListOfChampions[key].Name, Engine.AllChampionsList.ListOfChampions[key].Image, true));
                }
            }
            else if (launchMode == Enums.ManageDialogue.List)
            {
                foreach (Guid key in Engine.GetAllListsWithPosition(Constants.CUSTOM_LIST_ALL))
                {
                    if (Engine.ChampionListCollection[key].Name == Constants.ALL_CHAMPIONS)
                    {
                        continue;
                    }

                    bool notEmptyWarning;
                    if (Engine.ChampionListCollection[key].ListOfChampions.Count > 0)
                    {
                        notEmptyWarning = true;
                    }
                    else
                    {
                        notEmptyWarning = false;
                    }
                    _intputList.Add(new ListEntry(key,Engine.ChampionListCollection[key].Name, notEmptyWarning));
                }
            }
            else if (launchMode == Enums.ManageDialogue.Position)
            {
                foreach (string position in Engine.ListPositions)
                {
                    if (position == Constants.CUSTOM_LIST_ALL)
                    {
                        continue;
                    }
                    _intputList.Add(new ListEntry(Guid.Empty, position, true));
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
                else if (_launchMode == Enums.ManageDialogue.Position)
                {
                    warningMessage = "All Lists will clear their entries for this position, along with any Champions that belong in it. Continue?";
                }

                DialogResult dialogResult = MessageBox.Show(warningMessage, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    warningDialogResult = true;
                }
            }

            if (warningDialogResult== true || itemToDelete.Warning == false) //if warning message ok
            {
                _formResponseList.Add(new ManageFormResponse(_formState, itemToDelete.UniqueID, itemToDelete.Name, itemToDelete.PictureName));
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
                    _formResponseList.Add(new ManageFormResponse(_formState,Guid.Empty, ItemName.Text, PictureName.Text));
                    _intputList.Add(new ListEntry(Guid.Empty,ItemName.Text,PictureName.Text,false));
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
                    ListEntry editedItem = GetListEntry(oldItem);
                    string oldItemName = editedItem.Name;
                    editedItem.EditEntry(ItemName.Text,PictureName.Text);

                    ManageFormResponse editItemFormResponse = new ManageFormResponse(_formState, editedItem.UniqueID, editedItem.Name, editedItem.PictureName);
                    editItemFormResponse.OldName = oldItemName;
                    _formResponseList.Add(editItemFormResponse);
                    
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
        private void ListBox_Click(object sender, EventArgs e)
        {
            int index = ListBox.SelectedIndex;
            if (index != -1)
            {
                ListEntry selectedItem = GetListEntry(ListBox.Items[index].ToString());

                if (selectedItem != null)
                {
                    ItemName.Text = selectedItem.Name;
                    PictureName.Text = selectedItem.PictureName;
                    Picture.Image = HelpMethods.getImageFromLocalDirectory(selectedItem.PictureName, false);
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
