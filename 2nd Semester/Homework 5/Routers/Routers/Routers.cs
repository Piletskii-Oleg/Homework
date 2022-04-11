namespace Routers;

public static class Routers
{
    public static void MakeConfiguration(string path)
    {
        var tree = Graph.MakeMinimalTree(path);
        var newPath = path.Replace(Path.GetFileNameWithoutExtension(path),
            Path.GetFileNameWithoutExtension(path) + "-coherent");

        using (var writer = new StreamWriter(newPath))
        {
            var visitedNodes = new List<Node>();
            foreach (var edge in tree.Edges)
            {
                string line = edge.Begin.Number + ": ";
                line += $"{edge.End.Number} ({edge.Capacity})";
                writer.WriteLine(line);
            }
        }
    }
}
