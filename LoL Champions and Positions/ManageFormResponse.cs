using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoL_Champions_and_Positions
{
    public class ManageFormResponse
    {
        public ManageFormResponse(Enums.ManageFormState responseCommand, Guid uniqueID, string name, string picture)
        {
            UniqueID = uniqueID;
            Name = name;
            RespondCommand = responseCommand;
            Picture = picture;

        }
        public Enums.ManageFormState RespondCommand { get; private set; }
        public Guid UniqueID { get; private set; }
        public string Name { get; private set; }
        public string Picture { get; private set; }
        public string OldName { get; set; }
    }
}
