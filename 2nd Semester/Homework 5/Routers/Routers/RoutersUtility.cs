namespace Routers;

using System.Text;

/// <summary>
/// Utility to work with router networks.
/// </summary>
public static class RoutersUtility
{
    /// <summary>
    /// Makes configuration with maximum carrying capacity and minimum amount of connections.
    /// </summary>
    /// <param name="path">Path to the input file.</param>
    public static void MakeConfiguration(string path)
    {
        var tree = Graph.MakeMinimalTree(path);
        var newPath = path.Replace(Path.GetFileNameWithoutExtension(path), "output");

        using var writer = new StreamWriter(newPath);
        var visitedEdges = new List<Edge>();
        foreach (var node in tree.Nodes)
        {
            var line = new StringBuilder($"{node.Key}: ");
            foreach (var connectedEdge in node.Value.ConnectedEdges)
            {
                if (!visitedEdges.Contains(connectedEdge))
                {
                    visitedEdges.Add(connectedEdge);
                    line.Append(connectedEdge.Begin.Number == node.Key ? connectedEdge.End.Number : connectedEdge.Begin.Number);
                    line.Append($" ({connectedEdge.Capacity}) ");
                }
            }

            if (line.Length != $"{node.Value.Number}: ".Length)
            {
                writer.WriteLine(line);
            }
        }
    }
}
