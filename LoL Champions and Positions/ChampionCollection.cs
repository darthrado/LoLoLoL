using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoL_Champions_and_Positions
{
    public class ChampionCollection
    {
/*        public ChampionCollection(string name, string role, List<ChampionContainer> initList, System.Windows.Forms.ContextMenuStrip contextMenu, System.Windows.Forms.Panel controlPanel,Form1 mainForm)
        {
            _uniqueID = Guid.NewGuid();
            _name = name;
            _role = role;
            _listOfChampions = initList;
            _controlPanel = controlPanel;
            _contextMenu = contextMenu;
            _mainForm = mainForm;
        }*/
        public ChampionCollection(string name, string role, System.Windows.Forms.ContextMenuStrip contextMenu, System.Windows.Forms.Panel controlPanel, Form1 mainForm)
        {
            _uniqueID = Guid.NewGuid();
            _name = name;
            _role = role;
            _listOfChampions = new Dictionary<Guid,Champion>();
            /*_controlPanel = controlPanel;
            _contextMenu = contextMenu;
            _mainForm = mainForm;*/
        }
        public ChampionCollection(string name, string role)
        {
            _uniqueID = Guid.NewGuid();
            _name = name;
            _role = role;
            _listOfChampions = new Dictionary<Guid,Champion>();
            /*
            _controlPanel = null;
            _contextMenu = null;
            _mainForm = null;*/
        }

        private Guid _uniqueID;
        private string _name;
        private string _role;
        //private List<ChampionContainer> _listOfChampions;
        private Dictionary<Guid, Champion> _listOfChampions;
        /*
        private System.Windows.Forms.Panel _controlPanel;
        System.Windows.Forms.ContextMenuStrip _contextMenu;
        Form1 _mainForm;*/

        public void Add(Champion champion) 
        {
            _listOfChampions.Add(champion.UniqueID, champion);
        }
        public void Remove(Guid championID) 
        {
            _listOfChampions.Remove(championID);
        }
        /*
        public void ReplaceExistingChampion(ChampionContainer modChampion)
        {
            for (int i = 0; i<_listOfChampions.Count; i++)
            {
                if (_listOfChampions[i].Name == modChampion.Name)
                {
                    _listOfChampions[i] = modChampion;
                }
            }
        }*/

        public void Sort()
        {
            if (_listOfChampions == null)
            {
                return;
            }
            /*
            System.Comparison<Champion> newComparison = new Comparison<Champion>(HelpMethods.ChampionContainerComparer);
            this._listOfChampions.Sort(newComparison);*/
        }
        /*
        public void Print(string value) 
        {
            if (_controlPanel == null)
            {
                return;
                throw new Exception("Attempting to Print without Groupbox Set");
            }

            int X = _controlPanel.DisplayRectangle.Left + Constants.CHAMPION_HORIZONTAL_OFFSET;
            int Y = _controlPanel.DisplayRectangle.Top + Constants.CHAMPION_VERTICAL_OFFSET;
            int i=0;

            if (value == Constants.SEARCH_TEXT)
            {
                value = "";
            }

            while (i < _listOfChampions.Count)
            {
            
                // If Name or Search tag contains Search Value or Search Value is Empty
                if (_listOfChampions[i].Name.ToUpper().Contains(value.ToUpper()) || _listOfChampions[i].SearchTag.ToUpper() == value.ToUpper()||value == "")
                {
                    //Set Location + make visible
                    _listOfChampions[i].SetLocation(X, Y);
                    _listOfChampions[i].Visible = true;
                }
                else
                {
                    //Clear Location + make invisible
                    _listOfChampions[i].Visible = false;
                    _listOfChampions[i].SetLocation(0, 0);
                    i++;
                    continue;
                }

                if (X + 2 * (Constants.CHAMPION_HORIZONTAL_OFFSET + Constants.CHAMPION_FRAME_WIDTH) > _controlPanel.DisplayRectangle.Left + _controlPanel.Width)
                {
                    X = _controlPanel.DisplayRectangle.Left + Constants.CHAMPION_HORIZONTAL_OFFSET;
                    Y += (Constants.CHAMPION_FRAME_HEIGHT + Constants.CHAMPION_VERTICAL_OFFSET);
                }
                else
                {
                    X += (Constants.CHAMPION_FRAME_WIDTH + Constants.CHAMPION_HORIZONTAL_OFFSET);
                }
                i++;
            }
        }*/
        /*
        public void Hide() 
        {
            foreach (ChampionContainer champion in _listOfChampions)
            {
                champion.Visible = false;
            }
        }
        public void AddContextMenu(System.Windows.Forms.ContextMenuStrip contextMenu)
        {
            _contextMenu = contextMenu;
            foreach (ChampionContainer champion in _listOfChampions)
            {
                champion.PictureBox.ContextMenuStrip = contextMenu;
            }
        }
        public void AddControlPanel(ref System.Windows.Forms.Panel controlPanel)
        {
            _controlPanel = controlPanel;
            foreach (ChampionContainer champion in _listOfChampions)
            {
                controlPanel.Controls.Add(champion.PictureBox);
            }

        }*/

        public Dictionary<Guid,Champion> ContainedChampions() 
        {
            return _listOfChampions;
        }
        /*
        public void AddFormReference(Form1 mainForm)
        {
            _mainForm = mainForm;
            foreach (ChampionContainer champion in _listOfChampions)
            {
                champion.setMainForm(_mainForm);
            }
            
        }*/
        // change?
        public Guid GetChampionID(string championName)
        {
            foreach (Guid key in _listOfChampions.Keys)
            {
                if (_listOfChampions[key].Name == championName)
                {
                    return key;
                }
            }

            return Guid.Empty;
        }

        public Dictionary<Guid, Champion> ListOfChampions { get { return _listOfChampions; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Role { get { return _role; } set { _role = value; } }
        public Guid UniqueID { get { return _uniqueID; } }
    }
}
