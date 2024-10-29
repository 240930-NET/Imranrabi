using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FishingSpotsTracker.Data;
using FishingSpotsTracker.Models;
using FishingSpotsTracker.Mappers;
using Microsoft.EntityFrameworkCore;
using FishingSpotsTracker.Dtos.Spot;


namespace FishingSpotsTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpotsController : ControllerBase
{
    private readonly ApplicationDBContext _context;

    public SpotsController(ApplicationDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Spot>> GetAllSpots()
    {
        var spots = _context.Spots.ToList()
        .Select(spot => spot.ToSpotDto());
        return Ok(spots);
    }

    [HttpGet("{id}")]
    public ActionResult<Spot> GetSpotById([FromRoute] int id)
    {
        var spot = _context.Spots.Find(id);
        if (spot == null)
        {
            return NotFound();
        }
        return Ok(spot.ToSpotDto());
    }

    [HttpPost]
    public ActionResult<Spot> CreateSpot([FromBody] CreateSpotRequestDto createSpotRequestDto)
    {
        var spotToCreate = createSpotRequestDto.ToSpot();
        _context.Spots.Add(spotToCreate);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetSpotById), new { id = spotToCreate.Id }, spotToCreate.ToSpotDto());
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult<Spot> Update([FromRoute] int id, [FromBody] UpdateSpotRequestDto updateSpotRequestDto)
    {
        var spotToUpdate = _context.Spots.FirstOrDefault(spot => spot.Id == id);
        if (spotToUpdate == null)
        {
            return NotFound();
        }

        spotToUpdate.Name = updateSpotRequestDto.Name;
        spotToUpdate.WaterBodyType = updateSpotRequestDto.WaterBodyType;
        spotToUpdate.Latitude = updateSpotRequestDto.Latitude;
        spotToUpdate.Longitude = updateSpotRequestDto.Longitude;

        _context.SaveChanges();
        return Ok(spotToUpdate.ToSpotDto());

    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        var spotToDelete = _context.Spots.FirstOrDefault(spot => spot.Id == id);
        if (spotToDelete == null)
        {
            return NotFound();
        }

        _context.Spots.Remove(spotToDelete);
        _context.SaveChanges();
        return NoContent();
    }
}


