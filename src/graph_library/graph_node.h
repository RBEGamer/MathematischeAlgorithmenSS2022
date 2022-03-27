//
// Created by Marcel Ochsendorf on 28.03.22.
//

#ifndef GRAPH_LIBRARY_GRAPH_NODE_H
#define GRAPH_LIBRARY_GRAPH_NODE_H

#include <string>
#include <vector>


#include "graph_edge.h"

class graph_node {


public:
    graph_node();


    std::string toString();
    std::string toJson();
};


#endif //GRAPH_LIBRARY_GRAPH_NODE_H
