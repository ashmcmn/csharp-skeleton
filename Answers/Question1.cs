using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question1
    {
        public static int Answer(int[] portfolios)
        {
            var maxValue = 0;
            for (var i = 0; i < portfolios.Length; i++)
            {
                for (var j = 0; j < portfolios.Length; j++)
                {
                    int xor = portfolios[i] ^ portfolios[j];
                    if (xor > maxValue)
                    {
                        maxValue = xor;
                    }
                }
            }

            return maxValue;
        }
    }
}
