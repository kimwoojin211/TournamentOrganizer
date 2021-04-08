using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TournamentOrganizerClient.Models;

namespace TournamentOrganizerClient.Controllers
{
  public class TournamentsController : Controller
  {
    public IActionResult Index()
    {
      var allTournaments = Tournament.GetTournaments();
      return View(allTournaments);
    }

    public IActionResult Create()
    {
      return View();
    }
    public IActionResult Details(int id)
    {
      var thisTournament = Tournament.GetDetails(id);
      return View(thisTournament);
    }

    
    public IActionResult Edit(int id)
    {
      var tournament = Tournament.GetDetails(id);
      return View(tournament);
    }

    [HttpPost]
    public IActionResult Details(int id,Tournament tournament)
    {
      tournament.TournamentId = id;
      Tournament.Put(id,tournament);
      return RedirectToAction("Details", id);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
      Tournament.Delete(id);
      return RedirectToAction("Index");
    }


  }
}