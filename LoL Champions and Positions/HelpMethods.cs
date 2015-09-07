using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoL_Champions_and_Positions
{
 

    public class ChampionToFile : FileManager<ChampionCollection>
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
        public override List<ChampionCollection> ExportLines()
        {
            if (saveLines.Count<=0)
            {
                return null;
            }

            List<ChampionCollection> result= new List<ChampionCollection>();
            ChampionCollection AllChampionsCollection;
            result.Add(new ChampionCollection(Constants.ALL_CHAMPIONS,Enums.ListPositions.All.ToString()));
            AllChampionsCollection = result[0];

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

                    List<ChampionContainer> allChampions = AllChampionsCollection.ContainedChampions();
                    foreach (string champion in listOfChampions)
                    {
                        foreach (ChampionContainer existingChampion in allChampions)
                        {
                            if (existingChampion.Name == champion)
                            {
                                newListEntry.Add(new Champion(existingChampion.Name,existingChampion.Image,existingChampion.SearchTag,existingChampion.Description));
                                continue;
                            }
                        }
                    }
                    result.Add(newListEntry);

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
                    ChampionContainer matchupChampion = AllChampionsCollection.GetChampion(lineComponents[1]);
                    if (matchupChampion == null)
                    {
                        throw new Exception("Champion Missing: Can't add matchup");
                        //Technically if my program works correctly, i should never get here since all champions are Exported before the matchups
                    }
                    matchupChampion.AddMatchup(lineComponents[2], lineComponents[3]);

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

            foreach (ChampionContainer champion in AllChampionsCollection.ContainedChampions())
            {
                HelpMethods.UpdateChampionAcrossAllCollections(ref result, champion);
            }

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

        public static string getAppPath()
        {
            string result = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            result = result.Replace("file:\\", "");
            return result;
        }
        public static System.Drawing.Image getImageFromLocalDirectory(string filename)
        {
            string directoryPath = HelpMethods.getAppPath();
            string imageLocation = directoryPath + "\\images\\" + filename;
            System.Drawing.Image result;
            try
            {
             result = System.Drawing.Image.FromFile(imageLocation);
            }
            catch
            {
                result = Properties.Resources.ImageMissing;
            }

            return result;
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
