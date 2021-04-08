using System.Collections.Generic;
using System;
using TournamentOrganizer.Models;
namespace TournamentOrganizer.Entities
{
  public class User
  {
    public User()
    {
      this.MatchUsers = new HashSet<MatchUser>();
      this.TournamentUsers = new HashSet<TournamentUser>();
    }
    public User(string username, string password, string email):this()
    {
      this.MatchUsers = new HashSet<MatchUser>();
      this.TournamentUsers = new HashSet<TournamentUser>();
      this.Username= username;
      this.Password= password;
      this.Email = email;
    }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Region { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
    public virtual ICollection<TournamentUser> TournamentUsers { get; set; }
    public virtual ICollection<MatchUser> MatchUsers { get; set; }
  }
}