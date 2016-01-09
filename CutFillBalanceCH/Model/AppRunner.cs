using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace CutFillBalanceCH.Model
{


    class AppRunner
    {
        private readonly FileReader _fileReader = new FileReader();
        
        public void Run(Parameters parameters)
        {
            Stopwatch sw = new Stopwatch();

            IList<InputLine> cuts = this._fileReader.ReadInputData(parameters.CutFile).ToList<InputLine>();
            Console.WriteLine("Total number of cut blocks loaded {0}", cuts.Count());
            IList<InputLine> fills = this._fileReader.ReadInputData(parameters.FillFile).ToList<InputLine>();
            Console.WriteLine("Total number of fill blocks loaded {0}", fills.Count());

            sw.Start();
            int i = 0;
            while (cuts.Count > 0 & fills.Count > 0)
            {
                
                i++;
                Runner runner = new Runner(ref cuts, ref fills);

                if ( i % 500 == 0)
                {
                    Console.WriteLine("Cut\t{0}\tFill\t{1}\t{2} Pairs Found", cuts.Count(),fills.Count(),i);
                }
            }

            sw.Stop();

            Console.WriteLine("Seconds Elapsed:{0}", (sw.ElapsedMilliseconds/1000));
        }
        
    
        }
}
