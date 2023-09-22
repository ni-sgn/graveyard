namespace DAL.entities;

using System.ComponentModel.DataAnnotations;

internal sealed class Person {
  public int custom_id { get; set; }
  public DateTime date_of_birth { get; set; }
  public string first_name { get; set; } = null!;
  public string last_name { get; set; } = null!;
}