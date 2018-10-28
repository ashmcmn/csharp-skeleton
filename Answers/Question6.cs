using System;
using System.Collections.Generic;
using System.Linq;
using QuickGraph;
using QuickGraph.Algorithms;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question6
    {
        static AdjacencyGraph<int, Edge<int>> graph = new AdjacencyGraph<int, Edge<int>>();
        static Dictionary<Edge<int>, double> costs = new Dictionary<Edge<int>, double>();
        
        public static int Answer(int numOfServers, int targetServer, int[,] connectionTimeMatrix)
        {
            for (int i = 0; i < connectionTimeMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < numOfServers; j++)
                {
                    var edge = new Edge<int>(i, j);
                    graph.AddVerticesAndEdge(edge);
                    costs.Add(edge, connectionTimeMatrix[i,j]);
                }
            }
            
            var edgeCost = AlgorithmExtensions.GetIndexer(costs);
            var tryGetPath = graph.ShortestPathsDijkstra(edgeCost, 0);

            IEnumerable<Edge<int>> path;
            tryGetPath(targetServer, out path);

            double cost = 0;
            foreach (var edge in path)
            {
                cost += costs[edge];
            }

            return Convert.ToInt32(cost);
        }
    }
}
