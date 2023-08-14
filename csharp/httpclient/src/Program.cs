using static System.Console;
namespace test;


// learn streams in c#

public class EntryPoint{
    public static async Task<string> GetData()
    {
        HttpClient client = new HttpClient();
        //client.BaseAddress = new Uri("google.com"); 

        var data = await client.GetAsync("https://google.com");
        if (data.IsSuccessStatusCode)
            return await (data?.Content?.ReadAsStringAsync() ?? throw new ArgumentException("This shit is null"));
        else throw new Exception("Could not read the data");
    }

    public static async Task Main()
    {
        try{
            var result = await GetData();
            WriteLine(result);
        }
        catch(Exception ex)
        {
            WriteLine(ex.Message);
        }
    }

}
