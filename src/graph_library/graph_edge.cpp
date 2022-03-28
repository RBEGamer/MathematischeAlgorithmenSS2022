//
// Created by Marcel Ochsendorf on 28.03.22.
//

#include "graph_edge.h"

graph_edge::graph_edge(const graph_node _from, const graph_node _to) {
from = _from;
to = _to;
weigth = GRAPH_EDGE_WEIGTH_DEFAULT;
}

graph_edge::graph_edge(const graph_node _from, const graph_node _to, const graph_edge_weight_type _weigth) {
    from = _from;
    to = _to;
    weigth = _weigth;
}


std::string graph_edge::toString() {
    return toJson().dump();
}

json11::Json graph_edge::toJson() {
    const json11::Json t = json11::Json::object{
        {"from", from.get_label()},
        {"to", to.get_label()},
        {"weigth", weigth}};
    return t;
}


