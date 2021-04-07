using System.Collections.Generic;
using System.Linq;
using TournamentOrganizer.Entities;
using TournamentOrganizer.Models;

namespace TournamentOrganizer.Helpers
{
  public static class ExtensionMethods
  {
    public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users)
    {
      return users.Select(user => user.WithoutPassword());
    }

    public static User WithoutPassword(this User user)
    {
      user.Password = null;
      return user;
    }
  }
}