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
    IEnumerable<User> GetAll();
    void Post(User model);
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

    public User Authenticate(string username, string password)
    {
      var user = _db.Users.SingleOrDefault(user => user.Username == username && user.Password == password);
      // return null if user not found
      if (user == null)
      {
        return null;
      }

      // authentication successful so generate jwt token
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
        {
          new Claim(ClaimTypes.Name, user.UserId.ToString())
        }),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      user.Token = tokenHandler.WriteToken(token);

      return user.WithoutPassword();
    }

    public IEnumerable<User> GetAll()
    {
      return _db.Users.WithoutPasswords();
    }
    public void Post(User model)
    {
      _db.Users.Add(model);
      _db.SaveChanges(); 
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
        _db.Entry(user).State = EntityState.Modified;
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