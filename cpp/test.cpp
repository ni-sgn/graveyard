#include <iostream>
#include <string>
#include <vector>
#include <fstream>

using namespace std;

class person {
  private:
    int age;
    string name;
  public:
    int getAge() {
      return age;
    }

    string getName() {
      return name;
    }

    person(int age, string name) {
      this->age = age;
      this->name = name;
    }

};


int main() {

  string file_name = "text.txt";
  ofstream ofile(file_name);

  ofile << "Hello world!"; 

  string text;

  ofile.close();

  ifstream ifile(file_name);

  while(getline(ifile, text)){
    cout << text;
  }

  ifile.close();

  person* nika = new person(1, "hello");
  cout << nika->getAge() << endl;

  return 0;
}
