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
        private static ChampionToFile saveData = new ChampionToFile();

        public static void BasicInitialize()
        {
            championListCollection = new Dictionary<Guid, ChampionCollection>(); 
            listPositions = new HashSet<string>();
            listPositions.Add(Constants.CUSTOM_LIST_ALL);
            allChampionsList = new ChampionCollection(Constants.ALL_CHAMPIONS, Constants.CUSTOM_LIST_ALL);
            selectedChampionList = allChampionsList;
            championListCollection.Add(allChampionsList.UniqueID, allChampionsList);

        }
        public static void ClearAllData()
        {
            championListCollection = null;
            listPositions = null;
            selectedChampion = null;
            selectedChampionList = null;
        }
        public static void LoadFromFile(string filename)
        {
            ClearAllData();
            BasicInitialize();
            saveData.getFromFile(filename);
            saveData.ExportLines();
        }

        public static void SaveToFile(string filename)
        {
            saveData.ImportLines(null);
            saveData.saveToFile(filename);
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

            List<string> listOfNames = new List<string>(); // Fill the names of lists that don't have this position
            foreach (Guid key in championListCollection.Keys)
            {
                //if List is not: ALL_CHAMPIONS, and LlistOfNames doesn't contain this name
                if (championListCollection[key].Name != Constants.ALL_CHAMPIONS && !listOfNames.Contains(championListCollection[key].Name))
                {
                    //Add the list to the list of names
                    listOfNames.Add(championListCollection[key].Name);
                }
            }
            foreach (string name in listOfNames)
            {
                ChampionCollection newCollection = new ChampionCollection(name, roleName);
                championListCollection.Add(newCollection.UniqueID, newCollection);
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
        public static void EditPosition(string Oldname, string newName)
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
            if (allChampionsList.ListOfChampions.ContainsKey(uniqueID) == false)
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
            if (allChampionsList.ListOfChampions.ContainsKey(championUniqueID))
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
            if (allChampionsList.ListOfChampions.ContainsKey(championUniqueID)==false)
            {
                throw new Exception("Incorrect Champion ID");
            }
            
            if (listUniqueID == allChampionsList.UniqueID)
            {
                throw new Exception("List id cannot be the All Champions List");
            }

            List<Guid> sameListsKeys = GetAllListsWithName(championListCollection[listUniqueID].Name);

            if (championListCollection[listUniqueID].Role == Constants.CUSTOM_LIST_ALL)
            {
                foreach(Guid key in   sameListsKeys)
                {
                    championListCollection[key].Remove(championUniqueID);
                }
            }
            else
            {
                Guid listAllID = Guid.Empty;
                int counter=0;
                foreach (Guid key in sameListsKeys)
                {
                    if (key == listUniqueID)
                    {
                        championListCollection[key].Remove(championUniqueID);
                        counter++;
                        continue;
                    }
                    if (championListCollection[key].Role == Constants.CUSTOM_LIST_ALL)
                    {
                        listAllID = key;
                        continue;
                    }
                    if (championListCollection[key].ListOfChampions.ContainsKey(championUniqueID))
                    {
                        counter++;
                    }
                }
                if (counter == 1)
                {
                    championListCollection[listAllID].ListOfChampions.Remove(championUniqueID);
                }
            }


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

        class ChampionToFile : FileManagerLibrary.FileManager<Dictionary<Guid, ChampionCollection>>  //FileManager<ChampionCollection>
        {
            public ChampionToFile()
            {
            }

            /// <summary>
            /// Parses the containes String Lines to an ChampionCollectionString
            /// </summary>
            /// <returns></returns>
            public override Dictionary<Guid, ChampionCollection> ExportLines()
            {
                if (saveLines.Count <= 0)
                {
                    return null;
                }

                while (saveLines.Count > 0)
                {
                    string parseLine = saveLines.Dequeue();
                    string[] separator = { Constants.SLASH_SEPARATOR };
                    string[] lineComponents = parseLine.Split(separator, StringSplitOptions.None);

                    // List parse format: List///Position///Champion@@@Champion@@@Champion...
                    if (lineComponents[0] == LineType.List.ToString())
                    {
                        Guid ListID = Engine.GetListReference(lineComponents[1], lineComponents[2]);
                        if (ListID == Guid.Empty)
                        {
                            Engine.AddList(lineComponents[1]);
                            ListID = Engine.GetListReference(lineComponents[1], lineComponents[2]);
                            if (ListID == Guid.Empty)
                            {
                                throw new Exception("This SHouldnt happen");
                            }
                        }

                        separator[0] = Constants.AT_SEPARATOR;
                        string[] listOfChampions = null;
                        listOfChampions = lineComponents[3].Split(separator, StringSplitOptions.None);

                        foreach (string champion in listOfChampions)
                        {
                            Guid uniqueID = Engine.AllChampionsList.GetChampionID(champion);
                            if (uniqueID != Guid.Empty)
                            {
                                Engine.AddChampionToList(ListID, uniqueID);
                            }
                        }

                    }
                    //Champion parse format: Champion///Name///Image///searchTags///Description
                    else if (lineComponents[0] == LineType.Champion.ToString())
                    {
                        Champion newChampion = new Champion(lineComponents[1], lineComponents[2], lineComponents[3], lineComponents[4]);
                        Engine.CreateChampion(newChampion);
                    }
                    //Matchup parse format: Champion///EnemyChampion///MatchupDetails
                    else if (lineComponents[0] == LineType.Matchup.ToString())
                    {
                        Guid matchupChampionID = Engine.AllChampionsList.GetChampionID(lineComponents[1]);
                        if (matchupChampionID == Guid.Empty)
                        {
                            throw new Exception("Champion Missing: Can't add matchup");
                            //Technically if my program works correctly, i should never get here since all champions are Exported before the matchups
                        }
                        Engine.AllChampionsList.ListOfChampions[matchupChampionID].AddMatchup(lineComponents[2], lineComponents[3]);

                    }
                    //Not Developed Yet - ToDo
                    else if (lineComponents[0] == LineType.Item.ToString())
                    {
                    }
                    else if (lineComponents[0] == LineType.Position.ToString())
                    {
                        for (int i = 1; i < lineComponents.Length; i++)
                        {
                            if (lineComponents[i] != Constants.CUSTOM_LIST_ALL)
                            {
                                Engine.AddPosition(lineComponents[i]);
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Parsing error: Unknown Line Type");
                    }

                    //distribute the references of the main collection to the other lists
                }

                return null;
            }
            /// <summary>
            /// Parses a Champion Collection List to a String[] format ready for filesave
            /// </summary>
            /// <param name="List"></param>
            /// <returns></returns>
            public override bool ImportLines(Dictionary<Guid, ChampionCollection> inputLine)
            {
                if (Engine.ChampionListCollection.Count == 0)
                {
                    throw new Exception("Can't save empty data");
                }

                string separator = Constants.SLASH_SEPARATOR;
                string initialParseLine = LineType.Position.ToString();
                foreach (string key in Engine.ListPositions)
                {
                    if (key != Constants.CUSTOM_LIST_ALL)
                    {
                        initialParseLine += separator + key;
                    }
                }
                this.saveLines.Enqueue(initialParseLine);
                // enqueue all champions
                foreach (Guid key in Engine.AllChampionsList.ListOfChampions.Keys)
                {
                    separator = Constants.SLASH_SEPARATOR;
                    Champion champToParse = Engine.AllChampionsList.ListOfChampions[key];
                    string lineToParse = LineType.Champion.ToString() + separator +
                         champToParse.Name + separator +
                         champToParse.Image + separator +
                          champToParse.SearchTag + separator +
                         champToParse.Description;
                    this.saveLines.Enqueue(lineToParse);

                }

                foreach (Guid key in Engine.ChampionListCollection.Keys)
                {
                    if (key == Engine.AllChampionsList.UniqueID)
                    {
                        continue;
                    }
                    separator = Constants.SLASH_SEPARATOR;

                    string lineToParse = LineType.List.ToString() + separator +
                                         Engine.ChampionListCollection[key].Name + separator +
                                         Engine.ChampionListCollection[key].Role + separator;
                    bool firstPass = true;
                    separator = Constants.AT_SEPARATOR;
                    foreach (Guid championKey in Engine.ChampionListCollection[key].ListOfChampions.Keys)
                    {
                        if (firstPass)
                        {
                            lineToParse += Engine.ChampionListCollection[key].ListOfChampions[championKey].Name;
                            firstPass = false;
                        }
                        else
                        {
                            lineToParse += separator + Engine.ChampionListCollection[key].ListOfChampions[championKey].Name;
                        }
                    }

                }

                // To Do: Items
                return true;
            }

            enum LineType
            {
                Champion,
                List,
                Item,
                Matchup,
                Position
            };

        }
    }
}
