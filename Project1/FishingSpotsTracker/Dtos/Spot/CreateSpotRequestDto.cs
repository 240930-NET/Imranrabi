using System.ComponentModel.DataAnnotations;

namespace FishingSpotsTracker.Dtos.Spot;

public class CreateSpotRequestDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string WaterBodyType { get; set; } = string.Empty;

    [Required]
    public double Latitude { get; set; }

    [Required]
    public double Longitude { get; set; }
}

