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



}
