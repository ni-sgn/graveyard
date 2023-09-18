using System;
using static System.Console;


public interface MockInterface {
  void PrintGreeting();
  int AddNumbers(int a, int b);
}

public class MockImplementation1 : MockInterface {
  public void PrintGreeting() {
    WriteLine("This is first implementation");
  }

  public int AddNumbers(int a, int b) {
    return a + b;  
  }
}

public class MockImplementation2 : MockInterface {
  public void PrintGreeting() {
    WriteLine("This is second implementation");
  }

  public int AddNumbers(int a, int b) {
    return a + b + 1;  
  }
}


public class Progam {
  public static void Main(string[] args) {
    MockInterface mocked = new MockImplementation1();
    MockInterface mockedAgain = new MockImplementation2();

    mocked.PrintGreeting();
    mockedAgain.PrintGreeting();
  } 
}