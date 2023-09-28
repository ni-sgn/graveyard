using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace dal;
public class DeathContext : DbContext{
    public DeathContext(DbContextOptions options) : base (options){

    }

    public DbSet<entities.Graveyard>
}