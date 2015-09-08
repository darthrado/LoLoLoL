using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoL_Champions_and_Positions
{


    public class ChampionToFile : FileManagerLibrary.FileManager<ChampionCollection>  //FileManager<ChampionCollection>
    {
        public ChampionToFile(){}
        public ChampionToFile(List<ChampionCollection> Champions)
        {
            ImportLines(Champions);
        }

        /// <summary>
        /// Parses the containes String Lines to an ChampionCollectionString
        /// </summary>
        /// <returns></returns>
        public override Dictionary<Guid,ChampionCollection> ExportLines()
        {
            if (saveLines.Count<=0)
            {
                return null;
            }

            Dictionary<Guid, ChampionCollection> result = new Dictionary<Guid, ChampionCollection>();
            ChampionCollection AllChampionsCollection = new ChampionCollection(Constants.ALL_CHAMPIONS,Enums.ListPositions.All.ToString());
            result.Add(AllChampionsCollection.UniqueID, AllChampionsCollection);

            while (saveLines.Count > 0)
            {
                string parseLine = saveLines.Dequeue();
                string[] separator = {Constants.SLASH_SEPARATOR};
                string[] lineComponents = parseLine.Split(separator, StringSplitOptions.None);

                // List parse format: List///Position///Champion@@@Champion@@@Champion...
                if(lineComponents[0] == LineType.List.ToString())
                {
                    ChampionCollection newListEntry = new ChampionCollection(lineComponents[1], lineComponents[2]);
                    separator[0] = Constants.AT_SEPARATOR;
                    string[] listOfChampions = null;
                    listOfChampions = lineComponents[3].Split(separator, StringSplitOptions.None);

                    foreach (string champion in listOfChampions)
                    {
                        Guid uniqueID = AllChampionsCollection.GetChampionID(champion);
                        newListEntry.Add(AllChampionsCollection.ListOfChampions[uniqueID]);
                    }
                    result.Add(newListEntry.UniqueID,newListEntry);

                }
                //Champion parse format: Champion///Name///Image///searchTags///Description
                else if (lineComponents[0] == LineType.Champion.ToString())
                {
                    Champion newChampion = new Champion(lineComponents[1], lineComponents[2], lineComponents[3], lineComponents[4]);
                    AllChampionsCollection.Add(newChampion);
                }
                //Matchup parse format: Champion///EnemyChampion///MatchupDetails
                else if(lineComponents[0] == LineType.Matchup.ToString())
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
                else
                {
                    throw new Exception("Parsing error: Unknown Line Type");
                }

                //distribute the references of the main collection to the other lists
            }
            /*
            foreach (ChampionContainer champion in AllChampionsCollection.ContainedChampions())
            {
                HelpMethods.UpdateChampionAcrossAllCollections(ref result, champion);
            }*/

            return result;
        }
        /// <summary>
        /// Parses a Champion Collection List to a String[] format ready for filesave
        /// </summary>
        /// <param name="List"></param>
        /// <returns></returns>
        public override bool ImportLines(List<ChampionCollection> List)
        {
            // First enqueue all champions
            foreach (ChampionCollection allChampions in List)
            {
                if (allChampions.Name == Constants.ALL_CHAMPIONS)
                {
                    string separator = Constants.SLASH_SEPARATOR;
                    foreach (ChampionContainer champion in allChampions.ContainedChampions())
                    {
                        string lineToParse = LineType.Champion.ToString() + separator + 
                                             champion.Name + separator + 
                                             champion.Image + separator +
                                              champion.SearchTag + separator + 
                                             champion.Description;
                        this.saveLines.Enqueue(lineToParse);
                    }
                    break;
                }
            }

            foreach (ChampionCollection list in List)
            {
                string separator = Constants.SLASH_SEPARATOR;
                if (list.Name != Constants.ALL_CHAMPIONS)
                {
                    string lineToParse = LineType.List.ToString() + separator +
                                         list.Name + separator +
                                         list.Role + separator;
                    bool firstPass = true;
                    separator = Constants.AT_SEPARATOR;
                    foreach (ChampionContainer containedChamp in list.ContainedChampions())
                    {
                        if (firstPass)
                        {
                            lineToParse += containedChamp.Name;
                            firstPass = false;
                        }
                        else
                        {
                            lineToParse += separator + containedChamp.Name;
                        }
                        
                    }
                    this.saveLines.Enqueue(lineToParse);
                }
            }
            foreach (ChampionCollection allChampions in List)
            {
                string separator = Constants.SLASH_SEPARATOR;

                if (allChampions.Name == Constants.ALL_CHAMPIONS)
                {
                    foreach (ChampionContainer champion in allChampions.ContainedChampions())
                    {

                        foreach (Matchup matchup in champion.GetAllMatchups())
                        {
                            string lineToParse = LineType.Matchup.ToString() + separator +
                                                 champion.Name + separator +
                                                 matchup.EnemyChampion + separator +
                                                 matchup.MatchInformation;
                            this.saveLines.Enqueue(lineToParse);
                        }
                    }
                    break;
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
            Matchup
        };

    }

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

            if (imageDictionary.ContainsKey(filename))
            {
                return imageDictionary[filename];
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
        public static void UpdateChampionAcrossAllCollections(ref List<ChampionCollection> collectionList, ChampionContainer modifiedChampion)
        {
            foreach (ChampionCollection collection in collectionList)
            {
                collection.ReplaceExistingChampion(modifiedChampion);
            }
        }
        public static int ChampionContainerComparer(ChampionContainer value1, ChampionContainer value2)
        {
            return value1.Name.CompareTo(value2.Name);
        }
    }

    public class Matchup
    {
        public Matchup()
        {
        }
        public Matchup(string enemyChampion, string matchInformation)
        {
            _enemyChampion = enemyChampion;
            _matchInformation = matchInformation;
        }
        string _enemyChampion;
        string _matchInformation;
        public string EnemyChampion { get { return _enemyChampion; } set { _enemyChampion = value; } }
        public string MatchInformation { get { return _matchInformation; } set { _matchInformation = value; } }

    }

}
