//
// Created by Marcel Ochsendorf on 27.03.22.
//

#ifndef GRAPH_LIBRARY_GRAPH_H
#define GRAPH_LIBRARY_GRAPH_H

#include <filesystem>
#include <string>
#include <vector>
#include "3rd_party/loguru/loguru.hpp"

#include "graph_node.h"
#include "graph_edge.h"
class graph {


public:
    graph();
    graph(std::vector<graph_edge> _edges);

    bool load_graph_from_file(std::string _file);


    void add_node(graph_node& _node);
    void add_edge(graph_node& _from, graph_node _to);
    bool contains_node(graph_node& _node);
    size_t count_edges();
    size_t count_nodes();
    std::vector<graph_edge> get_edges();
    graph_edge get_edge_from_node(graph_node& _from);
    graph_edge get_edge_to_node(graph_node& _to);
    graph_edge get_edge_from_to_node(graph_node& _from, graph_node& _to);
    std::vector<graph_node> get_nodes();
    double get_total_costs();
    std::string toString();
    std::string toJson();
private:


    void add_node(const graph_node &_node);
};


#endif //GRAPH_LIBRARY_GRAPH_H
