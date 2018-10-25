using System;
using System.Linq;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question2
    {
        public static int Answer(int[] cashflowIn, int[] cashflowOut)
        {
            return (FindMin(cashflowIn.Concat(cashflowOut).ToArray())-1);
        }

        static int FindMinRec(int[] arr, int i, int sumCalculated, int sumTotal) 
        { 

            if (i==0) 
                return Math.Abs((sumTotal-sumCalculated) - sumCalculated); 
  
            return Math.Min(FindMinRec(arr, i-1, sumCalculated+arr[i-1], sumTotal), 
                FindMinRec(arr, i-1, sumCalculated, sumTotal)); 
        } 
  
        static int FindMin(int[] arr)
        {
            var n = arr.Length;
            var sumTotal = 0; 
            for (var i=0; i<n; i++) 
                sumTotal += arr[i]; 
  
            return FindMinRec(arr, n, 0, sumTotal); 
        } 
    }
}