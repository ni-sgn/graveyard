using Xunit;
using System.Text;
using static System.Console;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;

public class string_streaming {

  [Fact]
  public void can_you_turn_string_into_stream() {

    // arrange
    string dna = new string("aabbaaa"); 
    System.Text.Encoding encoding = Encoding.ASCII; // UTF8 is backwards compatible to ASCII

    byte[] byteArray = encoding.GetBytes(dna);

    // act

    // assert
  }

  [Fact]
  public void going_through_string() {
    // arrange
    string camelCasedTestSubject = new string("camelCasedTestSubject");
    string expected = "camel Cased Test Subject";
    StringBuilder sb = new StringBuilder();

    // act
    List<string> result = new(); 
    string temp = string.Empty;

    foreach(char c in camelCasedTestSubject) {
      if(!Char.IsUpper(c)) {
        sb.Append(c);
      } else {
        result.Add(sb.ToString());
        sb.Clear();
        sb.Append(c);
      }
    }
      result.Add(sb.ToString());

    WriteLine($"Result:{result.Aggregate((s1, s2) => String.Join(' ', s1, s2))}");

    string actual = string.Join(" ", result);
    // It'a almost like this needs to be a triggering point for arrange and act 
    // does not make sense programatically but without assert there is no experiment/test
    // assert
    Assert.Equal(expected, actual);
  }

  [Fact]
  public void string_gets_split() {
    // arrange 
    string testSubject = "test-subject";
    List<string> expected = new List<string> {"t2t" , "s5t"}; 

    List<string> buffer = new();

    // act
    List<string> cutStrings = testSubject.Split(' ', '-').ToList();
    List<string> abbreviated = cutStrings.Select(str => str.Length < 4 ? str : $"{str[0]}{str.Length-2}{str[str.Length-1]}").ToList();
    var actual = string.Join(' ', abbreviated);


    // assert
    Assert.Equal(abbreviated, expected);
  } 
} 