using Inventory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.View
{
    ///<summary>
    /// Product view contents
    ///</summary>
    internal class ProductView
    {
        public List<string> AddProduct = new()
        {
            "Name: ",
            "Quantity: ",
            "Price: "
        };
        public string RemoveProduct = "Product ID to be removed: ";
        public List<string> UpdateProduct = new()
        {
            "Product ID to be updated: ",
            "New quantity: "
        };
        public List<string> TableColumns = new() 
        { 
            nameof(Product.Id),
            nameof(Product.Name),
            nameof(Product.QuantityInStock),
            nameof(Product.Price)
        };
        public string TotalProductValue = "Total value of products: ";
    }
}
