namespace DAL;

using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using Dapper;
using System.Data.Common;


public static class DataOperations {

  public static string GetName(string personal_no, string connectionString) {
    using(DbConnection con = new SqlConnection(connectionString)) { 
      var result = con.Query<string>("SELECT last_name FROM dbo.people WHERE first_name = 'nika'").Single();

      return result;
    }
  }


}