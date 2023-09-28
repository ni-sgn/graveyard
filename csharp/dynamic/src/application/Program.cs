using static System.Console;
using System.Xml.Linq;

struct Car
{

}

// boxing
public class Program {
    public async static Task Main(string[] arsg) {
        dynamic name = "nika";
        String lastName = new string("saganelidze");

        XDocument AdditionalFields = new(new XElement("AdditionalFields"));

        AdditionalFields?.Root?.Add(new XElement("SA", 
            new XElement("taxId", "123"),
            new XElement("taxPayerId", "123123123")
            ));

        var stringy = AdditionalFields?.ToString();
        var backToXml = XDocument.Parse(stringy ?? throw new ArgumentException());


        string strXML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><taxPayerID>123</taxPayerID>";
        XDocument saxml = XDocument.Parse(strXML);
        WriteLine(saxml.Element("taxPayerID").Value);

        WriteLine(new { Id = 3, name = "hello", xml = saxml }.ToString());

    }

}


public sealed class CustomString<T> {
    public CustomString() {
        
    }
}
