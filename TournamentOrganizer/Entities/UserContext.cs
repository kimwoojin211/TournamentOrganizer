using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TournamentOrganizer.Entities
{
  public class UserContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public UserContext(DbContextOptions<UserContext> options)
      :base(options)
      {
      }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<User>()
          .HasData(
            new User{
              UserId= 1, 
              Username= "test",
              Password= "test",
              Name= "Joe Buden",
              Email= "joebud@budd.com",
              Region= "Los Angeles, CA, USA",
            },
            new User
            {
              UserId = 2,
              Username = "test2",
              Password = "test2",
              Name = "Joe Buddy",
              Email = "joebuddy@budd.com",
              Region = "Los Angeles, CA, USA",
            });
    }

  }
}