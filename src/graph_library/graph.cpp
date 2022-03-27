//
// Created by Marcel Ochsendorf on 27.03.22.
//

#include "graph.h"

graph::graph() {

}

graph::graph(std::vector<graph_edge> _edges) {
//FOR ITERATOR  ADD EDGES
}



bool graph::load_graph_from_file(const std::string _file) {
    return false;

    //GENERATED EDGELIST
}

void graph::add_node(graph_node &_node) {

}

void graph::add_edge(graph_node &_from, graph_node _to) {
//CHECK IF NODES EXISTS => ADD ONE
}

bool graph::contains_node(graph_node &_node) {
    return false;
}

size_t graph::count_edges() {
    return 0;
}

size_t graph::count_nodes() {
    return 0;
}

std::vector<graph_edge> graph::get_edges() {
    return std::vector<graph_edge>();
}

graph_edge graph::get_edge_from_node(graph_node &_from) {
    return graph_edge(graph_node(), graph_node());
}

graph_edge graph::get_edge_to_node(graph_node &_to) {
    return graph_edge(graph_node(), graph_node());
}

graph_edge graph::get_edge_from_to_node(graph_node &_from, graph_node &_to) {
    return graph_edge(graph_node(), graph_node());
}

std::vector<graph_node> graph::get_nodes() {
    return std::vector<graph_node>();
}

double graph::get_total_costs() {
    return 0;
}

std::string graph::toString() {
    return std::string();
}

std::string graph::toJson() {
    return std::string();
}



