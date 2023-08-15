using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Dapper;

namespace program;

public class EntryPoint{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var con = new SqlConnection("Server=localhost,1433;Database=DataHub;User=SA;Password=putStrLn $ p2ssw0rd;TrustServerCertificate=True;");
        try{
            con.Open();
            Console.WriteLine("Went successfully");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message + ex?.InnerException?.Message);
        }
        finally{
            con?.Close();
        }
    }
}
