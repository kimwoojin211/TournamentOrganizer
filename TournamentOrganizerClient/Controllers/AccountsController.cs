using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TournamentOrganizerClient.Models;
// using TournamentOrganizerClient.ViewModels;

namespace TournamentOrganizerClient.Controllers
{
  public class AccountsController : Controller
  {
    public IActionResult Index()
    {
      var allAccounts = Account.GetAccounts();
      return View(allAccounts);
    }
    
    public IActionResult Details(int id)
    {
      var account = Account.GetDetails(id);
      return View(account);
    }
    // public IActionResult Register()
    // {
    //   return View();
    // }

    // [HttpPost]
    // public async Task<ActionResult> Register(RegisterViewModel model)
    // {
    //   var user = new Account{Username= model.Username,Password=model.Password};
    //   return View();
    // }
    
  }
}