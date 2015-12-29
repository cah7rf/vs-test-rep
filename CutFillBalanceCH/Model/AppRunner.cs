using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CutFillBalanceCH;

namespace CutFillBalanceCH.Model
{
    
    
    class AppRunner
    {
        private readonly FileReader _fileReader = new FileReader();
        
        public void Run(Parameters parameters)
        {
            
            IList<InputLine> cuts = this._fileReader.ReadInputData(parameters.CutFile).ToList<InputLine>();
            Console.WriteLine("Total number of cut blocks loaded {0}", cuts.Count());
            IList<InputLine> fills = this._fileReader.ReadInputData(parameters.FillFile).ToList<InputLine>();
            Console.WriteLine("Total number of fill blocks loaded {0}", fills.Count());
            Runner runner = new Runner(ref cuts, ref fills);

            

        }
        
    
        }
}
