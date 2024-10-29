using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FishingSpotsTracker.Data;
using FishingSpotsTracker.Models;
using FishingSpotsTracker.Mappers;
using Microsoft.EntityFrameworkCore;
using FishingSpotsTracker.Dtos.FishCatch;



namespace FishingSpotsTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatchesController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    
    public CatchesController(ApplicationDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<FishCatch>> GetAllCatches()
    {
        var fishCatches = _context.FishCatches.ToList() 
        .Select(fishCatch => fishCatch.ToFishCatchDto());
        return Ok(fishCatches);
    }

    [HttpGet("{id}")]
    public ActionResult<FishCatch> GetCatchById([FromRoute] int id)
    {
        var fishCatch = _context.FishCatches.Find(id);
        if (fishCatch == null)
        {
            return NotFound();
        }
        return Ok(fishCatch.ToFishCatchDto());
    } 

    [HttpPost]
    public ActionResult<FishCatch> CreateCatch([FromBody] CreateFishCatchRequestDto createFishCatchRequestDto)
    {
        var fishCatchToCreate = createFishCatchRequestDto.ToFishCatch();
        _context.FishCatches.Add(fishCatchToCreate);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetCatchById), new { id = fishCatchToCreate.Id }, fishCatchToCreate.ToFishCatchDto());
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult<FishCatch> Update([FromRoute] int id, [FromBody] UpdateFishCatchRequestDto updateFishCatchRequestDto)
    {
        var fishCatchToUpdate = _context.FishCatches.FirstOrDefault(fishCatch => fishCatch.Id == id);
        if (fishCatchToUpdate == null)
        {
            return NotFound();
        }

        fishCatchToUpdate.CatchDate = updateFishCatchRequestDto.CatchDate;
        fishCatchToUpdate.WeightInPounds = updateFishCatchRequestDto.WeightInPounds;
        fishCatchToUpdate.LengthInInches = updateFishCatchRequestDto.LengthInInches;
        fishCatchToUpdate.Lure = updateFishCatchRequestDto.Lure;
        fishCatchToUpdate.Notes = updateFishCatchRequestDto.Notes;

        _context.SaveChanges();
        return Ok(fishCatchToUpdate.ToFishCatchDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        var fishCatchToDelete = _context.FishCatches.FirstOrDefault(fishCatch => fishCatch.Id == id);
        if (fishCatchToDelete == null)
        {
            return NotFound();
        }

        _context.FishCatches.Remove(fishCatchToDelete);
        _context.SaveChanges();
        return NoContent();
    }
}

