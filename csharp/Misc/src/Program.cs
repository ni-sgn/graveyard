using static System.Console;

public class Program {
  public static void Main(string[] args) {
    int c = 0;

    byte a = 255; 
    checked {
    a++;
    }
    Console.WriteLine(a);

    
    Console.WriteLine(a);
    for (byte b = 0; b <= 255; b++) {
      Console.WriteLine($"{b}");
      c++;
    }

  }


 }

