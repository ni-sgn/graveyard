using Microsoft.EntityFrameworkCore;
using Models;

public class DHContext : DbContext {

  public DHContext(DbContextOptions options) : base(options) {
  }

  public DbSet<Person> people { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    modelBuilder.Entity<Person>().ToTable("People");
  }

}
