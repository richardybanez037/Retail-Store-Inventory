using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.View
{
    ///<summary>
    /// Layout view with its header, header instructions, and prompts
    ///</summary>
    internal class LayoutView
    {
        public List<string> Header = new()
        {
            "==============================================",
            "||          Retail Store Inventory          ||",
            "=============================================="
        };
        public class HeaderInstructions
        {
            public readonly string ARROW_NAVIGATION = "-> Press Up and Down arrow keys to navigate";
            public readonly string ENTER_SELECT = "-> Press Enter to select";
            public readonly string ENTER_BACK = "-> Press Enter to go back";
            public readonly string AFTER_ADD_ATTEMPT;
            public readonly string AFTER_UPDATE_ATTEMPT;
            public HeaderInstructions()
            {
                AFTER_ADD_ATTEMPT = ENTER_BACK + " after add attempt";
                AFTER_UPDATE_ATTEMPT = ENTER_BACK + " after udpate attempt";
            }
        }
        public class Prompts
        {
            private readonly static string TRY_AGAIN = "try again";
            public readonly string EMPTY_NAME_INPUT = "*Empty name input, " + TRY_AGAIN;
            public readonly string INVALID_QUANTITY_INPUT = "*Invalid quantity input, " + TRY_AGAIN;
            public readonly string INVALID_NEW_QUANTITY_INPUT = "*Invalid new quantity input, " + TRY_AGAIN;
            public readonly string INVALID_PRICE_INPUT = "*Invalid price input, " + TRY_AGAIN;
            public readonly string INVALID_ID_INPUT = "*Invalid id input, " + TRY_AGAIN;
            public readonly string QUANTITY_NOT_LESS_THAN_1 = "*Quantity must not be less than 1, " + TRY_AGAIN;
            public readonly string PRICE_NOT_LESS_THAN_1 = "*Price must not be less than 1, " + TRY_AGAIN;
            public readonly string PRODUCT_ADDED = "\nProduct added!";
            public readonly string PRODUCT_REMOVED = "\nProduct removed successfully!";
            public readonly string PRODUCT_NOT_FOUND = "\nProduct not found, view the product id and " + TRY_AGAIN;
            public readonly string PRODUCT_UPDATED = "\nProduct updated successfully!";
            public readonly string NO_PRODUCTS = "\nNo products yet";
        }
    }
}
