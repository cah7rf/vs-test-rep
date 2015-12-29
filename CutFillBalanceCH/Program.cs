namespace CutFillBalanceCH
{
    using System;
    using CutFillBalanceCH.Model;
    using System.Diagnostics;
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            Parameters parameters = new Parameters(args);

            if (parameters.IsValid)
            {
                
                Console.WriteLine("Cut File: {0}", parameters.CutFile);
                Console.WriteLine("Fill File: {0}", parameters.FillFile);
                Console.WriteLine("Output File: {0}", parameters.OutputFile);
                new AppRunner().Run(parameters);
                sw.Stop();
                Console.WriteLine("Total Time: {0:0.00} milliseconds", sw.ElapsedMilliseconds);
            }
            else
            {
                Console.WriteLine("Execution Failed!");
            }

        }
    }
}
