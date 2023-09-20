namespace tests;

public class cw
{
    [Fact]
    public void Replace_Count_With_End_In_Range() {
      //arrange
      int start = 0;
      int count = 10;

      //act
      int end = count - start + 1;
      var nums = Enumerable.Range(start, end);

      //assert
      Assert.Equal(new int[] {0,1,2,3,4,5,6,7,8,9,10}, nums.ToArray());

    }


}