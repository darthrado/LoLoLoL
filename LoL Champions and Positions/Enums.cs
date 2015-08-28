using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoL_Champions_and_Positions
{
    public class Enums
    {
        public enum ManageDialogue
        {
            Champion,
            List
        };

        public enum ManageFormState
        {
            None,
            Edit,
            New,
            ItemSelected,
            Delete
        };
        public enum ListPositions
        {
            All,
            Top,
            Jungle,
            Mid,
            ADC,
            Support
        };
    }
}
