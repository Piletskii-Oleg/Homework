namespace Routers;

internal class Graph
{
    private List<Edge> edges = new ();

    private List<Node> nodes = new ();

    private List<List<int>> matrix = new ();

    public void FillMatrix(string path)
    {
        using (var streamReader = new StreamReader(File.OpenRead(path)))
        {
            string line = string.Empty;
            while ((line = streamReader.ReadLine()) != null)
            {
                int routerNumber = int.Parse(line[0].ToString()) - 1;
                nodes.Add(new Node(routerNumber));
            }

            streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            while ((line = streamReader.ReadLine()) != null)
            {
                int routerNumber = int.Parse(line[0].ToString()) - 1;
                matrix.Add(GetEdgesFromFile(line, routerNumber));
            }
        }

        if (!CheckForConnectivity())
        {
            throw new NotImplementedException();
        }
    }

    public Graph MakeMinimalTree()
    {
        edges.Sort();
        var tree = new Graph();
        var newEdges = new List<Edge>();
        foreach (var edge in edges)
        {
            if (DisjointSet.Find(edge.Begin) != DisjointSet.Find(edge.End))
            {
                newEdges.Add(edge);
                DisjointSet.Union(edge.Begin, edge.End);
            }
        }
        tree.nodes = this.nodes;
        tree.edges = newEdges;
        return tree;
    }

    private bool CheckForConnectivity()
    {
        return true;
    }

    private List<int> GetEdgesFromFile(string line, int routerNumber)
    {
        string[] array = line.Split(" ");
        var result = new List<int>();
        for (int i = 0; i < nodes.Count + 1; i++)
        {
            result.Add(0);
        }

        for (int i = 1; i < array.Length; i += 2) // [1:], [2], [(10),], [3], [(5)]
        {
            if (!int.TryParse(array[i], out int number))
            {
                throw new ArgumentException();
            }

            if (number > nodes.Count)
            {
                while (nodes.Count < number)
                {
                    nodes.Add(new Node(nodes.Count));
                }
            }

            var capacityToPut = array[i + 1].Where(c => char.IsDigit(c)).ToArray();
            result.Insert(number - 1, int.Parse(capacityToPut));
            edges.Add(new Edge(int.Parse(capacityToPut), nodes[routerNumber], nodes[number - 1]));
        }

        return result;
    }
}
