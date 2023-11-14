using RestSharp;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace BakePie
{
    class Program
    {
        private static RestClient restClient = new RestClient("http://xxxfillingservice/XxxFillingService/"); // TODO: url

        static void Main(string[] args)
        {

            BakePie();
        }

        private static void BakePie()
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

            timer.Stop();

            TimeSpan timeTaken = timer.Elapsed;
            Console.WriteLine("Pie finished baking. Filling = " + pieFilling.FillingType +". Time taken: " + timeTaken.ToString(@"m\:ss\.fff"));

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
            var task = restClient.GetAsync<Filling>(new RestRequest("/filling")); // TODO: URL

            // If we cannot get our favorite filling, then use apple filling instead...
            Filling applePieFilling = new Filling(FillingType.Apple);
            Thread.Sleep(5000);

            if (task.Status == TaskStatus.RanToCompletion)
            {
                pieFilling = task.Result;
            } else
            {
                pieFilling = applePieFilling;
            }

            pieFilling.isDone = true;

            return applePieFilling;
        }

        private static bool BakeCrust(Crust crust)
        {            
            Thread.Sleep(7000);
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
