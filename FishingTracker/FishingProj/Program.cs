using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;


namespace FishingProj
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string filePath = config["FishDataFile"] ?? "fishdata.json";
            var trackerSettings = config.GetSection("TrackerSettings").Get<TrackerSettings>() ?? new TrackerSettings { MaxFishEntries = 100 };
            bool clearDataOnStartup = config.GetValue<bool>("ClearDataOnStartup");

            FishTracker fishTracker = new FishTracker(filePath, trackerSettings);

            // This will clear data if the setting is added inside the appsettings.json using , "ClearDataOnStartup": true
            if (clearDataOnStartup)
            {
                fishTracker.ClearData();
                Console.WriteLine("Data cleared on startup!");
            }

            fishTracker.LoadData(); // Load existing data from file

            Console.WriteLine("Welcome to the Fishing Tracker!");

            while (true)
            {
                Console.WriteLine("1. Add a new fish");
                Console.WriteLine("2. View all fish");
                Console.WriteLine("3. Exit");

                /* When trying to do dotnet build I kept getting warnings about converting null to string
                so I used the null-coalescing operator to avoid this.*/
                string choice = Console.ReadLine() ??  string.Empty; 



                switch (choice)
                {
                    case "1":
                        AddFish(fishTracker);
                        break;
                    case "2":
                        ViewAllFish(fishTracker);
                        break;
                    case "3":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddFish(FishTracker fishTracker)
        {
            Console.WriteLine("Enter fish name:");
            string name = Console.ReadLine() ?? string.Empty;

            double weight = GetValidDouble("Enter fish weight in lbs:");
            double length = GetValidDouble("Enter fish length in in:");

            Fish newFish = new()
            {
                Name = name,
                Weight = weight,
                Length = length,
                CatchTime = DateTime.Now
            };

            fishTracker.AddFish(newFish);
            Console.WriteLine("Fish added successfully!");
        }

        static void ViewAllFish(FishTracker fishTracker) 
        {
            foreach (var fish in fishTracker.GetAllFish())
            {
                Console.WriteLine($"Name: {fish.Name}, Weight: {fish.Weight}, Length: {fish.Length}, Catch Time: {fish.CatchTime}");
            }
        }

        static double GetValidDouble(string prompt)
        {
            double result;
            while (true)
            {
                Console.WriteLine(prompt);
                if (double.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

    public class TrackerSettings
    {
        public int MaxFishEntries { get; set; }
    }

    public class Fish
    {
        public string Name { get; set; } = string.Empty; // Initialize properties to avoid null
        public double Weight { get; set; }
        public double Length { get; set; }
        public DateTime CatchTime { get; set; }
    }
}
