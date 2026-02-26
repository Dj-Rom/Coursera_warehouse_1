using System;
using System.Diagnostics.Metrics;
using warehouse_coursera.Models;
using warehouse_coursera.Services;

internal class Program
{
    static void Main(string[] args)
    {
        Inventory warehouse = new Inventory();

        while (true)
        {
            ShowMenu();
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Add product selected.");
                    Program.AddProduct(warehouse);
                    break;

                case "2":
                    Console.Clear();
                    Program.UpdateProduct(warehouse);
                    break;

                case "3":
                    Console.Clear();
                    Program.DeleteProduct(warehouse);
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("View products selected.");
                    Program.ViewProducts(warehouse);
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("Exiting program...");
                    return; // exits program

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    private static void ShowMenu()
    {
        Console.WriteLine("\nWelcome to the warehouse!");
        Console.WriteLine("1 = Add product");
        Console.WriteLine("2 = Update product");
        Console.WriteLine("3 = Remove product");
        Console.WriteLine("4 = View products");
        Console.WriteLine("5 = Exit program");
    }

    private static void AddProduct(Inventory warehouse)
    {
        string name;
        double price = 0;
        int quantity = 0;

        Console.WriteLine("Write product name or q = Exit");
        name = Console.ReadLine() ?? string.Empty;
        if (name == "q") return;
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.Clear();
            Console.WriteLine("Name cannot be empty. Write product name:");
            name = Console.ReadLine() ?? string.Empty;
        }

        bool isValid = false;

        while (!isValid)
        {
            Console.Clear();
            Console.Write("Enter product price: ");
            string input = Console.ReadLine();
            isValid = double.TryParse(input, out price);
            isValid = isValid && price >= 0; 
            if (!isValid)
            {
                Console.Clear();
                Console.WriteLine("Invalid input! Please enter a valid number.");
            }
        }

        isValid = false;
        while (!isValid)
        {
            Console.Write("Enter product quantity: ");
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out quantity);
            isValid = isValid && quantity >= 0; 


            if (!isValid)
            {
                Console.Clear();
                Console.WriteLine("Invalid input! Please enter a valid integer.");
            }
        }

        Product product = new Product(name, price, quantity);
        warehouse.AddProduct(product);
        Console.WriteLine($"Added: {product}");
    }
    private static void ViewProducts(Inventory warehouse)
    {
        {
            warehouse.DisplayInventory();
        }
    }
    private static void UpdateProduct(Inventory warehouse)
    {
      
        Program.ViewProducts(warehouse);
        Console.WriteLine("Enter the name of the product to update or q = Exit:");
        string name = Console.ReadLine() ?? string.Empty;
        if (name == "q") return;
        Product? oldProduct = warehouse.GetWarehouse().Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (oldProduct == null)
        {
            Console.Clear();
            Console.WriteLine("Product not found.");
            return;
        }
        string new_name = "";
        double new_price = 0;
        int new_quantity = 0;
        Console.Clear();
        Console.WriteLine("Select what you want update in this product: Name: " + oldProduct.Name + " Price: " + oldProduct.Price + " Quantity: " + oldProduct.Quantity + "\n 1 = Name, 2 = Price, 3 = Quantity, 4 = back to menu" );
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                Console.WriteLine("Current Name: " + oldProduct.Name + " Write product name");
                new_name = Console.ReadLine() ?? string.Empty;
                while (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty. Write product name:");
                   new_name = Console.ReadLine() ?? string.Empty;
                }

             
                warehouse.UpdateProduct(oldProduct, new Product(new_name, oldProduct.Price, oldProduct.Quantity));

                break;

            case "2":
                bool isValid = false;

                while (!isValid)
                {
                    Console.Write("Current price: " + oldProduct.Price + " Enter product price: ");
                    string i = Console.ReadLine();
                    isValid = double.TryParse(i, out new_price);
                    isValid = isValid && new_price >= 0;    
                    if (!isValid)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input! Please enter a valid number.");
                    }
                }
         
                warehouse.UpdateProduct(oldProduct, new Product(oldProduct.Name, new_price, oldProduct.Quantity));
                break;

            case "3":
                isValid = false;
                while (!isValid)
                {
                    Console.Clear();
                    Console.Write("Current quantity: " + oldProduct.Quantity + " Enter new product quantity: ");
                    string i = Console.ReadLine();
                    isValid = int.TryParse(i, out new_quantity);
                    isValid = isValid && new_quantity >= 0; 

                    if (!isValid)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input! Please enter a valid integer.");
                    }
                }
      
                warehouse.UpdateProduct(oldProduct, new Product(oldProduct.Name, oldProduct.Price, new_quantity));
                break;

            case "4":
                Console.Clear();
                Console.WriteLine("Exiting program...");
                return; // exits program

            default:
                Console.Clear();
                Console.WriteLine("Invalid option. Try again.");
                break;
        }

       
      

       


    }
    private static void DeleteProduct(Inventory warehouse)
    {
        Program.ViewProducts(warehouse);
        Console.WriteLine("Enter the name of the product to delete:");
        string name = Console.ReadLine() ?? string.Empty;
        Product? oldProduct = warehouse.GetWarehouse().Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (oldProduct == null)
        {
            Console.Clear();
            Console.WriteLine("Product not found.");
            return;
        }
    
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Are you sure? 1 = Yes, 2 = No,3 = Exit");

            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    warehouse.RemoveProduct(oldProduct);
                    Console.WriteLine("product deleted.");
                    return;

                case 2:
                    Program.ViewProducts(warehouse);
                    return;

                case 3:
                    Console.WriteLine("Exiting program...");
                    return; 

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

   
    }
    
}