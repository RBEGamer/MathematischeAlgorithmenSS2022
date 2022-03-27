//
// Created by Marcel Ochsendorf on 27.03.22.
//

#ifndef GRAPH_LIBRARY_GRAPH_H
#define GRAPH_LIBRARY_GRAPH_H

#include <filesystem>
#include <string>

#include "3rd_party/loguru/loguru.hpp"

class graph {


public:
    graph();
    bool load_grapth_from_file(std::string _file);
private:


};


#endif //GRAPH_LIBRARY_GRAPH_H
