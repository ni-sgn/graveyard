
#Folder structure 
$/
    artifacts/
    build/
    docs/
    packages/
    samples/
    src/
    tests/
    .editorconfig
    .gitignore
    .gitattributes
    LICENSE
    NuGet.Config
    README.md
    {solution}.sln
    ...


    src - Contains the actual source code for the application (the various projects with their classes etc.)
    tests - Contains unit test projects
    docs - Contains documentation files
    samples - This is where you would place files that provide examples to users on how to use your code or library
    artifacts - Build outputs go here
    packages - Contains NuGet packages
    build - Contains build customization scripts

#Talking about naming conventions, there isn't an actual standard; some common practices include:
    CompanyName.ProductName.Component (eg. MyCompany.MyApplication.DataAccess)
    CompanyName.Component (eg. MyCompany.Math)
    ProductName.Component (eg. MyApplication.Models)

#Separate functionality with projects
$/
  MyApplication.sln
  src/
    MyApplication.UI/
      MyApplication.UI.csproj

    MyApplication.Math/
      MyApplication.Math.csproj

    MyApplication.Business/
      MyApplication.Business.csproj

    MyApplication.DataAccess/
      SqlServer/
        SqlServerRepository.cs
      Mock/
        MockRepository.cs
      IRepository.cs
      MyApplication.DataAccess.csproj

#Unit tests organization
$/
  MyApplication.sln
  src/
    MyApplication.Math/
      Calculator.cs
      MyApplication.Math.csproj
      Utilities/
        MathUtilities.cs

  tests/
    MyApplication.Math.Tests/
      CalculatorTests.cs
      MyApplication.Math.Tests.csproj
      Utilities/
        MathUtilitiesTests.cs
