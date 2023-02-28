using Dijkstra;

internal class Program
{
    private static void Main(string[] args)
    {

/**
  Example graph:

  A--2-->B      B--5-->E      E
  |      |      |      ^      |
  4      3      1      1      2
  v      v      v      |      v
  C      C--2-->D      D--4-->F
*/

        Node a = new Node("A");
        Node b = new Node("B");
        Node c = new Node("C");
        Node d = new Node("D");
        Node e = new Node("E");
        Node f = new Node("F");

        a.AddAdjacentNode(b, 2);
        a.AddAdjacentNode(c, 4);
        b.AddAdjacentNode(c, 3);
        b.AddAdjacentNode(d, 1);
        b.AddAdjacentNode(e, 5);
        c.AddAdjacentNode(d, 2);
        d.AddAdjacentNode(e, 1);
        d.AddAdjacentNode(f, 4);
        e.AddAdjacentNode(f, 2);

        var g = new Graph(a);
        g.ShortestPath();
        Graph.PrintPaths(new List<Node>() { a, b, c, d, e, f });
    }
}