using System.ComponentModel.DataAnnotations;

namespace FishingSpotsTracker.Dtos.FishCatch;

public class CreateFishCatchRequestDto
{
    [Required]
    public DateTime CatchDate { get; set; }

    [Required]
    public double WeightInPounds { get; set; }

    [Required]
    public double LengthInInches { get; set; }

    [Required]
    public string Lure { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;
}

