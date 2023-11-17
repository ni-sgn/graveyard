using Microsoft.Data.SqlClient;
using Dapper;

namespace program;

public class EntryPoint{

  public static void Main(string[] args) {

    Console.WriteLine("Hello, World!");
    var con = new SqlConnection(
        "Server=localhost,1433;"
        + "Database=university;User=SA;Password=P@ssw0rd;"
        + "TrustServerCertificate=True;"
        );

    try{
      con.Open();
      Console.WriteLine("Went successfully");
      var enum_of_subjects = 
        con.Query<models.Subject>("select * from subject");
      Console.WriteLine(enum_of_subjects.FirstOrDefault()?.name);
    }
    catch(Exception ex) {
      Console.WriteLine(ex.Message + ex?.InnerException?.Message);
    }
    finally{
      con?.Close();
    }

  }
}
