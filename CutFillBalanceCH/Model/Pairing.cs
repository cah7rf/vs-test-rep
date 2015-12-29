using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace CutFillBalanceCH.Model
{
    public class Pairing : IEnumerable<Pair>, IEnumerable
    {
        private IEnumerator<Pair> _enumerator;
        private readonly List<Pair> _pairings = new List<Pair>();

        public void Add(InputLine cut, InputLine fill)
        {
            Pair item = new Pair(cut, fill);
            this._pairings.Add(item);
        }

        public void AddAll(IList<InputLine> cuts, IList<InputLine> fills)
        {
            foreach (InputLine line in cuts)
            {
                foreach(InputLine line2 in fills)
                { 
                    this.Add(line, line2);
                }
            }
            Console.WriteLine("Total Pairs={0}", this._pairings.Count);
        }
        public IEnumerator<Pair> GetEnumerator()
        {
            if (this._enumerator == null)
            {
                this._enumerator = _pairings.GetEnumerator();
            }
            return this._enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
