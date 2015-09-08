using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoL_Champions_and_Positions
{
    class Constants
    {
        public const int GROUP_BOX_BORDER_OFFSET = 5;
        public const int CHAMPION_HORIZONTAL_OFFSET = 5;
        public const int CHAMPION_VERTICAL_OFFSET = 5;
        public const int CHAMPION_FRAME_WIDTH = 60;
        public const int CHAMPION_FRAME_HEIGHT = 60;
        public const string SEARCH_TEXT = "Search...";
        public const string ALL_CHAMPIONS = "All Champions";
        public const string CUSTOM_LIST_ALL = "All Positions";
        public const string SLASH_SEPARATOR = "///";
        public const string AT_SEPARATOR = "@@@";
        public static bool IsReservedWord(string word)
        {
            if (word == ALL_CHAMPIONS || word == SEARCH_TEXT ||word == CUSTOM_LIST_ALL)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
