using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TournamentOrganizerClient.Models;
using TournamentOrganizerClient.ViewModels;

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
    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Register(RegisterViewModel model)
    {
      if(model.Username==null || model.Email==null || model.Password==null || !Account.Register(model.Username, model.Email, model.Password))
      {
        System.Console.WriteLine("Failure.");
        return RedirectToAction("Register");
      }
      else
      {
        System.Console.WriteLine("Success!");
        return RedirectToAction("Index","Home");
      }
    }
    public ActionResult Login()
    {
      return View();
    } 

    [HttpPost]
    public ActionResult Login(LoginViewModel model)
    {
      var account = Account.Login(model.Username,model.Password);
      if(account != null)//quickfix shortcut to async without asyncing.
      {
        System.Console.WriteLine("Success! " + account.Token);
        return RedirectToAction("Index","Home");
      }
      else
      {
        System.Console.WriteLine("Failure.");
        return RedirectToAction("Login");
      }
    }

    public IActionResult Edit(int id)
    {
      var account = Account.GetDetails(id);
      return View(account);
    }
    [HttpPost]
    public IActionResult Details(int id,Account account)
    {
      account.UserId = id;
      Account.Put(account);
      return RedirectToAction("Details", id);
    }
    public IActionResult Delete(int id)
    {
      var account = Account.GetDetails(id);
      return View(account);
    }
  }
}