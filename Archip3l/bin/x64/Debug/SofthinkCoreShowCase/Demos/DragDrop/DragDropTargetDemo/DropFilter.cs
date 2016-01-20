using DemoCommon.Model;
using SofthinkCore.UI.DragDrop;
using SofthinkCoreShowCase.DemoCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofthinkCoreShowCase.Demos.DragDrop
{
    public class DropFilter : IDropFilter
    {
        [Flags]
        public enum AllowedData
        {
            A = 0x1,
            B = 0x2,
            C = 0x4,
        }

        public AllowedData AllowedDataList { get; set; }

        public bool CanDrop(DragDropArgs arg)
        {
            if (arg.Data is PostitViewModelA && ((AllowedDataList & AllowedData.A) != 0))
                return true;
            if (arg.Data is PostitViewModelB && ((AllowedDataList & AllowedData.B) != 0))
                return true;
            if (arg.Data is PostitViewModelC && ((AllowedDataList & AllowedData.C) != 0))
                return true; 

            return false;
        }

    }
}
