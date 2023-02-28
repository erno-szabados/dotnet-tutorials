### Dijkstra's algorithm

Shortest paths from given node to all
reachable nodes. Greedy algorithm.

C# port of Geekific's Java example. 

Shortest path between two nodes
given shortest is A-B-C-D:
B-D = B-C-D is shortest
A-C = A-B-C is shortest

Approx. Any subpath of the path is also the shortest path between path vertices.

Start by overestimating all nodes (except starting A) cost
c(V) = inf
pred = NIL
c(A) = 0

c = cost to V
pred = previous node leading to V

Idea: continuously eliminate all other longer paths between starting node and all possible destinations.

Find shortest path between A and all the other nodes in this graph.

There are two node sets:

Settled: min distance and pred are finalized.
Unsettled: can be reached from the source, but min distance is not finalized.

Pick node with lowest known distance and evaluate all its unsettled adjacent nodes.
Add edge weight to source distance then compare with destination distance.
