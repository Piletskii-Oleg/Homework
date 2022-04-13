namespace Routers;

using Routers.Exceptions;

/// <summary>
/// Class that represents a graph.
/// </summary>
public class Graph
{
    /// <summary>
    /// Gets list containing edges of the graph.
    /// </summary>
    public List<Edge> Edges { get; private set; } = new ();

    /// <summary>
    /// Gets dictionary that contains nodes of the graph with the keys being their index numbers.
    /// </summary>
    public Dictionary<int, Node> Nodes { get; private set; } = new ();

    /// <summary>
    /// Creates minimum spanning tree from a graph.
    /// </summary>
    /// <param name="path">Path to the input file.</param>
    /// <returns>Minimum spanning tree.</returns>
    /// <exception cref="GraphNotConnectedException">Throws if the graph was not connected.</exception>
    /// <exception cref="ArgumentException">Throws if the input was not in correct form.</exception>
    public static Graph MakeMinimalTree(string path)
    {
        var graph = new Graph();
        graph.FillEdgesAndNodes(path);
        graph.Edges.Sort();
        var tree = new Graph();
        var newEdges = new List<Edge>();
        foreach (var edge in graph.Edges)
        {
            if (DisjointSet.Find(edge.Begin) != DisjointSet.Find(edge.End))
            {
                newEdges.Add(edge);
                DisjointSet.Union(edge.Begin, edge.End);
            }
        }

        tree.Edges = newEdges;
        tree.Nodes = graph.Nodes;
        foreach (var node in tree.Nodes)
        {
            node.Value.ConnectedEdges = new List<Edge>();
            foreach (var edge in newEdges)
            {
                if (edge.Begin.Equals(node.Value) || edge.End.Equals(node.Value))
                {
                    node.Value.ConnectedEdges.Add(edge);
                }
            }
        }

        return tree;
    }

    private bool CheckForConnectivity()
    {
        var visitedNodes = new Dictionary<Node, bool>();
        foreach (var node in Nodes)
        {
            visitedNodes.Add(node.Value, false);
        }

        if (DepthFirstSearch(Nodes[1], visitedNodes) == Nodes.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private int DepthFirstSearch(Node originalNode, Dictionary<Node, bool> visitedNodes)
    {
        int visitedNodesAmount = 1;
        visitedNodes[originalNode] = true;
        foreach (var edge in originalNode.ConnectedEdges)
        {
            if (!visitedNodes[edge.Begin])
            {
                visitedNodesAmount += DepthFirstSearch(edge.Begin, visitedNodes);
            }
            else if (!visitedNodes[edge.End])
            {
                visitedNodesAmount += DepthFirstSearch(edge.End, visitedNodes);
            }
        }

        return visitedNodesAmount;
    }

    private void FillEdgesAndNodes(string path)
    {
        using (var streamReader = new StreamReader(File.OpenRead(path)))
        {
            string? line = string.Empty;
            while ((line = streamReader.ReadLine()) != null)
            {
                int routerNumber = int.Parse(line[0].ToString());
                Nodes.Add(routerNumber, new Node(routerNumber));
            }

            for (int i = 1; i < MaxNodeNumber(); i++)
            {
                if (!Nodes.ContainsKey(i))
                {
                    Nodes.Add(i, new Node(i));
                }
            }

            streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            while ((line = streamReader.ReadLine()) != null)
            {
                int routerNumber = int.Parse(line[0].ToString());
                GetEdgesFromFile(line, routerNumber);
            }
        }

        if (!CheckForConnectivity())
        {
            throw new GraphNotConnectedException();
        }
    }

    private void GetEdgesFromFile(string line, int routerNumber)
    {
        string[] array = line.Split(" ");

        for (int i = 1; i < array.Length; i += 2)
        {
            if (!int.TryParse(array[i], out int number))
            {
                throw new ArgumentException("Input was not in correct form");
            }

            if (number > Nodes.Count || routerNumber > Nodes.Count)
            {
                while (Nodes.Count < number || Nodes.Count < routerNumber)
                {
                    Nodes.Add(Nodes.Count + 1, new Node(Nodes.Count + 1));
                }
            }

            var capacityToPut = array[i + 1].Where(c => char.IsDigit(c)).ToArray();
            var newEdge = new Edge(int.Parse(capacityToPut), Nodes[routerNumber], Nodes[number]);
            Nodes[routerNumber].ConnectedEdges.Add(newEdge);
            Nodes[number].ConnectedEdges.Add(newEdge);
            Edges.Add(newEdge);
        }
    }

    private int MaxNodeNumber()
    {
        int max = 0;
        foreach (var node in Nodes)
        {
            if (node.Key > max)
            {
                max = node.Key;
            }
        }

        return max;
    }
}
