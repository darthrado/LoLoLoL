using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoL_Champions_and_Positions
{
    public class Engine
    {
        private static Dictionary<Guid, ChampionCollection> championListCollection = new Dictionary<Guid, ChampionCollection>();
        private static HashSet<string> listPositions = new HashSet<string>();
        private static ChampionCollection allChampionsList;
        private static Champion selectedChampion;
        private static ChampionCollection selectedChampionList;

        public static void fillListCollection(Dictionary<Guid,ChampionCollection> sourceCollection)
        {
            if (championListCollection.Count != 0)
            {
                championListCollection.Clear();
            }
            if (listPositions.Count != 0)
            {
                listPositions.Clear();
            }
            allChampionsList = null;
            selectedChampion = null;
            selectedChampionList = null;

            championListCollection = sourceCollection;
            Guid allChampsUID = GetListReference(Constants.ALL_CHAMPIONS, Constants.CUSTOM_LIST_ALL);
            allChampionsList = championListCollection[allChampsUID];
            selectedChampionList = allChampionsList;

            
        }

        //List manipulation Methods
        public static void AddList(string name)
        {
            foreach (string position in listPositions)
            {
                if (GetListReference(name, position) == Guid.Empty)
                {
                    ChampionCollection newList = new ChampionCollection(name, position);
                    championListCollection.Add(newList.UniqueID, newList);
                }
            }
        }
        public static void RenameList(List<Guid> uniqueIDs, string newName)
        {
            foreach (Guid unid in uniqueIDs)
            {
                championListCollection[unid].Name = newName;
            }
        }

        public static void RemoveList(List<Guid> uniqueIDs)
        {
            foreach (Guid unid in uniqueIDs)
            {
                championListCollection.Remove(unid);
            }
        }
        public static Guid GetListReference(string name, string position)
        {
            foreach (Guid key in championListCollection.Keys)
            {
                if (championListCollection[key].Name == name && championListCollection[key].Role == position)
                {
                    return key;
                }
            }
            return Guid.Empty;
        }
        public static List<Guid> GetAllListsWithName(string name)
        {
            List<Guid> result = new List<Guid>();
            foreach (Guid key in championListCollection.Keys)
            {
                if (championListCollection[key].Name == name)
                {
                    result.Add(key);
                }
            }

            return result;

        }
        public static List<Guid> GetAllListsWithPosition(string position)
        {
            List<Guid> result = new List<Guid>();
            foreach (Guid key in championListCollection.Keys)
            {
                if (championListCollection[key].Role == position)
                {
                    result.Add(key);
                }
            }

            return result;
        }

        //Position manipulation Methods
        public static void AddPosition(string roleName)
        {
            if (listPositions.Contains(roleName))
            {
                throw new Exception("List Already Exists");
            }

            List<string> listOfNames = new List<string>();
            foreach(Guid key in championListCollection.Keys)
            {
                if(championListCollection[key].Name!=Constants.ALL_CHAMPIONS && !listOfNames.Contains(championListCollection[key].Name))
                {
                    listOfNames.Add(championListCollection[key].Name);
                }
            }
            foreach(string name in listOfNames)
            {
                ChampionCollection newCollection = new ChampionCollection(name,roleName);
            }

            listPositions.Add(roleName);
        }
        public static void RemovePosition(string name)
        {
            if (listPositions.Contains(name))
            {
                listPositions.Remove(name);
                List<Guid> listsForDelte = GetAllListsWithPosition(name);
                if (listsForDelte.Count > 0)
                {
                    RemoveList(listsForDelte);
                }
                return;
            }

            throw new Exception("List Doesn't Exist");
        }
        public static void EditPosition(string Oldname,string newName)
        {
            if (listPositions.Contains(Oldname))
            {
                listPositions.Remove(Oldname);
                listPositions.Add(newName);

                List<Guid> listsForRename = GetAllListsWithPosition(Oldname);
                foreach (Guid key in listsForRename)
                {
                    championListCollection[key].Role = newName;
                }

                return;
            }
        }

        //Champion manipulation Methods
        public static void CreateChampion(Champion newChampion)
        {
            allChampionsList.Add(newChampion);
        }
        public static void DeleteChampion(Guid uniqueID)
        {
            foreach (Guid key in championListCollection.Keys)
            {
                    championListCollection[key].Remove(uniqueID);
            }
        }
        /* possibly not needed
        public static void EditChampion(Champion newChampionValues)
        {
        }*/
        public static Guid GetChampionReference(string name)
        {
            return allChampionsList.GetChampionID(name);
        }
        public static Champion GetChampion(Guid uniqueID)
        {
            if (allChampionsList.ListOfChampions.ContainsKey(uniqueID)==false)
            {
                throw new Exception("Champion with key doesn't exist");
            }
            return allChampionsList.ListOfChampions[uniqueID];
        }
        public static void AddChampionToList(Guid listUniqueID, Guid championUniqueID)
        {
            if (listUniqueID == null || championUniqueID == null)
            {
                throw new Exception("Missing ID");
            }
            if (championListCollection.ContainsKey(listUniqueID) == false)
            {
                throw new Exception("Incorrect List ID");
            }
            if (championListCollection[listUniqueID].Name == Constants.ALL_CHAMPIONS)
            {
                throw new Exception("This Function shouldnt be called for the All Champions List");
            }
            if(allChampionsList.ListOfChampions.ContainsKey(championUniqueID))
            {
                throw new Exception("Incorrect Champion ID");
            }
            championListCollection[listUniqueID].Add(allChampionsList.ListOfChampions[championUniqueID]);

        }
        public static void RemoveChampionFromList(Guid listUniqueID, Guid championUniqueID)
        {
            if (listUniqueID == null || championUniqueID == null)
            {
                throw new Exception("Missing ID");
            }
            if (championListCollection.ContainsKey(listUniqueID) == false)
            {
                throw new Exception("Incorrect List ID");
            }
            if(allChampionsList.ListOfChampions.ContainsKey(championUniqueID))
            {
                throw new Exception("Incorrect Champion ID");
            }
            // if list is All 

        }

        //Property Manipulation Methods
        public static void SetSelectedList(Guid listID)
        {
            selectedChampionList = championListCollection[listID];
        }
        public static void SetSelectedChampion(Guid championID)
        {
            if (championID != null)
            {
                selectedChampion = allChampionsList.ListOfChampions[championID];
            }
            else
            {
                selectedChampion = null;
            }
        }

        public static ChampionCollection AllChampionsList { get { return allChampionsList; } }
        public static ChampionCollection SelectedChampionList { get { return selectedChampionList; } }
        public static Dictionary<Guid, ChampionCollection> ChampionListCollection { get { return championListCollection; } }
        public static HashSet<string> ListPositions { get { return listPositions; } }
        public static Champion SelectedChampion { get { return selectedChampion; } }

    }
}
