namespace Dijkstra;

class Node
{
    public string? Name { get; set; }

    public Int32 Distance { get; set; } = Int32.MaxValue;

    public List<Node> ShortestPath { get; set; } = new List<Node>();

    public Node(string name)
    {
        Name = name;
    }

    public Dictionary<Node, Int32> AdjacentNodes { get; set; } = new();

    public void AddAdjacentNode(Node v, int weight) => AdjacentNodes.Add(v, weight);
}