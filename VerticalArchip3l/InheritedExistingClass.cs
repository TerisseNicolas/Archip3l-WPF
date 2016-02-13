using SofthinkCore.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerticalArchip3l
{
    class ActionTouchButton : TouchButton
    {
        public Action Action;
    }
    class IslandConrolsBuildingTouchButton : TouchButton
    {
        public BuildingType BuildingType;
    }
}
