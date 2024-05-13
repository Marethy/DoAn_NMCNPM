using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanVang.Model
{
    /// <summary>
    ///  identify user intention when opening new View - form
    ///  
    /// </summary>
    public enum ActionType
    {
        ACTION_CREATE_NEW = 1, // user wants to save new item for their purpose
        ACTION_VIEW = 2,  // user wants to see the detail of an item
        ACTION_UPDATE = 3
    }
}
