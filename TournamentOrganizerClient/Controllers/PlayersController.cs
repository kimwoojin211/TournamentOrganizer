// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using TournamentOrganizerClient.Models;

// namespace TournamentOrganizerClient.Controllers
// {
//   public class PlayersController : Controller
//   {
//     public IActionResult Index()
//     {
//       var allPlayers = Player.GetPlayers();
//       return View(allPlayers);
//     }

//     [HttpPost]
//     public IActionResult Index(Player player)
//     {
//       Player.Post(player);
//       return RedirectToAction("Index");
//     }

//     public IActionResult Details(int id)
//     {
//       var player = Player.GetDetails(id);
//       return View(player);
//     }

//     public IActionResult Edit(int id)
//     {
//       var player = Player.GetDetails(id);
//       return View(player);
//     }

//     [HttpPost]
//     public IActionResult Details(int id, Player player)
//     {
//       player.PlayerId = id;
//       Player.Put(player);
//       return RedirectToAction("Details", id);
//     }

//     public IActionResult Delete(int id)
//     {
//       Player.Delete(id);
//       return RedirectToAction("Index");
//     }
//   }
// }