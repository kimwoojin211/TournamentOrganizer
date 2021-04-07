using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TournamentOrganizer.Services;
using TournamentOrganizer.Models;
using System.Linq;
using TournamentOrganizer.Entities;

namespace TournamentOrganizer.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
      _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate([FromBody]AuthenticateModel model)
    {
      var user = _userService.Authenticate(model.Username, model.Password);

      if (user == null)
      {
        return BadRequest(new { message = "Username or password is incorrect" });
      }
      return Ok(user);
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
      var users = _userService.GetAll();
      return Ok(users);
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Post(User model)
    {
      _userService.Post(model);
      return Ok();
    }


    // GET: api/Tournaments/5
    [AllowAnonymous]
    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
      var user = _userService.GetUser(id);

      if (user == null)
      {
        return NotFound();
      }

      return Ok(user);
    }

    // PUT: api/Tournaments/{#}
    [HttpPut("{id}")]
    public IActionResult Put(int id, User user)
    {
      if (id != user.UserId)
      {
        return BadRequest();
      }
      try
      {
        _userService.Put(id,user);
      }
      catch 
      {
        if (!_userService.UserExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return Ok();
    }
    // DELETE: api/Users/1
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
      try{
        _userService.Delete(id);
      }
      catch
      {
        return NotFound();
      }
      return Ok();
    }

  }
}