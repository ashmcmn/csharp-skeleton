using System;
using System.Collections.Generic;
using System.Linq;
using C_Sharp_Challenge_Skeleton.Beans;
using QuickGraph;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question3
    {
        public static int Answer(int numOfNodes, Edge[] edgeLists)
        {
            List<AdjacencyGraph<int, Edge<int>>> graphs = new List<AdjacencyGraph<int, Edge<int>>>();
            List<List<int>> possibleSolutions = new List<List<int>>();

            List<int> nodes = new List<int>();
            for (int i = 1; i < numOfNodes + 1; i++)
            {
                nodes.Add(i);
            }
            
            foreach (var combo in GetAllCombos(nodes))
            {
                AdjacencyGraph<int, Edge<int>> graph = new AdjacencyGraph<int, Edge<int>>();
                foreach (var i in combo)
                {
                    graph.AddVertex(i);
                }
                foreach (var e in edgeLists)
                {
                    if (graph.ContainsVertex(e.EdgeA) && graph.ContainsVertex(e.EdgeB))
                    {
                        graph.AddEdge(new Edge<int>(e.EdgeA, e.EdgeB));
                    }
                }
                graphs.Add(graph);
            }
            
            AdjacencyGraph<int, Edge<int>> selectedGraph = new AdjacencyGraph<int, Edge<int>>();
            foreach (var graph in graphs.ToList())
            {
                if (graph.Edges.Any() || graph.VertexCount == 1)
                {
                    graphs.Remove(graph);
                }
                else
                {
                    Console.WriteLine(string.Join(", ", graph.Vertices));
                    if (graph.VertexCount > selectedGraph.VertexCount) selectedGraph = graph;
                }
            }
            
            int X = selectedGraph.VertexCount;
            int Y = numOfNodes - X;
            
            Console.WriteLine(X+ ", " + Y);
            return X - Y;
        }
        
        public static List<List<T>> GetAllCombos<T>(List<T> list)
        {
            List<List<T>> result = new List<List<T>>();
            result.Add(new List<T>());
            result.Last().Add(list[0]);
            if (list.Count == 1)
                return result;
            List<List<T>> tailCombos = GetAllCombos(list.Skip(1).ToList());
            tailCombos.ForEach(combo =>
            {
                result.Add(new List<T>(combo));
                combo.Add(list[0]);
                result.Add(new List<T>(combo));
            });
            return result;
        }
    }
}