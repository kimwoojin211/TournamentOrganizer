using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TournamentOrganizerClient.Models;

namespace TournamentOrganizerClient.Controllers
{
  public class AccountsController : Controller
  {
    public ActionResult Index()
    {
      var allAccounts = Account.GetAccounts();
      return View(allAccounts);
    }
  }
}