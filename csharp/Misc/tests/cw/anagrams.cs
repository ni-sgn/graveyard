public class AnagramsTests {
  [Fact]
  public void Check_letters_one_by_one() {
    // arrange
    string str1 = ""; 
    string str2 = "toffee";

    bool actual = true;
    // act
    foreach(var c in str1) {
      if (!str2.Contains(c)) {
        actual = false;
        break;
      }
    }

    // assert
    Assert.True(actual);
  }

  [Fact]
  public void Check_by_ordering(){
    //arrange
     
    //act
    
    //assert
  }


}


