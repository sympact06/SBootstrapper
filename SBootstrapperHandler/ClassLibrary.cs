using Newtonsoft.Json;
using System.IO.Compression;
using System.Net;


namespace SBootstrapperHandler
{
    public class SBootstrapperLib
    {
        // Class Configuration
        private string version = "000ABBrO934xDE";




        public async void Init(string versionurl, string userdownloadurl, string authorname, string appexecutable)
        {
            string versionstring;
            DownloadFileAsync(versionurl, "version.txt");
            var vv = File.ReadAllLines("version.txt");
            versionstring = vv[0];
            File.Delete("version.txt");

            Console.WriteLine("© Olivierflentge.nl");
            Console.WriteLine("SBootstrapper Version " + version);

            Directory.CreateDirectory("TempData");

            // Version Check
            DownloadFileAsync("https://raw.githubusercontent.com/sympact06/SBootstrapper/master/version.json", "TempData//version.json");
            var versionjson = File.ReadAllText("Tempdata//version.json");
            dynamic versioncontent = JsonConvert.DeserializeObject<dynamic>(versionjson);

            if (versioncontent.version != version)
            {
                Console.WriteLine("Version is outdated or you are using a crack. Please update!");

                System.Threading.Thread.Sleep(10000);
                Environment.Exit(999);
            }
            Directory.Delete("TempData", true);
            Console.WriteLine("You are running on the current version!");

            // Check Configuration
            Console.WriteLine("Configuration is OK... Loading settings from " + authorname + " With Version " + versionstring);

            // Check User Version
            if (Directory.Exists("AppData"))
            {

            }
            else
            {
                Console.WriteLine("App is not installed... Installing!");
                Directory.CreateDirectory("AppData");
                File.Create("AppData//v.txt").Close();
                TextWriter tw = new StreamWriter("AppData//v.txt");
                tw.WriteLine(versionstring);
                tw.Close();
                UpdateApp();
            }

            // Checking for Updates
            var v = File.ReadAllLines("AppData//v.txt");
            if (versionstring != v[0])
            {
                Console.WriteLine("This is a old version of the app... Please give us some time to update...");
                UpdateApp();
            }

            Console.WriteLine("Done with checks... Have fun with the app!");
            System.Diagnostics.Process.Start("AppData//"+appexecutable);
            Task.WaitAll();
            System.Threading.Thread.Sleep(1000);
            Environment.Exit(999);





            void UpdateApp()
            {
                Directory.Delete("AppData", true);
                Directory.CreateDirectory("AppData");
                File.Create("AppData//v.txt").Close();
                TextWriter tw = new StreamWriter("AppData//v.txt");
                tw.WriteLine(versionstring);
                tw.Close();
                DownloadFileAsync(userdownloadurl, "AppData//App.zip");
                Task.WaitAll();
                ZipFile.ExtractToDirectory("AppData//App.zip", "AppData//");
                Task.WaitAll();
                File.Delete("AppData//App.zip");
            }

        }



        public async void DownloadFileAsync(string downloadurl, string path)
        {
#pragma warning disable SYSLIB0014 // Type or member is obsolete
            WebClient webclient = new();
#pragma warning restore SYSLIB0014 // Type or member is obsolete
            webclient.DownloadFile(downloadurl, path);

        }

    }
}