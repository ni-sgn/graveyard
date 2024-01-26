using System.Collections;

public class Program {
  public static void Main(string[] args) {
  }
}



public class A : IEnumerable<int> {

  public  IEnumerator<int> GetEnumerator() {
    throw new NotImplementedException();
  }

  IEnumerator IEnumerable.GetEnumerator() {
    throw new NotImplementedException();
  }
  
}

