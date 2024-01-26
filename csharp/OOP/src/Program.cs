public class A {
 static A() {
   Console.WriteLine("A static");

 }

 /*
 public A() {
   Console.WriteLine("A non-static");
  }
  */
}

public class B : A {
  static B() {
    Console.WriteLine("B static");
  }

  /*
  public B() {
    Console.WriteLine("B non-static");
  }
  */
}

public class Program {
  public static void Main(string[] args) {
    B b = new B();
    B z = new B();
    Console.WriteLine("Hello world");
  }
}


