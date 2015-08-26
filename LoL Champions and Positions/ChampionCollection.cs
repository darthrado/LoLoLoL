using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoL_Champions_and_Positions
{
    public class ChampionCollection
    {
        public ChampionCollection(string name, string role, List<ChampionContainer> initList, System.Windows.Forms.ContextMenuStrip contextMenu, System.Windows.Forms.GroupBox groupBox,Form1 mainForm)
        {
            _name = name;
            _role = role;
            _listOfChampions = initList;
            _groupBox = groupBox;
            _contextMenu = contextMenu;
            _mainForm = mainForm;
        }
        public ChampionCollection(string name, string role, System.Windows.Forms.ContextMenuStrip contextMenu, System.Windows.Forms.GroupBox groupBox, Form1 mainForm)
        {
            _name = name;
            _role = role;
            _listOfChampions = new List<ChampionContainer>();
            _groupBox = groupBox;
            _contextMenu = contextMenu;
            _mainForm = mainForm;
        }
        public ChampionCollection(string name, string role)
        {
            _name = name;
            _role = role;
            _listOfChampions = new List<ChampionContainer>();
            _groupBox = null;
            _contextMenu = null;
            _mainForm = null;
        }

        private string _name;
        private string _role;
        private List<ChampionContainer> _listOfChampions;
        private System.Windows.Forms.GroupBox _groupBox;
        System.Windows.Forms.ContextMenuStrip _contextMenu;
        Form1 _mainForm;

        public void Add(Champion champion) 
        {
            ChampionContainer newChampion;
            if(_contextMenu==null && _groupBox==null && _mainForm==null)
            {
                newChampion = new ChampionContainer(champion);
            }
            else
            {
                if (_contextMenu == null || _groupBox == null||_mainForm==null)
                {
                    throw new Exception("ContextMenu or GroupBox Not Set!");
                }
                newChampion = new ChampionContainer(champion, _mainForm);
                _groupBox.Controls.Add(newChampion.PictureBox);
                newChampion.PictureBox.ContextMenuStrip = _contextMenu;
            }


            _listOfChampions.Add(newChampion);
        }
        public bool Remove(string championName) 
        {
            for(int i=0; i<_listOfChampions.Count; i++)
            {
                if (_listOfChampions[i].ChampionPr.Name == championName)
                {
                    _listOfChampions[i].Visible = false;
                    _listOfChampions.RemoveAt(i);
                    
                    return true;
                }
            }

            return false;
        }
        public void Print(string value) 
        {
            if (_groupBox == null)
            {
                throw new Exception("Attempting to Print without Groupbox Set");
            }

            int X = _groupBox.Location.X+Constants.CHAMPION_HORIZONTAL_OFFSET;
            int Y = _groupBox.Location.Y+Constants.CHAMPION_VERTICAL_OFFSET;
            int i=0;

            while (i < _listOfChampions.Count)
            {
                if (value == Constants.SEARCH_TEXT)
                {
                    value = "";
                }

                if (_listOfChampions[i].ChampionPr.Name.Contains(value) || _listOfChampions[i].ChampionPr.SearchTag.Contains(value)||value == "")
                {
                    _listOfChampions[i].SetLocation(X, Y);
                    _listOfChampions[i].Visible = true;
                }
                else
                {
                    _listOfChampions[i].SetLocation(0, 0);
                    _listOfChampions[i].Visible = false;
                }

                if (X + 2*(Constants.CHAMPION_HORIZONTAL_OFFSET + Constants.CHAMPION_FRAME_WIDTH) > _groupBox.Location.X + _groupBox.Width)
                {
                    X = _groupBox.Location.X + Constants.CHAMPION_HORIZONTAL_OFFSET;
                    Y += (Constants.CHAMPION_FRAME_HEIGHT + Constants.CHAMPION_VERTICAL_OFFSET);
                }
                else
                {
                    X += (Constants.CHAMPION_FRAME_WIDTH + Constants.CHAMPION_HORIZONTAL_OFFSET);
                }
                i++;
            }
        }
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
        public void AddGroupBox(System.Windows.Forms.GroupBox groupBox)
        {
            _groupBox = groupBox;
            foreach (ChampionContainer champion in _listOfChampions)
            {
                groupBox.Controls.Add(champion.PictureBox);
            }

        }

        public List<Champion> ContainedChampions() 
        { 
            List<Champion> result = new List<Champion>();

            foreach (ChampionContainer champion in _listOfChampions)
            {
                result.Add(champion.ChampionPr);
            }

            return result;
        }
        public void AddFormReference(Form1 mainForm)
        {
            _mainForm = mainForm;
            foreach (ChampionContainer champion in _listOfChampions)
            {
                champion.setMainForm(_mainForm);
            }
            
        }
        public string Name { get { return _name; } set { _name = value; } }
        public string Role { get { return _role; } }
    }
}
