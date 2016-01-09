using System.Collections.Generic;
using System.IO;

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
