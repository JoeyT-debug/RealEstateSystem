using System;
using System.Collections.Generic;

namespace RealEstateSystem
{
    class Program
    {
        // Represents a Property
        public class Property
        {
            public int Id { get; set; }
            public string Name { get; set; } // Property name
            public string Type { get; set; } // Residential, Commercial, etc.
            public string Status { get; set; } // Available, Sold, Rented
            public double Price { get; set; } // Price of the property
        }

        // Real Estate Management Class
        public class RealEstateManager
        {
            private List<Property> properties = new List<Property>();
            private int nextId = 1;

            // Display all properties
            public void DisplayProperties()
            {
                Console.WriteLine("\n--- Property Listings ---");
                if (properties.Count == 0)
                {
                    Console.WriteLine("No properties available.");
                }
                else
                {
                    foreach (var property in properties)
                    {
                        Console.WriteLine($"ID: {property.Id}, Name: {property.Name}, Type: {property.Type}, Status: {property.Status}, Price: {property.Price:C}");
                    }
                }
                Console.WriteLine("--------------------------");
            }

            // Add a new property
            public void AddProperty()
            {
                Console.Write("\nEnter Property Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Property Type (Residential/Commercial): ");
                string type = Console.ReadLine();
                Console.Write("Enter Property Status (Available/Sold/Rented): ");
                string status = Console.ReadLine();
                Console.Write("Enter Property Price: ");
                double price = double.Parse(Console.ReadLine());

                properties.Add(new Property
                {
                    Id = nextId++,
                    Name = name,
                    Type = type,
                    Status = status,
                    Price = price
                });

                Console.WriteLine("Property added successfully!");
            }

            // Update property details
            public void UpdateProperty()
            {
                Console.Write("\nEnter the Property ID to update: ");
                int id = int.Parse(Console.ReadLine());
                Property property = properties.Find(p => p.Id == id);

                if (property != null)
                {
                    Console.Write("Enter new Name (leave blank to keep current): ");
                    string name = Console.ReadLine();
                    Console.Write("Enter new Type (leave blank to keep current): ");
                    string type = Console.ReadLine();
                    Console.Write("Enter new Status (leave blank to keep current): ");
                    string status = Console.ReadLine();
                    Console.Write("Enter new Price (leave blank to keep current): ");
                    string priceInput = Console.ReadLine();

                    if (!string.IsNullOrEmpty(name)) property.Name = name;
                    if (!string.IsNullOrEmpty(type)) property.Type = type;
                    if (!string.IsNullOrEmpty(status)) property.Status = status;
                    if (!string.IsNullOrEmpty(priceInput)) property.Price = double.Parse(priceInput);

                    Console.WriteLine("Property updated successfully!");
                }
                else
                {
                    Console.WriteLine("Property ID not found.");
                }
            }

            // Delete a property
            public void DeleteProperty()
            {
                Console.Write("\nEnter the Property ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                Property property = properties.Find(p => p.Id == id);

                if (property != null)
                {
                    properties.Remove(property);
                    Console.WriteLine("Property deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Property ID not found.");
                }
            }
        }

        static void Main(string[] args)
        {
            RealEstateManager manager = new RealEstateManager();

            while (true)
            {
                Console.WriteLine("\n--- Real Estate System ---");
                Console.WriteLine("1. View Properties");
                Console.WriteLine("2. Add Property");
                Console.WriteLine("3. Update Property");
                Console.WriteLine("4. Delete Property");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        manager.DisplayProperties();
                        break;
                    case "2":
                        manager.AddProperty();
                        break;
                    case "3":
                        manager.UpdateProperty();
                        break;
                    case "4":
                        manager.DeleteProperty();
                        break;
                    case "5":
                        Console.WriteLine("Exiting the system. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
