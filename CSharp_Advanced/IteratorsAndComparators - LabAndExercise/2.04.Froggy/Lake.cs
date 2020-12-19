using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _2._04.Froggy
{
    class Lake : IEnumerable<int> 
    {
        private List<int> stones;

        public Lake(List<int> stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            List<int> evenPositions = new List<int>();
            List<int> oddPositions = new List<int>();
            for (int i = 0; i < this.stones.Count; i++)
            {
                if (i % 2 == 0)
                {
                    evenPositions.Add(this.stones[i]);
                }
                else
                {
                    oddPositions.Add(this.stones[i]);
                }
            }

            foreach (var item in evenPositions)
            {
                yield return item;
            }

            oddPositions.Reverse();
            foreach (var item in oddPositions)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

      
    }
}
