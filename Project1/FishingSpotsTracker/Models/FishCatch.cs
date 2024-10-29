using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace FishingSpotsTracker.Models;

public class FishCatch
{
    [Key]
    public int Id { get; set; } 

    [Required]
    public DateTime CatchDate { get; set; } = DateTime.Now;

    private double _weightInPounds;
    public double WeightInPounds
    {
        get => _weightInPounds;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Weight must be positive");
            _weightInPounds = value;
        }
    }

    [Range(0, 200)]
    public double? LengthInInches { get; set; }

    public string? Lure { get; set; }
    public string? Notes { get; set; }
}
