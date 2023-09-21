namespace DAL;

using Dapper;
using Microsoft.Data.SqlClient;

using Microsoft.EntityFrameworkCore;

public class SocialLifeContext : DbContext {
  public SocialLifeContext(DbContextOptions options) : base(options) {

  }

  private DbSet<DAL.entities.Person> people { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    modelBuilder.Entity<DAL.entities.Person>().HasKey(nameof(DAL.entities.Person.custom_id));
  }
}
