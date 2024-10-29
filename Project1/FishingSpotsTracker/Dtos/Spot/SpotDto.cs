using System.ComponentModel.DataAnnotations;

namespace FishingSpotsTracker.Dtos.Spot;

public class SpotDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string WaterBodyType { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    
}

