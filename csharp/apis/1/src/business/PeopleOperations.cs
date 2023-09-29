namespace business;

using DAL;
using DAL.entities;
using Microsoft.ML;

public class PeopleOperations {
  
  private readonly SocialLifeContext _context;
  public PeopleOperations(SocialLifeContext context) {
    _context = context;
  }

  public void CreatePerson(Person person) {
    _context.Add<Person>(person);
    _context.SaveChanges();
  }

}
