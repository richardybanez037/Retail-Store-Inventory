using ConsoleTables;
using Inventory.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Model
{
    ///<summary>
    /// Manages the inventory actions:
    /// AddProduct: Add product to products list
    /// RemoveProduct: Remove product from the products list
    /// UpdateProduct: Update product from the products list
    /// ListProducts: List all products from the products list
    /// GetTotalValue: Get the total value from the products list
    ///</summary>
    internal class InventoryManager
    {
        readonly List<Product> Products = new();
        readonly ProductView productView = new();
        readonly LayoutView.Prompts prompts = new();
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        public bool RemoveProduct(int productId)
        {
            Product product = Products.Find(p => p.Id.Equals(productId));
            if (product != null) {
                Products.Remove(product);
                return true;
            };
            return false;
        }
        public bool UpdateProduct(int productId, int newQuantity)
        {
            Product product = Products.Find(p => p.Id.Equals(productId));
            if (product != null)
            {
                product.QuantityInStock = newQuantity;
                return true;
            }
            else return false;
        }
        public void ListProducts()
        {
            List<string> tableColumns = productView.TableColumns;
            var table = new ConsoleTable(tableColumns.ToArray());
            Products.ForEach(p => table.AddRow(p.Id, p.Name, p.QuantityInStock, p.Price));
            table.Write();
        }
        public double GetTotalValue()
        {
            return Products.Sum(p => p.QuantityInStock * p.Price);
        }
    }
}
