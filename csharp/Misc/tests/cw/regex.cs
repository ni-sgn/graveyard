using Xunit;
using System.Text.RegularExpressions;

public class regexTests {
  [Fact]
  public void just_create_some_regex_object() { 
    // arrange
    Regex reg = new Regex("^[a-zA-Z0]+$");
    string test_subject = "abRraCCaaddab0raA"; 

    // act
    var result = reg.IsMatch(test_subject);

    // assert
    Assert.True(result);
  }
}