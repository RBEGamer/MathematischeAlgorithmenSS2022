//
// Created by prodevmo on 28.03.22.
//

#ifndef GRAPH_LIBRARY_GRAPH_EDGE_H
#define GRAPH_LIBRARY_GRAPH_EDGE_H

#include <string>
#include "3rd_party/json11/json11.hpp"

#include "graph_node.h"


class graph_edge {
public:
    graph_edge(graph_node _from, graph_node _to);
    graph_edge(graph_node _from, graph_node _to, graph_edge_weight_type _weigth);



    void set_weigth(graph_edge_weight_type _w);
    graph_edge_weight_type get_weigth();

    graph_node get_to();
    graph_node get_from();
    std::string toString();
    json11::Json toJson();

private:
    graph_node from;
    graph_node to;
    graph_edge_weight_type weigth;


    bool check_same_origin(const graph_edge &_e, const graph_node &_n);

    bool check_same_destination(const graph_edge &_e, const graph_node &_n);
};


#endif //GRAPH_LIBRARY_GRAPH_EDGE_H
