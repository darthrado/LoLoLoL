using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoL_Champions_and_Positions
{
    public class ManageFormResponse
    {
        public ManageFormResponse(Enums.ManageFormState responseCommand, string name, string picture)
        {
            if (responseCommand == Enums.ManageFormState.Edit)
            {
                throw new Exception("Don't call Edit response without a name change");
            }
            Name = name;
            RespondCommand = responseCommand;
            Picture = picture;
            NewName = name;

        }
        public ManageFormResponse(Enums.ManageFormState responseCommand, string name, string picture, string newName)
        {
            Name = name;
            NewName = newName;
            Picture = picture;
            RespondCommand = responseCommand;
        }
        public Enums.ManageFormState RespondCommand { get; private set; }
        public string Name { get; private set; }
        public string Picture { get; private set; }
        public string NewName { get; private set; }
    }
}
