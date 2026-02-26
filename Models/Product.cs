using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace warehouse_coursera.Models
{
    internal class Product
    {
        
        private string name;
        private double price;
        private int quantity;
        public Product(string name, double price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public override string ToString()
        {
            return $"Product: {name}, Price: {price}, Quantity: {quantity}";
        }
    }
}
