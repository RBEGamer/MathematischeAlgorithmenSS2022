//
// Created by Marcel Ochsendorf on 28.03.22.
//

#include "graph_node.h"

graph_node::graph_node() {

}

graph_node::graph_node(graph_node_label_type _node_id) {
    set_label(_node_id);
}

void graph_node::set_label(graph_node_label_type _label) {
    node_id = _label;
}

graph_node_label_type graph_node::get_label() {
    return node_id;
}

std::vector<graph_edge> graph_node::get_edges() {
    return node_edges;
}

std::vector<graph_edge> graph_node::get_edges_to(graph_node &_to) {
    std::vector<graph_edge> t;

    for (graph_edge& e: get_edges()) {


        //if(_to.equals()){
        //    t.push_back(e);
       // }
    }
    return t;
}


bool graph_node::operator== (const graph_node& c1) const
{
    return c1.node_id == node_id;
}

bool graph_node::equals(const graph_node& c1) const {
    return c1.node_id == node_id;
}

void graph_node::add_edge(graph_edge &_edge) {
    node_edges.push_back(_edge);
}

void graph_node::remove_edge(graph_edge &_edge) {
   // node_edges.erase(_edge);
}

void graph_node::set_visited(bool _visited) {
 node_visited = _visited;
}

bool graph_node::visited() {
    return node_visited;
}

size_t graph_node::edge_count() {
    return get_edges().size();
}

std::string graph_node::toString() {
    return toJson().dump();
}

json11::Json graph_node::toJson() {
    const json11::Json t = json11::Json::object{
            {"type", "node"},
            {"visited", visited()},
            {"id", node_id},
            {"label", get_label()},
            {"payload", get_payload()},
            {"edge_count", (int)edge_count()},


    };
    return t;
}

void graph_node::set_payload(graph_node_value_type _payload) {
    node_payload = _payload;
}

graph_node_value_type graph_node::get_payload() const {
    return node_payload;
}




