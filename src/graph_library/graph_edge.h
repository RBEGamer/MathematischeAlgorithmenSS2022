//
// Created by Marcel Ochsendorf on 28.03.22.
//

#ifndef GRAPH_LIBRARY_GRAPH_EDGE_H
#define GRAPH_LIBRARY_GRAPH_EDGE_H

#include "3rd_party/json11/json11.hpp"

#include "graph_datatypes.h"
#include "graph_node.h"

class graph_edge {

public:
    graph_edge(graph_node _from, graph_node _to);
    graph_edge(graph_node _from, graph_node _to, graph_edge_weight_type _weigth);


    std::string toString();
    json11::Json toJson();
private:
 graph_node from;
 graph_node to;

 graph_edge_weight_type weigth;

};


#endif //GRAPH_LIBRARY_GRAPH_EDGE_H
