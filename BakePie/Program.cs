﻿using System;
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
            bool fillingFinished;
            Crust crust;
            crust = PrepareCrust();

            Task<bool> futureCrust = Task.Factory.StartNew<bool>(() => BakeCrust(crust)); 

            BakeCrust(crust);

            fillingFinished = PrepareFilling();

            FinishPie(futureCrust.Result, fillingFinished);


        }

        private static void FinishPie(bool crustFinished, bool fillingFinished)
        {
            if (crustFinished == false || fillingFinished == false)
            {
                throw new ArgumentException("Both crust and filling must be finished to finish pie!");
            }
            
        }

        private static bool PrepareFilling()
        {

            Thread.Sleep(5000);
            return true;
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