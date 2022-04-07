using System.Net;
using SBootstrapperHandler;

namespace SBootstrapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SBootstrapperLib SBootstrapper = new SBootstrapperLib();
            SBootstrapper.Init("https://raw.githubusercontent.com/sympact06/SBootstrapper/master/test.txt", "https://mirrorhosting.nl/images.zip", "Olivier Flentge","no.exe");

           

        }
    }
}