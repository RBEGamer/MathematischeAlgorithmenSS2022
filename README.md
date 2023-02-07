# MathematischeAlgorithmenSS2022


The goal of this course is, to implement a performant graph library

[FH Aachen - Mathematical Methods in Computer Science](https://www.fh-aachen.de/menschen/hoever/lehrveranstaltungen/mathematischen-methoden-der-informatik/)

## GRAPH FORMAT

graph example folder: `./src/graph_library/example_graphs`

First line: Number of nodes; following lines: Edges (i->j, numbering: 0 ... node-count-1) (To check your algorithms: Graphs 2 and 3 each have 4 context components, the large 222, the whole-large 9560, and the whole-large 306). 



## Practical tasks

1st Graph: Structure and storage format.
   * Breadth-first search (iterative) and depth-first search (recursive) to determine the number of coherence components.
2. minimal exciting trees
   * algorithms of Prim and Kruskal
3. traveling salesman problem
   - Nearest neighbor algorithm
   - Double tree algorithm
   - Solution by trying all tours
   - Branch-and-Bound in the solution of TSP
4. shortest paths
   - Dijkstra algorithm
   - Moore-Bellman-Ford algorithm
5. maximum fluxes
   - Edmonds-Karp algorithm
6. minimum cost fluxes
   - Cycle-Canceling-Algorithm
   - Successive-Shortest-Path-Algorithm
7. maximum matchings in bipartite graphs
   - Determination with maximum fluxes
