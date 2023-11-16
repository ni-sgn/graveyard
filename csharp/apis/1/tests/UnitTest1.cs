using System.Text;

namespace test;

public class UnitTest1 {
    [Fact]
    public void Test1() {
      Assert.Equal(1,2);
    }

    [Fact]
    public void Test2() {
      StringBuilder sb = new StringBuilder();
      Assert.Equal(1,1);
    }
}
