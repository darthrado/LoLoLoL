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
            _uniqueID = Guid.NewGuid();
            _name = name;
            _image = image;
            _searchTag = searchTag;
            _description = description;
            matchupList = new List<Matchup>();
        }
        Guid _uniqueID;
        string _name;
        string _image;
        string _searchTag;
        string _description;

        List<Matchup> matchupList;

        private Matchup getMatchup(string championName)
        {
            foreach (Matchup matchup in matchupList)
            {
                if (championName == matchup.EnemyChampion)
                {
                    return matchup;
                }
            }
            return null;
        }
        public string getMatchupInfo(string championName)
        {
            Matchup resultMatchup = getMatchup(championName);

            if (resultMatchup != null)
            {
                return resultMatchup.MatchInformation;
            }

            return null;
        }
        public bool AddMatchup(string enemyChampion, string matchupInfo)
        {
            if (getMatchup(enemyChampion) != null)
            {
                return false;
            }

            matchupList.Add(new Matchup(enemyChampion,matchupInfo));
            return true;
        }
        public bool EditMatchup(string enemyChampion, string matchupInfo)
        {
            Matchup matchupForEdit = getMatchup(enemyChampion);

            if (matchupForEdit != null)
            {
                matchupForEdit.MatchInformation = matchupInfo;
                return true;
            }

            return false;
        }
        public bool DeleteMatchup(string enemyChampion)
        {
            Matchup forDelete = getMatchup(enemyChampion);

            if (forDelete != null)
            {
                matchupList.Remove(forDelete);
                return true;
            }

            return false;
        }
        public List<Matchup> GetAllMatchups()
        {
            return this.matchupList;
        }

        public string Name { get { return _name; } set { _name = value; } }
        public string Image { get { return _image; } set { _image = value; } }
        public string SearchTag { get { return _searchTag; } set { _searchTag = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public Guid UniqueID { get { return _uniqueID; } }
    }
}
