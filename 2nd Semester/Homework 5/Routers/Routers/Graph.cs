namespace Routers;

internal class Graph
{
    internal List<Edge> Edges { get; set; } = new ();

    internal List<Node> Nodes { get; set; } = new ();

    private readonly List<List<int>> matrix = new ();

    internal static Graph MakeMinimalTree(string path)
    {
        var graph = new Graph();
        graph.FillMatrix(path);
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
        tree.Nodes = graph.Nodes;
        tree.Edges = newEdges;
        return tree;
    }

    private void FillMatrix(string path)
    {
        using (var streamReader = new StreamReader(File.OpenRead(path)))
        {
            string? line = string.Empty;
            while ((line = streamReader.ReadLine()) != null)
            {
                int routerNumber = int.Parse(line[0].ToString());
                Nodes.Add(new Node(routerNumber));
            }

            streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            while ((line = streamReader.ReadLine()) != null)
            {
                int routerNumber = int.Parse(line[0].ToString()) - 1;
                matrix.Add(GetEdgesFromFile(line, routerNumber));
            }
        }

        var visitedNodes = new Dictionary<Node, bool>();
        foreach (var node in Nodes)
        {
            visitedNodes.Add(node, false);
        }

        if (CheckForConnectivity(Nodes[0], visitedNodes) != Nodes.Count)
        {
            throw new NotImplementedException();
        }
    }

    private int CheckForConnectivity(Node originalNode, Dictionary<Node, bool> visitedNodes)
    {
        int visitedNodesAmount = 1;
        visitedNodes[originalNode] = true;
        foreach (var node in Nodes)
        {
            if (!visitedNodes[node])
            {
                visitedNodesAmount += CheckForConnectivity(node, visitedNodes);
            }
        }

        return visitedNodesAmount;
    }

    private List<int> GetEdgesFromFile(string line, int routerNumber)
    {
        string[] array = line.Split(" ");
        var result = new List<int>();
        for (int i = 0; i < Nodes.Count + 1; i++)
        {
            result.Add(0);
        }

        for (int i = 1; i < array.Length; i += 2)
        {
            if (!int.TryParse(array[i], out int number))
            {
                throw new ArgumentException(nameof(line));
            }

            if (number > Nodes.Count)
            {
                while (Nodes.Count < number)
                {
                    Nodes.Add(new Node(Nodes.Count + 1));
                }
            }

            var capacityToPut = array[i + 1].Where(c => char.IsDigit(c)).ToArray();
            result.Insert(number - 1, int.Parse(capacityToPut));
            Edges.Add(new Edge(int.Parse(capacityToPut), Nodes[routerNumber], Nodes[number - 1]));
        }

        return result;
    }
}
