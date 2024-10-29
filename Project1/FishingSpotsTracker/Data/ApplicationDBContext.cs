using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FishingSpotsTracker.Models;
    

namespace FishingSpotsTracker.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }

    public DbSet<Spot> Spots { get; set; }
    public DbSet<FishCatch> FishCatches { get; set; }
}
