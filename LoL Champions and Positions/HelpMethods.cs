using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoL_Champions_and_Positions
{

    public class HelpMethods
    {
        private static Dictionary<string,System.Drawing.Image> imageDictionary = new Dictionary<string,System.Drawing.Image>();

        public static string getAppPath()
        {

            string result = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            result = result.Replace("file:\\", "");
            return result;
        }

        private static bool ThumbnailCallback()
        {
            return false;
        }

        public static System.Drawing.Image getImageFromLocalDirectory(string filename,bool thumbnail)
        {
            System.Drawing.Image result;
            if (filename == null)
            {
                return null;
            }


            if (imageDictionary.ContainsKey(filename))
            {
                result = imageDictionary[filename];
            }
            else
            {

                string directoryPath = HelpMethods.getAppPath();
                string imageLocation = directoryPath + "\\images\\" + filename;

                try
                {
                    result = System.Drawing.Image.FromFile(imageLocation);
                    imageDictionary.Add(filename, result);
                }
                catch
                {
                    result = Properties.Resources.ImageMissing;
                }
            }

            if (thumbnail)
            {
                System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                return result.GetThumbnailImage(60, 60, myCallback, IntPtr.Zero);
            }
            else
            {
                return result;
            }

            
        }
        /*public static void UpdateChampionAcrossAllCollections(ref List<ChampionCollection> collectionList, ChampionContainer modifiedChampion)
        {
            foreach (ChampionCollection collection in collectionList)
            {
                collection.ReplaceExistingChampion(modifiedChampion);
            }
        }*/
        /*public static int ChampionContainerComparer(ChampionContainer value1, ChampionContainer value2)
        {
            return value1.Name.CompareTo(value2.Name);
        }*/
    }

    public class Matchup
    {
        public Matchup(string enemyChampion, string matchInformation)
        {
            _uniqueID = Guid.NewGuid();
            _enemyChampion = enemyChampion;
            _matchInformation = matchInformation;
        }
        Guid _uniqueID;
        string _enemyChampion;
        string _matchInformation;
        public string EnemyChampion { get { return _enemyChampion; } set { _enemyChampion = value; } }
        public string MatchInformation { get { return _matchInformation; } set { _matchInformation = value; } }
        Guid UniqueID { get { return _uniqueID; } }

    }

    public class ChampionToFile : FileManagerLibrary.FileManager<Dictionary<Guid, ChampionCollection>>  //FileManager<ChampionCollection>
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


            Dictionary<Guid, ChampionCollection> result = new Dictionary<Guid, ChampionCollection>();
            ChampionCollection AllChampionsCollection = new ChampionCollection(Constants.ALL_CHAMPIONS, Constants.CUSTOM_LIST_ALL);
            result.Add(AllChampionsCollection.UniqueID, AllChampionsCollection);

            while (saveLines.Count > 0)
            {
                string parseLine = saveLines.Dequeue();
                string[] separator = { Constants.SLASH_SEPARATOR };
                string[] lineComponents = parseLine.Split(separator, StringSplitOptions.None);

                // List parse format: List///Position///Champion@@@Champion@@@Champion...
                if (lineComponents[0] == LineType.List.ToString())
                {
                    ChampionCollection newListEntry = new ChampionCollection(lineComponents[1], lineComponents[2]);
                    separator[0] = Constants.AT_SEPARATOR;
                    string[] listOfChampions = null;
                    listOfChampions = lineComponents[3].Split(separator, StringSplitOptions.None);

                    foreach (string champion in listOfChampions)
                    {
                        Guid uniqueID = AllChampionsCollection.GetChampionID(champion);
                        if (uniqueID != Guid.Empty)
                        {
                            newListEntry.Add(AllChampionsCollection.ListOfChampions[uniqueID]);
                        }
                    }
                    result.Add(newListEntry.UniqueID, newListEntry);

                }
                //Champion parse format: Champion///Name///Image///searchTags///Description
                else if (lineComponents[0] == LineType.Champion.ToString())
                {
                    Champion newChampion = new Champion(lineComponents[1], lineComponents[2], lineComponents[3], lineComponents[4]);
                    AllChampionsCollection.Add(newChampion);
                }
                //Matchup parse format: Champion///EnemyChampion///MatchupDetails
                else if (lineComponents[0] == LineType.Matchup.ToString())
                {
                    Guid matchupChampionID = AllChampionsCollection.GetChampionID(lineComponents[1]);
                    if (matchupChampionID == Guid.Empty)
                    {
                        throw new Exception("Champion Missing: Can't add matchup");
                        //Technically if my program works correctly, i should never get here since all champions are Exported before the matchups
                    }
                    AllChampionsCollection.ListOfChampions[matchupChampionID].AddMatchup(lineComponents[2], lineComponents[3]);

                }
                //Not Developed Yet - ToDo
                else if (lineComponents[0] == LineType.Item.ToString())
                {
                }
                else if (lineComponents[0] == LineType.Position.ToString())
                {
                    for (int i = 1; i < lineComponents.Length - 1; i++)
                    {
                        Engine.AddPosition(lineComponents[i]);
                    }
                }
                else
                {
                    throw new Exception("Parsing error: Unknown Line Type");
                }

                //distribute the references of the main collection to the other lists
            }

            return result;
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
                initialParseLine += separator + key;
            }
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
