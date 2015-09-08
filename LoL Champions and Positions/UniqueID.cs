using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
namespace LoL_Champions_and_Positions
{
    public class UniqueID
    {
        private enum enumerableCharacters
        {
            A1 = '1',A2 = '2',A3 = '3',A4='4',A5='5',A6='6',A7='7','8','9','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
        };

        private static HashSet<string> inUse = new HashSet<string>();
        private static HashSet<char> characters = new HashSet<char>();
        private static string currentID = "aaaaaaaaaa";
        public static string getNewID()
        {
            string result = currentID;
            inUse.Add(currentID);
            SwitchCharacter(currentID.Length-1);

            return result;
        }
        private static void Increment()
        {

            int len = currentID.Length;
            for (int i = len - 1; i >= 0; i--)
            {
                while (inUse.Contains(currentID))
                {
                    SwitchCharacter(currentID[i]);
                    
                }
            }
        }
        private static void SwitchCharacter(int pos)
        {
            //currentID
            enumerableCharacters enumertator = enumerableCharacters.A1;
            enumertator
        }
    }
}*/
