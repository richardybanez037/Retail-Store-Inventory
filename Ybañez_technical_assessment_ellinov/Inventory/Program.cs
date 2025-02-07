using Inventory;
using Inventory.Model;
using Inventory.View;

/// project: Retail Store Inventory
/// author: John Richard A. Ybañez
/// created: February 7, 2025

int selected = 0;
int id = 0;
Pages currentPage = Pages.Menu;

LayoutView layoutViewInstance = new();
LayoutView.HeaderInstructions headerInstructions = new();
LayoutView.Prompts prompts = new();
List<string> headerView = layoutViewInstance.Header;

MenuView menuViewInstance = new();
List<string> menuView = menuViewInstance.Menu;
int menuLength = menuView.Count;

ProductView productViewInstance = new();
List<string> addProductView = productViewInstance.AddProduct;
string removeProductView = productViewInstance.RemoveProduct;
List<string> updateProductView = productViewInstance.UpdateProduct;
string totalProductView = productViewInstance.TotalProductValue;

InventoryManager inventoryManager = new();

///<summary>
/// Displays the header instructions per view
/// </summary>
void DisplayHeaderInstructions()
{
    switch (currentPage)
    {
        case Pages.Menu:
            Console.WriteLine(headerInstructions.ARROW_NAVIGATION);
            Console.WriteLine(headerInstructions.ENTER_SELECT);
            break;
        case Pages.Total_products_value:
        case Pages.View_products:
        case Pages.Remove_product:
            Console.WriteLine(headerInstructions.ENTER_BACK + "\n");
            break;
        case Pages.Add_product:
            Console.WriteLine(headerInstructions.AFTER_ADD_ATTEMPT + "\n");
            break;
        case Pages.Update_product:
            Console.WriteLine(headerInstructions.AFTER_UPDATE_ATTEMPT + "\n");
            break;
        default: Console.WriteLine("\n");
            break;
    }
    Console.WriteLine("\n========== " + currentPage + " ==========");
}
///<summary>
/// Handles the addition of a product to the products list
/// </summary>
void AddProductHandler()
{
    string newName = string.Empty;

    while (string.IsNullOrEmpty(newName))
    {
        Console.Write(addProductView[0]);
        string nameInput = Console.ReadLine();
        if (string.IsNullOrEmpty(nameInput.Trim()))
            Console.WriteLine(prompts.EMPTY_NAME_INPUT);
        else newName = nameInput;
    }

    int parsedNewQuantity = int.MinValue;
    while (parsedNewQuantity == int.MinValue)
    {
        Console.Write(addProductView[1]);
        string quantityInput = Console.ReadLine();
        if (!int.TryParse(quantityInput, out parsedNewQuantity))
        {
            Console.WriteLine(prompts.INVALID_QUANTITY_INPUT);
            parsedNewQuantity = int.MinValue;
        }
        else if (parsedNewQuantity <= 0)
        {
            Console.WriteLine(prompts.QUANTITY_NOT_LESS_THAN_1);
            parsedNewQuantity = int.MinValue;
        }
    }

    double parsedPrice = double.MinValue;
    while (parsedPrice == double.MinValue)
    {
        Console.Write(addProductView[2]);
        string priceInput = Console.ReadLine();
        if (!double.TryParse(priceInput, out parsedPrice))
        { 
            Console.WriteLine(prompts.INVALID_PRICE_INPUT);
            parsedPrice = int.MinValue;
        }
        else if (parsedPrice <= 0)
        {
            Console.WriteLine(prompts.PRICE_NOT_LESS_THAN_1);
            parsedPrice = double.MinValue;
        }
    }

    Product product = new()
    {
        Id = id++,
        Name = newName,
        QuantityInStock = parsedNewQuantity,
        Price = parsedPrice
    };
    inventoryManager.AddProduct(product);

    Console.WriteLine(prompts.PRODUCT_ADDED);
}
///<summary>
/// Handles the removal of a product from the products list
/// </summary>
void RemoveProductHandler()
{
    int productId = -1;
    while (productId < 0)
    {
        Console.Write(removeProductView);
        string productIdInput = Console.ReadLine();
        if (!int.TryParse(productIdInput, out productId))
        {
            Console.WriteLine(prompts.INVALID_ID_INPUT);
            productId = -1;
        }
        else
        {
            bool isRemoved = inventoryManager.RemoveProduct(productId);
            if (isRemoved) Console.WriteLine(prompts.PRODUCT_REMOVED);
            else Console.WriteLine(prompts.PRODUCT_NOT_FOUND);
        }
    }
}
///<summary>
/// Handles the update of a product from the products list
/// </summary>
void UpdateProductHandler()
{
    int updateProductId = -1;
    while (updateProductId < 0)
    {
        Console.Write(updateProductView[0]);
        string productIdInput = Console.ReadLine();
        if (!int.TryParse(productIdInput, out updateProductId))
        {
            Console.WriteLine(prompts.INVALID_ID_INPUT);
            updateProductId = -1;
        }
    }

    int updateParsedNewQuantity = -1;
    while (updateParsedNewQuantity == -1)
    {
        Console.Write(updateProductView[1]);
        string quantityInput = Console.ReadLine();
        if (!int.TryParse(quantityInput, out updateParsedNewQuantity))
            Console.WriteLine(prompts.INVALID_NEW_QUANTITY_INPUT);
    }

    bool isProductUpdated = inventoryManager.UpdateProduct(updateProductId, updateParsedNewQuantity);
    if (isProductUpdated)
    {
        Console.WriteLine(prompts.PRODUCT_UPDATED);
    }
    else Console.WriteLine(prompts.PRODUCT_NOT_FOUND);
}
///<summary>
/// Displays the page from selected menu selection
/// </summary>
void DisplayPage()
{
    switch (currentPage)
    {
        case Pages.Menu:
            menuView.ForEach(m => Console.WriteLine(m));
            break;
        case Pages.Add_product:
            AddProductHandler();
            break;
        case Pages.Remove_product:
            RemoveProductHandler();
            break;
        case Pages.Update_product:
            UpdateProductHandler();
            break;
        case Pages.View_products:
            inventoryManager.ListProducts();
            break;
        case Pages.Total_products_value:
            Console.WriteLine(totalProductView + inventoryManager.GetTotalValue());
            break;
    }
}
///<summary>
/// Displays headers, headers instructions, and page views
/// </summary>
void display()
{
    headerView.ForEach(h => Console.WriteLine(h));
    DisplayHeaderInstructions();
    DisplayPage();
}
///<summary>
/// Handles the page navigation of the user using up and down arrow keys, and enter key
/// </summary>
void navigate()
{
    int prevSelected = selected;
    var key = Console.ReadKey(true).Key;

    switch (key)
    {
        case ConsoleKey.UpArrow:
            if(currentPage == Pages.Menu)
            {
                selected--;
                if (selected < 0) selected = menuLength - 1;
            }
            break;
        case ConsoleKey.DownArrow:
            if (currentPage == Pages.Menu)
            {
                selected++;
                if (selected == menuLength) selected = 0;
            }
            break;
        case ConsoleKey.Enter:
            switch (currentPage)
            {
                case Pages.Menu:
                    currentPage = (Pages)selected + 1;
                    break;
                default:
                    currentPage = Pages.Menu;
                    break;
            }
            break;
    }

    menuView[prevSelected] = menuView[prevSelected].Replace(Constants.Indicator, Constants.Unselected);
    menuView[selected] = menuView[selected].Replace(Constants.Unselected, Constants.Indicator);

    Console.Clear();
}
///<summary>
/// System loop
/// </summary>
while (true)
{
    display();
    navigate();
}