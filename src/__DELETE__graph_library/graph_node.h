//
// Created by Marcel Ochsendorf on 28.03.22.
//

#ifndef GRAPH_LIBRARY_GRAPH_NODE_H
#define GRAPH_LIBRARY_GRAPH_NODE_H

#include <string>
#include <vector>

#include "3rd_party/json11/json11.hpp"

#include "graph_datatypes.h"
#include "graph_edge.h"

class graph_node {


public:
    graph_node();
    graph_node(graph_node_label_type _node_id);

    void add_edge(graph_edge& _edge);
    void remove_edge(graph_edge& _edge);

    std::vector<graph_edge> get_edges_to(graph_node& _to);

    std::vector<graph_edge> get_edges();

    void set_label(graph_node_label_type _label);
    graph_node_label_type get_label();

    void set_visited(bool _visited);
    bool visited();
    size_t edge_count();
    std::string toString();
    json11::Json toJson();

    void set_payload(graph_node_value_type _payload);
    graph_node_value_type get_payload() const;


    operator== (const graph_node& c1) const;
    bool equals(const graph_node& c1) const;
private:

    std::vector<graph_edge> node_edges;
    graph_node_value_type node_payload;
    bool node_visited;
    graph_node_label_type node_id;


};


#endif //GRAPH_LIBRARY_GRAPH_NODE_H
