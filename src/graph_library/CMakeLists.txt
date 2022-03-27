cmake_minimum_required(VERSION 3.20)
project(graph_library)

set(CMAKE_CXX_STANDARD 17)

add_executable(graph_library main.cpp config_parser.cpp config_parser.h)
