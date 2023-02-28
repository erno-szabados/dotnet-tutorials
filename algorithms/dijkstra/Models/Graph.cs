namespace Dijkstra;

class Graph
{
    public Node Root { get; private set; }

    public Graph(Node v)
    {
        Root = v;
    }

    public void ShortestPath()
    {
        ShortestPath(Root);
    }

    private static void ShortestPath(Node n)
    {
        n.Distance = 0;
        var settledNodes = new HashSet<Node>();
        var unsettledNodes = new PriorityQueue<Node, Int32>();
        unsettledNodes.Enqueue(n, n.Distance);
        while (unsettledNodes.Count > 0)
        {
            Node currentNode = unsettledNodes.Dequeue();
            var currentUnsettled = currentNode.AdjacentNodes.Where(v => !settledNodes.Contains(v.Key));
            foreach (var cu in currentUnsettled)
            {
                evaluateDistanceAndPath(cu.Key, cu.Value, currentNode);
                unsettledNodes.Enqueue(cu.Key, cu.Value);
            }
            settledNodes.Add(currentNode);
        }
    }

    private static void evaluateDistanceAndPath(Node adjacentNode, Int32 edgeWeight, Node sourceNode)
    {
        Int32 newDistance = sourceNode.Distance + edgeWeight;
        if (newDistance < adjacentNode.Distance)
        {
            // lower cost path found
            adjacentNode.Distance = newDistance;
            adjacentNode.ShortestPath = sourceNode.ShortestPath.Append(sourceNode).ToList();
        }
    }

    public static void PrintPaths(List<Node> nodes)
    {
        nodes.ForEach(n =>
        {
            var path = n.ShortestPath
                .Select(v => v.Name)
                .DefaultIfEmpty()
                .Aggregate((i, j) => $"{i} -> {j}");
            Console.WriteLine(String.IsNullOrEmpty(path) ?
                $"{n.Name}:{n.Distance}" :
                $"{path} -> {n.Name} : {n.Distance}");
        });
    }
}