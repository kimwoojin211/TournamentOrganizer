// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using TournamentOrganizer.Models;

// namespace TournamentOrganizer.Controllers
// {
//   [Route("players")]
//   [ApiController]
//   public class PlayersController : ControllerBase
//   {
//     private readonly TournamentOrganizerContext _db;

//     public PlayersController(TournamentOrganizerContext db)
//     {
//       _db = db;
//     }


//     [HttpGet]
//     public ActionResult<IEnumerable<Player>> Get()
//     {
//       var query = _db.Players.AsQueryable();

//       // if (name != null)
//       // {
//       //   query = query.Where(entry => entry.Name == name);
//       // }

//       // if (goods != null)
//       // {
//       //   query = query.Where(entry => entry.Goods == goods);
//       // }

//       // if (number != null)
//       // {
//       //   query = query.Where(entry => entry.Number == number);
//       // }

//       return query.ToList();
//     }



//     [HttpGet("{id}")]
//     public async Task<ActionResult<Player>> GetPlayer(int id)
//     {
//       var player = await _db.Players.FindAsync(id);

//       if (player == null)
//       {
//         return NotFound();
//       }

//       return player;
//     }


//     [HttpPut("{id}")]
//     public async Task<IActionResult> Put(int id, Player player)
//     {
//       if (id != player.PlayerId)
//       {
//         return BadRequest();
//       }

//       _db.Entry(player).State = EntityState.Modified;

//       try
//       {
//         await _db.SaveChangesAsync();
//       }
//       catch (DbUpdateConcurrencyException)
//       {
//         if (!PlayerExists(id))
//         {
//           return NotFound();
//         }
//         else
//         {
//           throw;
//         }
//       }

//       return NoContent();
//     }

//     [HttpPost]
//     public async Task<ActionResult<Player>> Post(Player player)
//     {
//       _db.Players.Add(player);
//       await _db.SaveChangesAsync();

//       return CreatedAtAction(nameof(GetPlayer), new { id = player.PlayerId }, player);
//     }


//     [HttpDelete("{id}")]
//     public async Task<IActionResult> DeletePlayer(int id)
//     {
//       var player = await _db.Players.FindAsync(id);
//       if (player == null)
//       {
//         return NotFound();
//       }

//       _db.Players.Remove(player);
//       await _db.SaveChangesAsync();

//       return NoContent();
//     }

//     private bool PlayerExists(int id)
//     {
//       return _db.Players.Any(e => e.PlayerId == id);
//     }
//   }
// }