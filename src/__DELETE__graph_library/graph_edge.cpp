//
// Created by prodevmo on 28.03.22.
//

#include "graph_edge.h"

graph_edge::graph_edge(const graph_node _from,const graph_node _to) {
    from = _from;
    to = _to;
}

graph_edge::graph_edge(const graph_node _from,const graph_node _to, const graph_edge_weight_type _weigth) {
    graph_edge(from, to);
    set_weigth(_weigth);
}

std::string graph_edge::toString() {
    return toJson().dump();
}

json11::Json graph_edge::toJson() {
    const json11::Json t = json11::Json::object{
            {"type", "edge"},
            {"from_node", from.get_label()},
            {"to_node", to.get_label()},
            {"weigth", get_weigth()}
    };
    return t;
}

bool graph_edge::check_same_origin(const graph_edge& _e, const graph_node& _n){
    if(_e.from == _n){
        return true;
    }
    return false;
}
bool graph_edge::check_same_destination(const graph_edge& _e, const graph_node& _n){
    if(_e.to == _n){
        return true;
    }
    return false;
}

void graph_edge::set_weigth(graph_edge_weight_type _w) {
    weigth = _w;
}

graph_edge_weight_type graph_edge::get_weigth() {
    return weigth;
}

graph_node graph_edge::get_to() {
    return to;
}

graph_node graph_edge::get_from() {
    return from;
}

bool graph_edge::check_same_destination(graph_edge &_e, graph_node &_n) {
    return false;
}

bool graph_edge::check_same_origin(graph_edge &_e, graph_node &_n) {
    return false;
}


