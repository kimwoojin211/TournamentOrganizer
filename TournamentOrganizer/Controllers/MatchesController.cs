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
  public class MatchesController : ControllerBase
  {
    private readonly TournamentOrganizerContext _db;
    public MatchesController(TournamentOrganizerContext db)
    {
      _db = db;
    }
    // GET api/matches
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Match>>> Get()
    {
      var query = _db.Matches.Include(match => match.MatchUsers).ThenInclude(join => join.User).AsQueryable();
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
      //   query = query.OrderBy(match => match.MatchId).Skip((int.Parse(page) - 1) * size).Take(size);
      // }

    }

    // POST api/Matches
    [HttpPost]
    public async Task<ActionResult<Match>> Post(Match match)
    {
      var thisTournament = await _db.Tournaments
                                .FirstOrDefaultAsync(entry => entry.TournamentId == match.TournamentId);
      if(thisTournament != null)
      {
        System.Console.WriteLine(thisTournament.ToString());
        thisTournament.Matches.Add(match);
        _db.Tournaments.Update(thisTournament);
        await _db.SaveChangesAsync();
      }
      else
      {
          return BadRequest();
      }
      // if(users != null)
      // {
      //   foreach(User user in users)
      //   {
      //     _db.MatchUsers.Add(new MatchUser(){ MatchId = match.MatchId, UserId = user.UserId});
      //     await _db.SaveChangesAsync();
      //   }
      // }
      return CreatedAtAction(nameof(GetMatch), new { id = match.MatchId }, match);
      

    }
    // GET: api/Matches/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Match>> GetMatch(int id)
    {
      var match = await _db.Matches
        .Include(match => match.MatchUsers)
        .ThenInclude(join => join.User)
        .FirstOrDefaultAsync(match => match.MatchId == id);

      if (match == null)
      {
        return NotFound();
      }

      return match;
    }

    // PUT: api/Matches/{#}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Match match)
    {
      if (id != match.MatchId)
      {
        return BadRequest();
      }

      try
      {
        _db.Entry(match).State = EntityState.Modified;
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!MatchExists(id))
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
    // DELETE: api/Matches/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMatch(int id)
    {
      var match = await _db.Matches.FindAsync(id);
      if (match == null)
      {
        return NotFound();
      }
      _db.Matches.Remove(match);
      await _db.SaveChangesAsync();
      return NoContent();
    }
    
    [HttpDelete("{id}/DeleteUser/{joinId}")]
    public async Task<IActionResult> DeleteUser(int joinId)
    {
      var joinEntry = _db.MatchUsers.FirstOrDefaultAsync(entry => entry.MatchUserId == joinId);
      _db.Remove(joinEntry);
      await _db.SaveChangesAsync();
      return NoContent();
    }

    [HttpPost("{matchId}/AddUser/{userId}")]
    public async Task<IActionResult> AddUser(Match match, int matchId, int userId)
    {
      if(match != null)
      {
        _db.MatchUsers.Add(new MatchUser() {MatchId = matchId, UserId = userId});
        await _db.SaveChangesAsync();
      }
      return NoContent();
    }

    private bool MatchExists(int id)
    {
      return _db.Matches.Any(e => e.MatchId == id);
    }
  }
}