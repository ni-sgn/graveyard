namespace DAL;

using DAL.entities;
using FluentValidation;

public class PersonValidator : AbstractValidator<entities.Person>{
  public PersonValidator() {
    RuleFor(Person => Person.first_name).MinimumLength(2);
  }
}