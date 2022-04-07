

# SBootstrapper - Easy Updating

A 100% Free project made for developers to keep their project updated for al users!


## Authors

- [@Olivier Flentge](https://github.com/sympact06)


## Installation

You can download the .dll files that are required at the "releases" tab. Add them to a .NET 6 Console project.

### How to add the .dll as package/dependency
That is pretty easy. Just go the the "Dependencies" tab in your Solution Explorer and add Newton.json and SBootstrapperHandler to it.

### Program.cs 
As program.cs (your main file) you need to add a few lines to let our program work.

First you should include it at the top of your file with:
```csharp
using SBootstrapperHandler;
```

Then you should add it as a function library with:
```csharp
SBootstrapperLib SBootstrapper = new SBootstrapperLib();
```

The only thing you need to do now is use this function at `    static void Main(string[] args)
`
```csharp
SBootstrapper.Init(string VersionURL, string AppURL, string Author, string ExecutableFile);
```

### Example program.cs 
```csharp
using SBootstrapperHandler;
namespace MyApp
{
internal class Program
{
    static void Main(string[] args)
    {
        SBootstrapperLib SBootstrapper = new SBootstrapperLib();
        SBootstrapper.Init(string VersionURL, string AppURL, string Author, string ExecutableFile);
    }
}
}
```
