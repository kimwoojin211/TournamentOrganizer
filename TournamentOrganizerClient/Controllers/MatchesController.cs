using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TournamentOrganizerClient.Models;

namespace TournamentOrganizerClient.Controllers
{
  public class MatchesController : Controller
  {
    public IActionResult Index()
    {
      var allMatches = Match.GetMatches();
      return View(allMatches);
    }

    public IActionResult Create()
    {
      return View();
    }

    public IActionResult Details(int id)
    {
      var match = Match.GetDetails(id);
      match.MatchUsers = Match.GetMatchUsers(id);
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