using System;
using System.Diagnostics;
using System.IO;

namespace JSONProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            var jsonPath = "json.json";
            var loopsToAverage = 10;
            var jsonFileText = File.ReadAllText(jsonPath);

            Console.WriteLine("Executing newtonsoft loop");
            stopwatch.Start();

            for(int i = 0; i < loopsToAverage; i++)
            {
                var newtonsoftLoadedJson = Newtonsoft.Json.JsonConvert.DeserializeObject<object>(jsonFileText);
            }

            stopwatch.Stop();
            Console.WriteLine($"Newtonsoft elapsed seconds = {stopwatch.Elapsed.TotalSeconds}");
            stopwatch.Reset();

            Console.WriteLine("Executing System.text.json loop");
            stopwatch.Start();

            for (int i = 0; i < loopsToAverage; i++)
            {
                var systemLoadedJson = System.Text.Json.JsonSerializer.Deserialize<object>(jsonFileText);
            }

            stopwatch.Stop();
            Console.WriteLine($"System elapsed seconds = {stopwatch.Elapsed.TotalSeconds}");
        }
    }
}
