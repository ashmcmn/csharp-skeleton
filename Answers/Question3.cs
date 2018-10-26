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

                    List<int> nodes = Enumerable.Range(1, numOfNodes).ToList();
                    
                    int comboCount = (int) Math.Pow(2, nodes.Count) - 1;
                    List<List<int>> combos = new List<List<int>>();
                    for (int i = 1; i < comboCount + 1; i++)
                    {
                        combos.Add(new List<int>());
                        for (int j = 0; j < nodes.Count; j++)
                        {
                            if ((i >> j) % 2 != 0)
                                combos.Last().Add(nodes[j]);
                        }
                    }
                    
                    
                    for (var index = 0; index < combos.Count; index++)
                    {
                        var combo = combos[index];
                        AdjacencyGraph<int, Edge<int>> graph = new AdjacencyGraph<int, Edge<int>>();
                        for (var index1 = 0; index1 < combo.Count; index1++)
                        {
                            var i = combo[index1];
                            graph.AddVertex(i);
                        }

                        bool dontAdd = false;
                        for (var i = 0; i < edgeLists.Length; i++)
                        {
                            var e = edgeLists[i];
                            if (graph.ContainsVertex(e.EdgeA) && graph.ContainsVertex(e.EdgeB))
                            {
                                dontAdd = true;
                            }
                        }

                        if (!dontAdd)
                        {
                            graphs.Add(graph);
                        }
                        
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
                            if (graph.VertexCount > selectedGraph.VertexCount) selectedGraph = graph;
                        }
                    }

                    int X = selectedGraph.VertexCount;
                    int Y = numOfNodes - X;
                    
                    return X - Y;
                }
    }
}