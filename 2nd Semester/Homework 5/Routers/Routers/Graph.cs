namespace Routers;

using Routers.Exceptions;

/// <summary>
/// Class that represents a graph.
/// </summary>
public class Graph
{
    private List<Edge> edges = new ();
    private Dictionary<int, Node> nodes = new ();

    /// <summary>
    /// Gets dictionary that contains nodes of the graph with the keys being their index numbers.
    /// </summary>
    public IReadOnlyDictionary<int, Node> Nodes { get; private set; } = new Dictionary<int, Node>();

    /// <summary>
    /// Gets list containing edges of the graph.
    /// </summary>
    public IReadOnlyList<Edge> Edges { get; private set; } = new List<Edge>();

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
        graph.edges.Sort();
        var tree = new Graph();
        var newEdges = new List<Edge>();
        foreach (var edge in graph.edges)
        {
            if (DisjointSet.Find(edge.Begin) != DisjointSet.Find(edge.End))
            {
                newEdges.Add(edge);
                DisjointSet.Union(edge.Begin, edge.End);
            }
        }

        tree.edges = newEdges;
        tree.Edges = tree.edges;
        tree.nodes = graph.nodes;
        tree.Nodes = tree.nodes;
        foreach (var node in tree.nodes)
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
        foreach (var node in nodes)
        {
            visitedNodes.Add(node.Value, false);
        }

        return DepthFirstSearch(nodes[1], visitedNodes) == nodes.Count;
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
        using var streamReader = new StreamReader(File.OpenRead(path));
        string? line = string.Empty;
        while ((line = streamReader.ReadLine()) != null)
        {
            int routerNumber = int.Parse(line[0].ToString());
            nodes.Add(routerNumber, new Node(routerNumber));
        }

        for (int i = 1; i < MaxNodeNumber(); i++)
        {
            if (!nodes.ContainsKey(i))
            {
                nodes.Add(i, new Node(i));
            }
        }

        streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
        while ((line = streamReader.ReadLine()) != null)
        {
            int routerNumber = int.Parse(line[0].ToString());
            GetEdgesFromFile(line, routerNumber);
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

            if (number > nodes.Count || routerNumber > nodes.Count)
            {
                while (nodes.Count < number || nodes.Count < routerNumber)
                {
                    nodes.Add(nodes.Count + 1, new Node(nodes.Count + 1));
                }
            }

            var capacityToPut = array[i + 1].Where(c => char.IsDigit(c)).ToArray();
            var newEdge = new Edge(int.Parse(capacityToPut), nodes[routerNumber], nodes[number]);
            nodes[routerNumber].ConnectedEdges.Add(newEdge);
            nodes[number].ConnectedEdges.Add(newEdge);
            edges.Add(newEdge);
        }
    }

    private int MaxNodeNumber()
    {
        int max = 0;
        foreach (var node in nodes)
        {
            if (node.Key > max)
            {
                max = node.Key;
            }
        }

        return max;
    }
}
