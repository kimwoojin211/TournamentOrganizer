using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

    [HttpPost]
    public IActionResult Index(Tournament tournament)
    {
      Tournament.Post(tournament);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var match = Match.GetDetails(id);
      return View(match);
    }

    public IActionResult Edit(int id)
    {
      var match = Match.GetDetails(id);
      return View(match);
    }

    [HttpPost]
    public IActionResult Details(int id, Match match)
    {
      match.MatchId = id;
      Match.Put(match);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Match.Delete(id);
      return RedirectToAction("Index");
    }
  }
}