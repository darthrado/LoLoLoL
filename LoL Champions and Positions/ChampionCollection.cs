﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoL_Champions_and_Positions
{
    public class ChampionCollection
    {
        public ChampionCollection(string name, string role, List<ChampionContainer> initList, System.Windows.Forms.ContextMenuStrip contextMenu, System.Windows.Forms.Panel controlPanel,Form1 mainForm)
        {
            _name = name;
            _role = role;
            _listOfChampions = initList;
            _controlPanel = controlPanel;
            _contextMenu = contextMenu;
            _mainForm = mainForm;
        }
        public ChampionCollection(string name, string role, System.Windows.Forms.ContextMenuStrip contextMenu, System.Windows.Forms.Panel controlPanel, Form1 mainForm)
        {
            _name = name;
            _role = role;
            _listOfChampions = new List<ChampionContainer>();
            _controlPanel = controlPanel;
            _contextMenu = contextMenu;
            _mainForm = mainForm;
        }
        public ChampionCollection(string name, string role)
        {
            _name = name;
            _role = role;
            _listOfChampions = new List<ChampionContainer>();
            _controlPanel = null;
            _contextMenu = null;
            _mainForm = null;
        }

        private string _name;
        private string _role;
        private List<ChampionContainer> _listOfChampions;
        private System.Windows.Forms.Panel _controlPanel;
        System.Windows.Forms.ContextMenuStrip _contextMenu;
        Form1 _mainForm;

        public void Add(Champion champion) 
        {
            ChampionContainer newChampion;
            if(_mainForm==null)
            {
                newChampion = new ChampionContainer(champion);
            }
            else
            {

                newChampion = new ChampionContainer(champion, _mainForm);
            }

            if(_controlPanel!=null)
            {
                _controlPanel.Controls.Add(newChampion.PictureBox);
            }
            if(_contextMenu!=null)
            {
                newChampion.PictureBox.ContextMenuStrip = _contextMenu;
            }


            _listOfChampions.Add(newChampion);
        }
        public bool Remove(string championName) 
        {
            for(int i=0; i<_listOfChampions.Count; i++)
            {
                if (_listOfChampions[i].Name == championName)
                {
                    _listOfChampions[i].Visible = false;
                    _listOfChampions.RemoveAt(i);
                    
                    return true;
                }
            }

            return false;
        }
        public void ReplaceExistingChampion(ChampionContainer modChampion)
        {
            for (int i = 0; i<_listOfChampions.Count; i++)
            {
                if (_listOfChampions[i].Name == modChampion.Name)
                {
                    _listOfChampions[i] = modChampion;
                }
            }
        }

        public void Sort()
        {
            if (_listOfChampions == null)
            {
                return;
            }

            System.Comparison<ChampionContainer> newComparison = new Comparison<ChampionContainer>(HelpMethods.ChampionContainerComparer);
            this._listOfChampions.Sort(newComparison);
        }

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
                if (_listOfChampions[i].Name.Contains(value) || _listOfChampions[i].SearchTag.Contains(value)||value == "")
                {
                    //Set Location + make visible
                    _listOfChampions[i].SetLocation(X, Y);
                    _listOfChampions[i].Visible = true;
                }
                else
                {
                    //Clear Location + make invisible
                    _listOfChampions[i].SetLocation(0, 0);
                    _listOfChampions[i].Visible = false;
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
        public void AddControlPanel(ref System.Windows.Forms.Panel controlPanel)
        {
            _controlPanel = controlPanel;
            foreach (ChampionContainer champion in _listOfChampions)
            {
                controlPanel.Controls.Add(champion.PictureBox);
            }

        }

        public List<ChampionContainer> ContainedChampions() 
        { 
            List<ChampionContainer> result = new List<ChampionContainer>();

            foreach (ChampionContainer champion in _listOfChampions)
            {
                result.Add(champion);
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
        public ChampionContainer GetChampion(string championName)
        {
            foreach (ChampionContainer containedChampion in _listOfChampions)
            {
                if (containedChampion.Name == championName)
                {
                    return containedChampion;
                }
            }

            return null;
        }

        public string Name { get { return _name; } set { _name = value; } }
        public string Role { get { return _role; } }
    }
}
