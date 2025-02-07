using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.View
{
    ///<summary>
    /// Menu contents
    ///</summary>
    internal class MenuView
    {
        public List<string> Menu = new List<string>
        {
            Constants.Indicator + "Add product",
            Constants.Unselected + "Remove product",
            Constants.Unselected + "Update product",
            Constants.Unselected + "View products",
            Constants.Unselected + "Get total value of products"
        };
    }
}
