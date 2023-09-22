using Microsoft.EntityFrameworkCore;
using DAL.entities;

public static class initial_values {
  public static void initialize(this ModelBuilder mb) {

    mb.Entity<Mobile>().HasData(new Mobile[] {
      new Mobile {
        mobile_number = "123123123",
        provider      = "magti"
      },

      new Mobile {
        mobile_number = "321321321",
        provider      = "magti"
      }
    });

    mb.Entity<Person>().HasData(new Person[] {
      new Person {
        custom_id     = 1,
        first_name    = "nika",
        last_name     = "saganelidze",
        date_of_birth = DateTime.Now
      },

      new Person {
        custom_id     = 2,
        first_name    = "nika's",
        last_name     = "clone",
        date_of_birth = DateTime.Now
      }
    });
  } 
}