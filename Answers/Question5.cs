using System;
using System.Linq;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question5
    {
        public static int Answer(int[] numOfShares, int totalValueOfShares)
        {

            var numOfShares2 = numOfShares.ToList();
            int count = 1;
            while (calSets(totalValueOfShares, numOfShares2.ToArray()) == 0)
            {
                for (int i = 0; i < numOfShares.Length; i++)
                {
                    numOfShares2.Add(numOfShares[i]);
                }

                count++;
            }

            return count;
        }
        
        static int[,] costs;
    
        static int[,] minItems;
    
        public static int calSets(int target, int[] arr) {
            costs = new int[arr.Length, target + 1];
            minItems = new int[arr.Length, target + 1];
            for (int j = 0; (j <= target); j++) {
                if ((arr[0] <= j)) {
                    costs[0, j] = arr[0];
                    minItems[0, j] = 1;
                }
            
            }
        
            for (int i = 1; (i < arr.Length); i++) {
                for (int j = 0; (j <= target); j++) {
                    costs[i, j] = costs[(i - 1), j];
                    minItems[i, j] = minItems[(i - 1), j];
                    if ((arr[i] <= j)) {
                        costs[i, j] = Math.Max(costs[i, j], (costs[(i - 1), (j - arr[i])] + arr[i]));
                        if ((costs[(i - 1), j] 
                             == (costs[(i - 1), (j - arr[i])] + arr[i]))) {
                            minItems[i, j] = Math.Min(minItems[i, j], (minItems[(i - 1), (j - arr[i])] + 1));
                        }
                        else if ((costs[(i - 1), j] 
                                  < (costs[(i - 1), (j - arr[i])] + arr[i]))) {
                            minItems[i, j] = (minItems[(i - 1), (j - arr[i])] + 1);
                        }
                    
                    }
                
                }
            
            }
        
            if ((costs[(arr.Length - 1), target] == target))
            {
                return minItems[(arr.Length - 1), target];
            }
                return 0;
        
        }
    }
}