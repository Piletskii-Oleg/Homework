namespace Routers;

using System.Text;
using Routers.Exceptions;

/// <summary>
/// Utility to work with router networks.
/// </summary>
public static class RoutersUtility
{
    /// <summary>
    /// Makes configuration with maximum carrying capacity and minimum amount of connections.
    /// </summary>
    /// <param name="inputPath">Path to the input file.</param>
    /// <param name="outputPath">Path to the output file.</param>
    /// <exception cref="GraphNotConnectedException">Throws if the graph was not connected.</exception>
    /// <exception cref="ArgumentException">Throws if the input was not in correct form.</exception>
    public static void MakeConfiguration(string inputPath, string outputPath)
    {
        var tree = Graph.MakeMinimalTree(inputPath);
        using var writer = new StreamWriter(outputPath);
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
