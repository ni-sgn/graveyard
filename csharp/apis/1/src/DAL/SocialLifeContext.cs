namespace DAL;
using Microsoft.EntityFrameworkCore;

public class SocialLifeContext : DbContext {
  public SocialLifeContext(DbContextOptions options) : base(options) {

  }

  private DbSet<entities.Person> people { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {

    modelBuilder.Entity<entities.Person>().HasKey(nameof(entities.Person.custom_id));
    modelBuilder.Entity<entities.Mobile>().HasKey(nameof(entities.Mobile.mobile_number));
    
    modelBuilder.Entity<entities.Person>().HasMany<entities.Mobile>();
    modelBuilder.Entity<entities.Mobile>().HasMany<entities.Person>();

    modelBuilder.initialize();

  }
}
