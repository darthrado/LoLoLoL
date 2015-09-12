using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoL_Champions_and_Positions
{
    public class ChampionCollection
    {
        public ChampionCollection(string name, string role, System.Windows.Forms.ContextMenuStrip contextMenu, System.Windows.Forms.Panel controlPanel, Form1 mainForm)
        {
            _uniqueID = Guid.NewGuid();
            _name = name;
            _role = role;
            _listOfChampions = new Dictionary<Guid,Champion>();
        }
        public ChampionCollection(string name, string role)
        {
            _uniqueID = Guid.NewGuid();
            _name = name;
            _role = role;
            _listOfChampions = new Dictionary<Guid,Champion>();
        }

        private Guid _uniqueID;
        private string _name;
        private string _role;
        private Dictionary<Guid, Champion> _listOfChampions;

        public void Add(Champion champion) 
        {
            _listOfChampions.Add(champion.UniqueID, champion);
        }
        public void Remove(Guid championID) 
        {
            _listOfChampions.Remove(championID);
        }

        public Dictionary<Guid,Champion> ContainedChampions() 
        {
            return _listOfChampions;
        }
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

        public void Sort()
        {
            if (_listOfChampions == null)
            {
                return;
            }
            List<KeyValuePair<Guid, Champion>> tempList = new List<KeyValuePair<Guid, Champion>>(_listOfChampions);

            tempList.Sort(delegate(KeyValuePair<Guid, Champion> firstPair, KeyValuePair<Guid, Champion> secondPair)
            {
                return firstPair.Value.Name.CompareTo(secondPair.Value.Name);
            }
                 );
            _listOfChampions.Clear();
            foreach (KeyValuePair<Guid, Champion> pair in tempList)
            {
                _listOfChampions.Add(pair.Key, pair.Value);
            }
        }

        public Dictionary<Guid, Champion> ListOfChampions { get { return _listOfChampions; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Role { get { return _role; } set { _role = value; } }
        public Guid UniqueID { get { return _uniqueID; } }
    }
}
