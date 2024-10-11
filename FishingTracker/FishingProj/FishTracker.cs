using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace FishingProj
{
    public class FishTracker
    {
        private List<Fish> _fishList = new List<Fish>();
        private readonly string _filePath;
        private readonly TrackerSettings _settings;

        public FishTracker(string filePath, TrackerSettings settings)
        {
            _filePath = filePath;
            _settings = settings;
        }

        public void AddFish(Fish fish)
        {
            if (_fishList.Count >= _settings.MaxFishEntries)
            {
                Console.WriteLine("Max fish entries reached. Cannot add more fish.");
                return;
            }
            _fishList.Add(fish);
            SaveData(); // Save data after adding fish
        }

        public IEnumerable<Fish> GetAllFish()
        {
            return _fishList; // Return the list of fish
        }

        public void SaveData()
        {
            string jsonData = JsonSerializer.Serialize(_fishList);
            File.WriteAllText(_filePath, jsonData); // Write the serialized data to the file
        }

        public void LoadData()
        {
            if (File.Exists(_filePath))
            {
                string jsonData = File.ReadAllText(_filePath);
                _fishList = JsonSerializer.Deserialize<List<Fish>>(jsonData) ?? new List<Fish>(); // Deserialize or create a new list if the file is empty
            }
        }

        // Method to delete all fish entries by clearing the in-memory list and saving the empty list
        public void ClearData()
        {
            _fishList = new List<Fish>(); // Reset the in-memory list to an empty list
            SaveData(); // This will overwrite the file with an empty list, effectively deleting the stored data
        }
    }
}

    
