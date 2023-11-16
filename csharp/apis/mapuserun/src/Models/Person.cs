namespace Models;

using System.ComponentModel.DataAnnotations;

public sealed class Person {
  [Key]
  public int custom_id { get; set; }
  public string first_name { get; set; }
  public string last_name { get; set; }
  public DateTime date_of_birth { get; set; }
} 
