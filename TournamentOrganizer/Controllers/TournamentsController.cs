using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournamentOrganizer.Models;
using TournamentOrganizer.Entities;

namespace TournamentOrganizer.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TournamentsController : ControllerBase
  {
    private readonly TournamentOrganizerContext _db;
    public TournamentsController(TournamentOrganizerContext db)
    {
      _db = db;
    }
    // GET api/tournaments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tournament>>> Get()
    {
      var query = _db.Tournaments.Include(tournament => tournament.Matches).Include(tournament => tournament.TournamentUsers).ThenInclude(join => join.User).AsQueryable();
      return await query.ToListAsync();
      // if (name != null)
      // {
      //   query = query.Where(entry => entry.Name == name);
      // }
      // if (category != null)
      // {
      //   query = query.Where(entry => entry.Category == category);
      // }
      // if (hoursOpen != null)
      // {
      //   query = query.Where(entry => String.Compare(entry.HoursOpen, hoursOpen)<=0);
      // }
      // if (hoursClose != null)
      // {
      //   query = query.Where(entry => String.Compare(entry.HoursClose, hoursClose) <= 0);
      // }
      // if (page != null)
      // {
      //   int size = (pageSize == null ? 20 : Int32.Parse(pageSize));
      //   query = query.OrderBy(tournament => tournament.TournamentId).Skip((int.Parse(page) - 1) * size).Take(size);
      // }

    }

    // POST api/Tournaments
    [HttpPost]
    public async Task<ActionResult<Tournament>> Post(Tournament tournament)
    {
      _db.Tournaments.Add(tournament);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetTournament), new { id = tournament.TournamentId }, tournament);
    }
    // GET: api/Tournaments/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Tournament>> GetTournament(int id)
    {
      var tournament = await _db.Tournaments.FindAsync(id);

      if (tournament == null)
      {
        return NotFound();
      }

      return tournament;
    }

    // PUT: api/Tournaments/{#}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Tournament tournament)
    {
      if (id != tournament.TournamentId)
      {
        return BadRequest();
      }
      _db.Entry(tournament).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TournamentExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }
    // DELETE: api/Tournaments/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTournament(int id)
    {
      var tournament = await _db.Tournaments.FindAsync(id);
      if (tournament == null)
      {
        return NotFound();
      }
      _db.Tournaments.Remove(tournament);
      await _db.SaveChangesAsync();
      return NoContent();
    }

    [HttpDelete("{id}/DeleteUser/{joinId}")]
    public async Task<IActionResult> DeleteUser(int joinId)
    {
      var joinEntry = await _db.TournamentUsers.FirstOrDefaultAsync(entry => entry.TournamentUserId == joinId);
      _db.Remove(joinEntry);
      await _db.SaveChangesAsync();
      return NoContent();
    }

    [HttpPost("{id}/AddUser/{userId}")]
    public async Task<IActionResult> AddUser(int id, int userId)
    {
      var thisTournament =  await _db.Tournaments.FindAsync(id);
      if(thisTournament != null)
      {
        _db.TournamentUsers.Add(new TournamentUser() {TournamentId = thisTournament.TournamentId, UserId = userId});
        await _db.SaveChangesAsync();
      }
      return NoContent();
    }

    private bool TournamentExists(int id)
    {
      return _db.Tournaments.Any(e => e.TournamentId == id);
    }
  }
}