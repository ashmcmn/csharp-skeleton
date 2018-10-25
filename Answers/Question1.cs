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
            int maxValue = 0;
            for (int i = 0; i < portfolios.Length; i++)
            {
                for (int j = 0; j < portfolios.Length; j++)
                {
                    if (MergePortfolio(portfolios[i], portfolios[j]) > maxValue)
                    {
                        MergePortfolio(portfolios[i], portfolios[j]);
                    }
                }
            }

            return maxValue;
        }

        private static int MergePortfolio(int p0, int p1)
        {
            string b0 = Convert.ToString(p0, 2);
            string b1 = Convert.ToString(p1, 2);
            string merged = "";
            for (int i = 0; i < 16; i++)
            {
                if (b0[i] == '0' && b1[i] == '0')
                {
                    merged += '0';
                }
                else if (b0[i] == '1' ^ b1[i] == '1')
                {
                    merged += 1;
                }
                else
                {
                    merged += '0';
                }
            }

            return Convert.ToInt32(merged, 2);
        }
    }
}
