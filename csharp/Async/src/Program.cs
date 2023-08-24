
using System.Threading.Tasks;
using static System.Console;

public class Asynchronous {


  // This is a so called blocking code
  // it is blocking because it blocks the thread while it goes on
  // by executing what it contains step-by-step
  // because it blocks thread, it also blocks thread-context
  // which I don't quite understand what that means
  // but if some continuation asks for that context, it will be
  // waiting forever, because this guy right here, is not letting it go
  // !!!! Main takeaway, if you are calling async method, make calle also async ( Always )
  public static void Main( string[] args ) {
    WriteLine( Methods.GetModifiedAsync( "prefix" ).Result );
  }

  // This one is a non-blocking code
  // Why does not it block it? I don't know yet
  // 
  /*
  public static async Task Main(string[] args) {
    WriteLine( await Methods.GetModifiedAsync( "prefix" ) );
  }
  */

}
public static class Methods {
  public async static Task<String> GetModifiedAsync( string prefix ) { 
    using( HttpClient client = new() ) {
      var a = await client.GetStringAsync( "https://www.google.com" );

      return a + prefix;
    } 
  }
}

