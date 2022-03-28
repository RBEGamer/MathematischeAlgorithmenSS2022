cmake_minimum_required(VERSION 3.20)
project(graph_library)
set(PROJECT_NAME graph_library)
# project version
set(VERSION_MAJOR 1)
set(VERSION_MINOR 0)
set(VERSION_PATCH 0)
add_compile_definitions(VERSION="0.1.0")

# C++17
enable_language(C CXX)
set (CMAKE_VERBOSE_MAKEFILE 1)
set(CMAKE_CXX_STANDARD 17)
add_definitions(-std=c++17)
set(CMAKE_CXX_STANDARD_REQUIRED TRUE)

find_package (Threads)

set(SOURCE_FILES
        3rd_party/cpp-httplib/httplib.h
        3rd_party/json11/json11.hpp 3rd_party/json11/json11.cpp
        3rd_party/loguru/loguru.cpp
        3rd_party/inih/INIReader.h
        3rd_party/magic_enum/include/magic_enum.hpp
        main.cpp config_parser.cpp config_parser.h
        graph.cpp graph.h graph_node.cpp graph_node.h graph_edge.cpp graph_edge.h graph_datatypes.h)

file(GLOB SOURCES *.h *.hpp *.cpp)

add_executable(${PROJECT_NAME} ${SOURCE_FILES} ${SOURCES})

# MAC COMPILE ON MAC OSX
if (${CMAKE_SYSTEM_NAME} MATCHES "Darwin")
    set_target_properties(${PROJECT_NAME} PROPERTIES
            BUNDLE True
            MACOSX_BUNDLE_GUI_IDENTIFIER com.prodevmo.graphlibrary.${PROJECT_NAME}
            MACOSX_BUNDLE_BUNDLE_NAME ${PROJECT_NAME}
            MACOSX_BUNDLE_BUNDLE_VERSION "0.1"
            MACOSX_BUNDLE_SHORT_VERSION_STRING "0.1"
            MACOSX_BUNDLE_INFO_PLIST ${CMAKE_SOURCE_DIR}/cmake/customtemplate.plist.in
            )
else()
    TARGET_LINK_LIBRARIES(${PROJECT_NAME} ${Boost_LIBRARIES} rt)
endif()


target_link_libraries(${PROJECT_NAME} ${CMAKE_DL_LIBS})
target_link_libraries (${PROJECT_NAME} ${CMAKE_THREAD_LIBS_INIT})
target_link_libraries(${PROJECT_NAME} ${CMAKE_DL_LIBS})


set_target_properties(${PROJECT_NAME} PROPERTIES OUTPUT_NAME "${PROJECT_NAME}")
set(dir ${CMAKE_CURRENT_SOURCE_DIR})
set(EXECUTABLE_OUTPUT_PATH ${dir} CACHE PATH "Build directory" FORCE)
set(LIBRARY_OUTPUT_PATH ${dir} CACHE PATH "Build directory" FORCE)