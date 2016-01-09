using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace CutFillBalanceCH.Model
{
    class Runner
    {
        
        public Runner(ref IList<InputLine> cuts, ref IList<InputLine> fills)
        {
            Stopwatch sw = new Stopwatch();

            double minDistance = 1e30;
            InputLine closestCut = new InputLine();
            InputLine closestFill = new InputLine();

            sw.Start();
            KDTree.KDTree<InputLine> cutTree = new KDTree.KDTree<InputLine>(3);
            for (int i = 0; i < cuts.Count(); i++)
            {
                cutTree.AddPoint(new double[] { cuts[i].X, cuts[i].Y, cuts[i].Z }, cuts[i]);
            }
            sw.Stop();
            //Console.WriteLine("Tree Created in {0:0.00} milliseconds", sw.ElapsedMilliseconds);


            sw.Reset();
            sw.Start();
            for (int j = 0; j < fills.Count(); j++)
            {
                var pIter = cutTree.NearestNeighbors(new double[] { fills[j].X, fills[j].Y, fills[j].Z }, 1);

                while (pIter.MoveNext())
                {
                    InputLine pCurrent = pIter.Current;
                    double currentDistance = new double();
                    currentDistance = pCurrent.Distance(fills[j]);

                    if (currentDistance < minDistance)
                    {
                        minDistance = currentDistance;
                        closestCut = pCurrent;
                        closestFill = fills[j];

                    }
                }
            }

            if (closestCut.TotalVolume>closestFill.TotalVolume)
            {
                fills.Remove(closestFill);
            }
            else
            {
                cuts.Remove(closestCut);
            }
            

            sw.Stop();
            //Console.WriteLine("Nearest Neighbor Found in {0:0.00} milliseconds", sw.ElapsedMilliseconds);


            //Console.WriteLine("Closet Points are {0} units appart", Math.Sqrt(minDistance));
            //Console.WriteLine("Closet Points Cut:{0}, Fill:{1}", closestCut, closestFill);
        }
        
        
        
    }
}
