using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using warehouse_coursera.Models;
namespace warehouse_coursera.Services
{
    internal class Inventory
    {
        private List<Product> warehouse = new List<Product> ();

        public void AddProduct(Product product)
        {
            warehouse.Add(product);
        }
        public void RemoveProduct(Product product)
        {
            warehouse.Remove(product);
        }
        public void UpdateProduct(Product oldProduct, Product newProduct)
        {
            int index = warehouse.IndexOf(oldProduct);
            if (index != -1)
            {
                warehouse[index] = newProduct;
            }
        }
        public void DisplayInventory()
        {
            Console.WriteLine("Current Inventory:");
            if (warehouse.Count == 0) Console.WriteLine("empty");
            foreach (var product in warehouse)
            {
                Console.WriteLine(product);
            }
        }
        public List<Product> GetWarehouse()
        {
            return warehouse;
        }
        public void UpdateWarehouse()
        {
            DisplayInventory();
        }
    }
}
