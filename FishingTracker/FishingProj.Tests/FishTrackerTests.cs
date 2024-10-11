using System;
using Xunit;

namespace FishingProj.Tests
{
    public class FishTrackerTests
    {
        private readonly string _testFilePath = "test_fishdata.json";

        private FishTracker CreateTestTracker()
        {
            var settings = new TrackerSettings { MaxFishEntries = 100 };
            return new FishTracker(_testFilePath, settings);
        }

        [Fact] 
        public void TestAddFish() 
        {
            var tracker = CreateTestTracker();

            var fish1 = new Fish { Name = "Salmon", Weight = 2.5, Length = 60, CatchTime = DateTime.Now };
            var fish2 = new Fish { Name = "Trout", Weight = 1.5, Length = 45, CatchTime = DateTime.Now.AddMinutes(-10) };
            var fish3 = new Fish { Name = "Pike", Weight = 4.3, Length = 85, CatchTime = DateTime.Now.AddMinutes(-30) };
            
            // Add each fish
            tracker.AddFish(fish1);
            tracker.AddFish(fish2);
            tracker.AddFish(fish3);

            // Grab all fish
            var allFish = tracker.GetAllFish();
            
            // Verify that all fish are in the list
            Assert.Contains(fish1, allFish);
            Assert.Contains(fish2, allFish);
            Assert.Contains(fish3, allFish);
        }

        [Fact]
        public void TestGetAllFish_WhenNoFishAdded_ReturnsEmptyList()
        {
            var tracker = CreateTestTracker();
            Assert.Empty(tracker.GetAllFish()); // If no fish are added the list should be empty

        }

        [Fact]
        public void TestAddMultipleFish()
        { 
            var tracker = CreateTestTracker(); 
            
            var fish1 = new Fish { Name = "Bass", Weight = 3.0, Length = 55, CatchTime = DateTime.Now }; 
            var fish2 = new Fish { Name = "Perch", Weight = 1.1, Length = 25, CatchTime = DateTime.Now.AddMinutes(-15) };
            var fish3 = new Fish { Name = "Walleye", Weight = 2.8, Length = 48, CatchTime = DateTime.Now.AddMinutes(-60) };

            
            tracker.AddFish(fish1);
            tracker.AddFish(fish2);
            tracker.AddFish(fish3);

            
            var allFish = tracker.GetAllFish();
            
            
            Assert.Contains(fish1, allFish);
            Assert.Contains(fish2, allFish);
            Assert.Contains(fish3, allFish);
        }
    }
}
