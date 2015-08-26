using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoL_Champions_and_Positions
{
    public class Champion
    {
        public Champion(string name, string image, string searchTag, string tooltip)
        {
            _name = name;
            _image = image;
            _searchTag = searchTag;
            _tooltip = tooltip;
        }
        string _name;
        string _image;
        string _searchTag;
        string _tooltip;

        public string Name { get { return _name; } set { _name = value; } }
        public string Image { get { return _image; } set { _image = value; } }
        public string SearchTag { get { return _searchTag; } set { _searchTag = value; } }
        public string Tooltip { get { return _tooltip; } set { _tooltip = value; } }
    }
}
