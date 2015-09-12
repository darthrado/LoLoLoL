using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BanKaiEngine;

namespace LoL_Champions_and_Positions
{

    public class HelpMethods
    {
        private static Dictionary<string,System.Drawing.Image> imageDictionary = new Dictionary<string,System.Drawing.Image>();

        public static string getAppPath()
        {

            string result = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            result = result.Replace("file:\\", Constants.STRING_EMPTY);
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
    }




}
