using System.Collections.Generic;
using System.Linq;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question4
    {
        public static int Answer(string[,] machineToBeFixed, int numOfConsecutiveMachines)
        {
            int dim = machineToBeFixed.GetLength(0);
            int max = 999;
            for (int i = 0; i < dim; i++)
            {
                var row = SliceRow(machineToBeFixed, i);
                if (dim - row.Count(x => x == "X") == numOfConsecutiveMachines)
                {
                    List<string> rowString = row.ToList();
                    rowString.RemoveAll(x => x == "X");
                    List<int> rowInt = rowString.Select(int.Parse).ToList();
                    if (rowInt.Sum() < max)
                    {
                        max = rowInt.Sum();
                    }
                }
            }

            if (max == 999) max = 0;
            return max;
        }
        
        public static IEnumerable<T> SliceRow<T>(T[,] array, int row)
        {
            for (var i = array.GetLowerBound(1); i <= array.GetUpperBound(1); i++)
            {
                yield return array[row, i];
            }
        }
    }
}