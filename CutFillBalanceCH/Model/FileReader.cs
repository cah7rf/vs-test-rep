using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CutFillBalanceCH.Model;

namespace CutFillBalanceCH.Model
{
   public class FileReader
    {
  
       public IList<InputLine> ReadInputData(string filepath)
       {
           
          var reader = new StreamReader(File.OpenRead(filepath));
          IList<InputLine> inputData = new List<InputLine>();
          string line = reader.ReadLine();
           while (!reader.EndOfStream)
           {
               line = reader.ReadLine();
               InputLine temp = new InputLine();
               temp.Add(line);
               inputData.Add(temp);

           

           }
           return inputData;
       }
        

    }
}
