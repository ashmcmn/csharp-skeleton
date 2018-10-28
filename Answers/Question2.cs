using System;
using System.Collections.Generic;
using System.Linq;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question2
    {
        public static int Answer(int[] cashflowIn, int[] cashflowOut)
        {
            List<IEnumerable<int>> inSets = Subsets(cashflowIn.ToList()).Where(x => x.Count() != 0).ToList();
            List<IEnumerable<int>> outSets = Subsets(cashflowOut.ToList()).Where(x => x.Count() != 0).ToList();
            
            int minDiff = Math.Abs(inSets.ElementAt(0).Sum() - outSets.ElementAt(0).Sum());
            
            foreach (var set in inSets)
            {
                foreach (var set2 in outSets)
                {
                    if (Math.Abs(set.Sum() - set2.Sum()) < minDiff)
                    {
                        minDiff = Math.Abs(set.Sum() - set2.Sum());
                        
                    }
                }
            }

            return minDiff;
        }
        
        public static IEnumerable<IEnumerable<T>> Subsets<T>(IEnumerable<T> source)
        {
            List<T> list = source.ToList();
            int length = list.Count;
            int max = (int)Math.Pow(2, list.Count);

            for (int count = 0; count < max; count++)
            {
                List<T> subset = new List<T>();
                uint rs = 0;
                while (rs < length)
                {
                    if ((count & (1u << (int)rs)) > 0)
                    {
                        subset.Add(list[(int)rs]);
                    }
                    rs++;
                }
                yield return subset;
            }
        }
    }
}
