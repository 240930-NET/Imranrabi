using System.ComponentModel.DataAnnotations;

namespace FishingSpotsTracker.Dtos.FishCatch;

public class FishCatchDto
{
    public int Id { get; set; }
    public DateTime CatchDate { get; set; }
    public double WeightInPounds { get; set; }
    public double LengthInInches { get; set; }
    public string Lure { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
}

