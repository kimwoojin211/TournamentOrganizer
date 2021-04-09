using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TournamentOrganizer.Entities;
using TournamentOrganizer.Models;
using TournamentOrganizer.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TournamentOrganizer.Services
{
  public interface IUserService
  {
    User Authenticate(string username, string password);
    IEnumerable<User> GetAll(string tournamentId,string matchId);
    User Post(string username, string password, string email);
    User GetUser(int id);
    void Put(int id, User user);
    void Delete(int id);
    bool UserExists(int id);
  }

  public class UserService : IUserService
  {
    private readonly TournamentOrganizerContext _db;
    private readonly AppSettings _appSettings;

    public UserService(TournamentOrganizerContext db, IOptions<AppSettings> appSettings)
    {
      _appSettings = appSettings.Value;
      _db = db;
    }

    public IEnumerable<User> GetAll(string tournamentId, string matchId)
    {
      var query = _db.Users.Include(user => user.TournamentUsers).ThenInclude(join => join.Tournament).Include(user => user.MatchUsers).ThenInclude(join => join.Match).ToList();
      List<User> userList = new List<User>();
      if(tournamentId !=null)
      {
        foreach (User user in query)
        {
          foreach (TournamentUser tournamentUser in user.TournamentUsers)
          {
            if (tournamentUser.TournamentId == int.Parse(tournamentId))
            {
              userList.Add(user);
            }
          }
        }
      }
      if (matchId != null)
      {
        foreach (User user in query)
        {
          foreach (MatchUser matchUser in user.MatchUsers)
          {
            if (matchUser.MatchId == int.Parse(matchId))
            {
              userList.Add(user);
            }
          }
        }
      }
    return userList.WithoutPasswords();
    }

    public User Authenticate(string username, string password)
    {
      var user = _db.Users.SingleOrDefault(user => user.Username == username && user.Password == password);
      // return null if user not found
      if (user == null)
      {
        return null;
      }
      else
      {
        var loggedInUser = _db.Users.FirstOrDefault(user => !(String.IsNullOrEmpty(user.Token)));
        if(!(loggedInUser ==null) && user.UserId != loggedInUser.UserId)
        {
          loggedInUser.Token = null;
          _db.Users.Attach(loggedInUser);
          _db.SaveChanges();
        }
          // if loggedinuser null, then first login.
          // if user and loggedin user are different, null the logged in user's token, create new JWT
          // if user and loggedinuser are same, user trying to log in is already logged in. do we want to remake the JWT so it refreshes the expiration? or do we just skip over the jwt generation? 
          // seems like if i remake JWT for case 3, i can simplify the logic to always recreate a new JWT on authentication

          // authentication successful so generate jwt token
          var tokenHandler = new JwtSecurityTokenHandler();
          var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
          var tokenDescriptor = new SecurityTokenDescriptor
          {
            Subject = new ClaimsIdentity(new Claim[]
            {
              new Claim(ClaimTypes.Name, user.UserId.ToString())
            }),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
          };
          var token = tokenHandler.CreateToken(tokenDescriptor);
          user.Token = tokenHandler.WriteToken(token);
          _db.Users.Update(user);
          _db.SaveChanges();
        }

      return user.WithoutPassword();
    }
    
    public User Post(string username, string password, string email)
    {
      if (_db.Users.Any(user => user.Username == username)|| _db.Users.Any(user => user.Email == email))
      {
        return null;
      }
      User newUser = new User(username, password, email);
      _db.Users.Add(newUser);
      _db.SaveChanges();
      return newUser;
    }

    public User GetUser(int id)
    {
      var user = _db.Users.FirstOrDefault(user => user.UserId == id);

      if(user == null)
      {
        return null;
      }
      return user.WithoutPassword();
    }
    public void Put(int id, User user)
    {
      try
      {
        _db.Users.Update(user);
        _db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException)
      {
        throw;
      }
    }
    public void Delete(int id)
    {
      var user = _db.Users.FirstOrDefault(user => user.UserId == id);
      if (user != null)
      {
        _db.Users.Remove(user);
        _db.SaveChanges();
      }
      else
      {
        throw new Exception();
      }
    }

    public bool UserExists(int id)
    {
      return _db.Users.Any(e => e.UserId == id);
    }
  }
}