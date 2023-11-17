using FeatureHubSDK;
using RestSharp;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
//using FeatureHubSDK;

namespace BakePie
{
    class Program
    {
        //private static RestClient restClient = new RestClient("https://localhost:7042/RhubarbFillingService/");
        private static RestClient restClient = new RestClient("http://rhubarbfillingservice/RhubarbFillingService/");

        static void Main(string[] args)
        {
            BakePie();
            //Task bakePie = Task.Factory.StartNew (() => BakePie());
            //bakePie.Wait();
        }

        private static async void BakePie()
        {
            var timer = new Stopwatch();
            Console.WriteLine("Baking pie...");
            timer.Start();

            Crust crust;
            crust = PrepareCrust();

            Task<bool> futureCrust = Task.Factory.StartNew<bool>(() => BakeCrust(crust)); 

            BakeCrust(crust);

            Filling pieFilling = PrepareFilling();

            FinishPie(futureCrust.Result, crust, pieFilling);

            FeatureLogging.DebugLogger += (sender, s) => Console.WriteLine("DEBUG: " + s);
            FeatureLogging.TraceLogger += (sender, s) => Console.WriteLine("TRACE: " + s);
            FeatureLogging.InfoLogger += (sender, s) => Console.WriteLine("INFO: " + s);
            FeatureLogging.ErrorLogger += (sender, s) => Console.WriteLine("ERROR: " + s);
            var config = new EdgeFeatureHubConfig("http://featurehub:8085", "40a04c7d-6931-4203-8ac9-92ddd216afdb/6K4jw7EO7eWCZ4wNQjHdbkbix5xqKCPkFFjZlaze");
            var fh = await config.NewContext().Build();
            var shouldAddSprinkles = fh["AddSprinklesToPie"].IsEnabled;
            Console.WriteLine(shouldAddSprinkles);

            await Task.Run(() =>
            {
                if (shouldAddSprinkles)
                {
                    AddSprinklesToPie();
                }
            });
           

            timer.Stop();

            TimeSpan timeTaken = timer.Elapsed;
            Console.WriteLine("Pie finished baking. Filling = " + pieFilling.FillingType +". Time taken: " + timeTaken.ToString(@"m\:ss\.fff"));

        }

        private static void AddSprinklesToPie()
        {
            Console.WriteLine("Added sprinkles to pie!");
        }

        private static void FinishPie(bool crustFinished, Crust crust, Filling pieFilling)
        {
            if (crustFinished == false || pieFilling.isDone == false)
            {
                throw new ArgumentException("Both crust and filling must be finished to finish pie!");
            }

            crust.pieFilling = pieFilling;
        }

        private static Filling PrepareFilling()
        {
            // Try to get your favorite filling using a "fire-and-hope" approach
            Filling pieFilling;
            var task = restClient.GetAsync<Filling>(new RestRequest("/")); // TODO: URL

            // If we cannot get our favorite filling, then use default filling instead...
            Filling applePieFilling = new Filling(FillingType.Apple);
            Thread.Sleep(2000);
            applePieFilling.isDone = true;

            if (task.Status == TaskStatus.RanToCompletion)
            {
                pieFilling = task.Result;
            } else
            {
                pieFilling = applePieFilling;
            }            

            return pieFilling;
        }

        private static bool BakeCrust(Crust crust)
        {            
            Thread.Sleep(4000);
            crust.IsDone = true;
            return true;
        }

        private static Crust PrepareCrust()
        {
            Crust tmp = new Crust();
            return tmp;
        }
    }
}
