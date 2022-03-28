//
// Created by Marcel Ochsendorf on 28.03.22.
//

#include "graph_node.h"

graph_node::graph_node(graph_node_label_type _node_id) {
    set_label(_node_id);
}

void graph_node::add_edge(graph_edge _edge) {

}

void graph_node::remove_edge(graph_edge _edge) {

}

graph_edge graph_node::get_edge(graph_edge _to) {
    return graph_edge(graph_node(), graph_node());
}

std::vector graph_node::get_edges() {
    return std::vector();
}

void graph_node::set_label(graph_node_label_type _label) {
    node_id = _label;
}

graph_node_label_type graph_node::get_label() {
    return node_id;
}

void graph_node::set_visited(bool _visited) {
    node_visited = _visited;
}



json11::Json graph_node::toJson() {
    json11::Json je = json11::Json::array();
    for (auto &e : node_edges){

    }

    const json11::Json t = json11::Json::object{{"id", node_id},
                                                {"payload", node_payload},
                                                {"visited", node_visited}};
    return t.dump();
}

void graph_node::set_payload(graph_node_value_type _payload) {
    node_payload = _payload;
}

graph_node_value_type graph_node::get_payload() const {
    return node_payload;
}

size_t graph_node::edge_count() {
    return ed;
}

bool graph_node::visited() {
    return node_visited;
}

std::string graph_node::toString() {
    return toJson().dump();
}
