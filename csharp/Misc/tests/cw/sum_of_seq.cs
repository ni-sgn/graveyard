public class sumeOfSeqTest {
  [Fact]
  public void Sum_gives_me_sum() {

    string filePath = 
      "/home/nika/"
      +"src/personal/graveyard/csharp/Misc/tests/cw/sum_of_seq.cs";
    string solutionPath = "solution.txt";

    string sourceCode = File.ReadAllText(filePath);
    
    using (FileStream destinationStream = File.Create(solutionPath)) 
    using (FileStream sourceStream = File.OpenRead(filePath)) {
      sourceStream.CopyTo(destinationStream);
    }  

    // arrange
    int start = 2;
    int end = 6;
    int step = 2;
    int actual = 0; 

    // act
    if (start <= end) {
      while (actual <= end) {
        actual += start;
        start += step; 
      } 
    } 

    // assert
    Assert.Equal(12, actual);
  }
  
}
