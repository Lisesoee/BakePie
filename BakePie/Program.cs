using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace BakePie
{
    class Program
    {
        static void Main(string[] args)
        {

            BakePie();
        }

        private static void BakePie()
        {
            var timer = new Stopwatch();
            Console.WriteLine("Baking pie...");
            timer.Start();

            bool fillingFinished;
            Crust crust;
            crust = PrepareCrust();

            Task<bool> futureCrust = Task.Factory.StartNew<bool>(() => BakeCrust(crust)); 

            BakeCrust(crust);

            Filling pieFilling = PrepareFilling();

            FinishPie(futureCrust.Result, crust, pieFilling);

            timer.Stop();

            TimeSpan timeTaken = timer.Elapsed;
            Console.WriteLine("Pie finished baking. Time taken: " + timeTaken.ToString(@"m\:ss\.fff"));

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
            Filling applePieFilling = new Filling(FillingType.Apple);
            applePieFilling.isDone = true;

            Thread.Sleep(5000);
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
