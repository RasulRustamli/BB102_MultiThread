using System.Diagnostics;

namespace MultiTask
{
    internal class Program
    {
        static  void Main(string[] args)
        {
            //GetHtttpContext();
            //GetHttpContextAsync().Wait();
        }
        public async static Task GetHttpContextAsync()
        {
            Stopwatch sw = new Stopwatch();
            var tasks=new List<Task<string>>();
            sw.Start();
            
            foreach (var item in GetUrls())
            {
                HttpClient clint = new HttpClient();
                tasks.Add(clint.GetStringAsync(item));
            }
            await Task.WhenAll(tasks);
            foreach (var item in tasks)
            {
                Console.WriteLine(item.Result.Length);
            }

            sw.Stop();
            
        }
        public static void GetHtttpContext()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var item in GetUrls())
            {
                HttpClient clint = new HttpClient();
                var result = clint.GetStringAsync(item).Result;
                Console.WriteLine(item +"->>" + result.Length);
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
        public static string[] GetUrls()
        {
            return new string[]
            {
                "https://dotnet.microsoft.com/en-us/",
                "https://dotnet.microsoft.com/en-us/learntocode",
                "https://dotnet.microsoft.com/en-us/learn/dotnet/what-is-dotnet",
                "https://dotnet.microsoft.com/en-us/download",
                "https://dotnet.microsoft.com/en-us/platform/community",
                "https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?WT.mc_id=dotnet-35129-website&view=aspnetcore-7.0"
            };
        }

    }
}