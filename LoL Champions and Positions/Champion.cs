using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoL_Champions_and_Positions
{
    public class Champion
    {
        public Champion(string name, string image, string searchTag, string description)
        {
            _name = name;
            _image = image;
            _searchTag = searchTag;
            _description = description;
            matchupList = new Dictionary<string, Matchup>();
        }
        string _name;
        string _image;
        string _searchTag;
        string _description;

        Dictionary<string,Matchup> matchupList;

        private Matchup getMatchup(string championName)
        {
            if (matchupList.ContainsKey(championName))
            {
                return matchupList[championName];
            }
            else
            {
                return null;
            }
        }
        public string getMatchupInfo(string championName)
        {
            if(matchupList.ContainsKey(championName))
            {
                return matchupList[championName].MatchInformation;
            }
            else
            {
                return null;
            }
        }
        public bool AddMatchup(string enemyChampion, string matchupInfo)
        {
            if (matchupInfo.Contains(enemyChampion))
            {
                return false;
            }

            matchupList.Add(enemyChampion,new Matchup(enemyChampion,matchupInfo));
            return true;
        }
        public bool EditMatchup(string enemyChampion, string matchupInfo)
        {
            if (matchupList.ContainsKey(enemyChampion))
            {
                matchupList[enemyChampion].MatchInformation = matchupInfo;
                return true;
            }

            return false;
        }
        public bool DeleteMatchup(string enemyChampion)
        {
            if (matchupList.ContainsKey(enemyChampion))
            {
                matchupList.Remove(enemyChampion);
                return true;
            }

            return false;
        }
        public Dictionary<string, Matchup> MatchupList { get { return matchupList; } }

        public string Name { get { return _name; } set { _name = value; } }
        public string Image { get { return _image; } set { _image = value; } }
        public string SearchTag { get { return _searchTag; } set { _searchTag = value; } }
        public string Description { get { return _description; } set { _description = value; } }
    }
}
