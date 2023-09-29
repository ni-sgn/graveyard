namespace tests;

public class list_remove_count 
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


    [Fact]
    public void Removing_element_from_array_reduces_count_for_list() {
      //arrange
      List<int> lst = new List<int>{1};

      //act
      int pre_count  = lst.Count;
      lst.RemoveAt(0);
      int post_count = lst.Count; 

      //assert
      Assert.Equal(pre_count, 1);
      Assert.Equal(post_count, 0);
      Assert.Equal(pre_count, post_count+1);
    }


}