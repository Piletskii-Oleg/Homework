namespace Routers;

public static class Routers
{
    public static void MakeConfiguration(string path)
    {
        var tree = Graph.MakeMinimalTree(path);
        var newPath = path.Replace(Path.GetFileNameWithoutExtension(path), "output");

        using var writer = new StreamWriter(newPath);
        var visitedEdges = new List<Edge>();
        foreach (var node in tree.Nodes)
        {
            string line = node.Number + ": ";
            foreach (var connectedEdge in node.ConnectedEdges)
            {
                if (!visitedEdges.Contains(connectedEdge))
                {
                    visitedEdges.Add(connectedEdge);
                    line += connectedEdge.Begin.Equals(node) ? $"{connectedEdge.End.Number}" : $"{connectedEdge.Begin.Number}";
                    line += $"({connectedEdge.Capacity}) ";
                }
            }

            if (line != $"{node.Number}: ")
            {
                writer.WriteLine(line);
            }
        }
    }
}
