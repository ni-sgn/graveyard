
namespace Application;
public class Person {
    public int age;
    public string name;
    public Person(int age, string name) {
        this.age = age;
        this.name = name;
    }
}

// pipeline-shi 
[AttributeUsage(AttributeTargets.Class)]
public class CustomAttribute : Attribute {
    public CustomAttribute(int number) {
    }
}
