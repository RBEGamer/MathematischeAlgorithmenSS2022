# CMAKE generated file: DO NOT EDIT!
# Generated by "Unix Makefiles" Generator, CMake Version 3.21

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:

#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:

# Disable VCS-based implicit rules.
% : %,v

# Disable VCS-based implicit rules.
% : RCS/%

# Disable VCS-based implicit rules.
% : RCS/%,v

# Disable VCS-based implicit rules.
% : SCCS/s.%

# Disable VCS-based implicit rules.
% : s.%

.SUFFIXES: .hpux_make_needs_suffix_list

# Produce verbose output by default.
VERBOSE = 1

# Command-line flag to silence nested $(MAKE).
$(VERBOSE)MAKESILENT = -s

#Suppress display of executed commands.
$(VERBOSE).SILENT:

# A target that is always out of date.
cmake_force:
.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

# The shell in which to execute make rules.
SHELL = /bin/sh

# The CMake executable.
CMAKE_COMMAND = /home/prodevmo/.local/share/JetBrains/Toolbox/apps/CLion/ch-0/213.7172.20/bin/cmake/linux/bin/cmake

# The command to remove a file.
RM = /home/prodevmo/.local/share/JetBrains/Toolbox/apps/CLion/ch-0/213.7172.20/bin/cmake/linux/bin/cmake -E rm -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/cmake-build-debug

# Include any dependencies generated for this target.
include CMakeFiles/graph_library.dir/depend.make
# Include any dependencies generated by the compiler for this target.
include CMakeFiles/graph_library.dir/compiler_depend.make

# Include the progress variables for this target.
include CMakeFiles/graph_library.dir/progress.make

# Include the compile flags for this target's objects.
include CMakeFiles/graph_library.dir/flags.make

CMakeFiles/graph_library.dir/3rd_party/json11/json11.cpp.o: CMakeFiles/graph_library.dir/flags.make
CMakeFiles/graph_library.dir/3rd_party/json11/json11.cpp.o: ../3rd_party/json11/json11.cpp
CMakeFiles/graph_library.dir/3rd_party/json11/json11.cpp.o: CMakeFiles/graph_library.dir/compiler_depend.ts
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object CMakeFiles/graph_library.dir/3rd_party/json11/json11.cpp.o"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -MD -MT CMakeFiles/graph_library.dir/3rd_party/json11/json11.cpp.o -MF CMakeFiles/graph_library.dir/3rd_party/json11/json11.cpp.o.d -o CMakeFiles/graph_library.dir/3rd_party/json11/json11.cpp.o -c /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/3rd_party/json11/json11.cpp

CMakeFiles/graph_library.dir/3rd_party/json11/json11.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/graph_library.dir/3rd_party/json11/json11.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/3rd_party/json11/json11.cpp > CMakeFiles/graph_library.dir/3rd_party/json11/json11.cpp.i

CMakeFiles/graph_library.dir/3rd_party/json11/json11.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/graph_library.dir/3rd_party/json11/json11.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/3rd_party/json11/json11.cpp -o CMakeFiles/graph_library.dir/3rd_party/json11/json11.cpp.s

CMakeFiles/graph_library.dir/3rd_party/loguru/loguru.cpp.o: CMakeFiles/graph_library.dir/flags.make
CMakeFiles/graph_library.dir/3rd_party/loguru/loguru.cpp.o: ../3rd_party/loguru/loguru.cpp
CMakeFiles/graph_library.dir/3rd_party/loguru/loguru.cpp.o: CMakeFiles/graph_library.dir/compiler_depend.ts
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Building CXX object CMakeFiles/graph_library.dir/3rd_party/loguru/loguru.cpp.o"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -MD -MT CMakeFiles/graph_library.dir/3rd_party/loguru/loguru.cpp.o -MF CMakeFiles/graph_library.dir/3rd_party/loguru/loguru.cpp.o.d -o CMakeFiles/graph_library.dir/3rd_party/loguru/loguru.cpp.o -c /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/3rd_party/loguru/loguru.cpp

CMakeFiles/graph_library.dir/3rd_party/loguru/loguru.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/graph_library.dir/3rd_party/loguru/loguru.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/3rd_party/loguru/loguru.cpp > CMakeFiles/graph_library.dir/3rd_party/loguru/loguru.cpp.i

CMakeFiles/graph_library.dir/3rd_party/loguru/loguru.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/graph_library.dir/3rd_party/loguru/loguru.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/3rd_party/loguru/loguru.cpp -o CMakeFiles/graph_library.dir/3rd_party/loguru/loguru.cpp.s

CMakeFiles/graph_library.dir/graph_edge.cpp.o: CMakeFiles/graph_library.dir/flags.make
CMakeFiles/graph_library.dir/graph_edge.cpp.o: ../graph_edge.cpp
CMakeFiles/graph_library.dir/graph_edge.cpp.o: CMakeFiles/graph_library.dir/compiler_depend.ts
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_3) "Building CXX object CMakeFiles/graph_library.dir/graph_edge.cpp.o"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -MD -MT CMakeFiles/graph_library.dir/graph_edge.cpp.o -MF CMakeFiles/graph_library.dir/graph_edge.cpp.o.d -o CMakeFiles/graph_library.dir/graph_edge.cpp.o -c /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/graph_edge.cpp

CMakeFiles/graph_library.dir/graph_edge.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/graph_library.dir/graph_edge.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/graph_edge.cpp > CMakeFiles/graph_library.dir/graph_edge.cpp.i

CMakeFiles/graph_library.dir/graph_edge.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/graph_library.dir/graph_edge.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/graph_edge.cpp -o CMakeFiles/graph_library.dir/graph_edge.cpp.s

CMakeFiles/graph_library.dir/graph_node.cpp.o: CMakeFiles/graph_library.dir/flags.make
CMakeFiles/graph_library.dir/graph_node.cpp.o: ../graph_node.cpp
CMakeFiles/graph_library.dir/graph_node.cpp.o: CMakeFiles/graph_library.dir/compiler_depend.ts
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_4) "Building CXX object CMakeFiles/graph_library.dir/graph_node.cpp.o"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -MD -MT CMakeFiles/graph_library.dir/graph_node.cpp.o -MF CMakeFiles/graph_library.dir/graph_node.cpp.o.d -o CMakeFiles/graph_library.dir/graph_node.cpp.o -c /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/graph_node.cpp

CMakeFiles/graph_library.dir/graph_node.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/graph_library.dir/graph_node.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/graph_node.cpp > CMakeFiles/graph_library.dir/graph_node.cpp.i

CMakeFiles/graph_library.dir/graph_node.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/graph_library.dir/graph_node.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/graph_node.cpp -o CMakeFiles/graph_library.dir/graph_node.cpp.s

CMakeFiles/graph_library.dir/graph.cpp.o: CMakeFiles/graph_library.dir/flags.make
CMakeFiles/graph_library.dir/graph.cpp.o: ../graph.cpp
CMakeFiles/graph_library.dir/graph.cpp.o: CMakeFiles/graph_library.dir/compiler_depend.ts
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_5) "Building CXX object CMakeFiles/graph_library.dir/graph.cpp.o"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -MD -MT CMakeFiles/graph_library.dir/graph.cpp.o -MF CMakeFiles/graph_library.dir/graph.cpp.o.d -o CMakeFiles/graph_library.dir/graph.cpp.o -c /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/graph.cpp

CMakeFiles/graph_library.dir/graph.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/graph_library.dir/graph.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/graph.cpp > CMakeFiles/graph_library.dir/graph.cpp.i

CMakeFiles/graph_library.dir/graph.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/graph_library.dir/graph.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/graph.cpp -o CMakeFiles/graph_library.dir/graph.cpp.s

CMakeFiles/graph_library.dir/main.cpp.o: CMakeFiles/graph_library.dir/flags.make
CMakeFiles/graph_library.dir/main.cpp.o: ../main.cpp
CMakeFiles/graph_library.dir/main.cpp.o: CMakeFiles/graph_library.dir/compiler_depend.ts
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_6) "Building CXX object CMakeFiles/graph_library.dir/main.cpp.o"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -MD -MT CMakeFiles/graph_library.dir/main.cpp.o -MF CMakeFiles/graph_library.dir/main.cpp.o.d -o CMakeFiles/graph_library.dir/main.cpp.o -c /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/main.cpp

CMakeFiles/graph_library.dir/main.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/graph_library.dir/main.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/main.cpp > CMakeFiles/graph_library.dir/main.cpp.i

CMakeFiles/graph_library.dir/main.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/graph_library.dir/main.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/main.cpp -o CMakeFiles/graph_library.dir/main.cpp.s

CMakeFiles/graph_library.dir/config_parser.cpp.o: CMakeFiles/graph_library.dir/flags.make
CMakeFiles/graph_library.dir/config_parser.cpp.o: ../config_parser.cpp
CMakeFiles/graph_library.dir/config_parser.cpp.o: CMakeFiles/graph_library.dir/compiler_depend.ts
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_7) "Building CXX object CMakeFiles/graph_library.dir/config_parser.cpp.o"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -MD -MT CMakeFiles/graph_library.dir/config_parser.cpp.o -MF CMakeFiles/graph_library.dir/config_parser.cpp.o.d -o CMakeFiles/graph_library.dir/config_parser.cpp.o -c /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/config_parser.cpp

CMakeFiles/graph_library.dir/config_parser.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/graph_library.dir/config_parser.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/config_parser.cpp > CMakeFiles/graph_library.dir/config_parser.cpp.i

CMakeFiles/graph_library.dir/config_parser.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/graph_library.dir/config_parser.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/config_parser.cpp -o CMakeFiles/graph_library.dir/config_parser.cpp.s

# Object files for target graph_library
graph_library_OBJECTS = \
"CMakeFiles/graph_library.dir/3rd_party/json11/json11.cpp.o" \
"CMakeFiles/graph_library.dir/3rd_party/loguru/loguru.cpp.o" \
"CMakeFiles/graph_library.dir/graph_edge.cpp.o" \
"CMakeFiles/graph_library.dir/graph_node.cpp.o" \
"CMakeFiles/graph_library.dir/graph.cpp.o" \
"CMakeFiles/graph_library.dir/main.cpp.o" \
"CMakeFiles/graph_library.dir/config_parser.cpp.o"

# External object files for target graph_library
graph_library_EXTERNAL_OBJECTS =

../graph_library: CMakeFiles/graph_library.dir/3rd_party/json11/json11.cpp.o
../graph_library: CMakeFiles/graph_library.dir/3rd_party/loguru/loguru.cpp.o
../graph_library: CMakeFiles/graph_library.dir/graph_edge.cpp.o
../graph_library: CMakeFiles/graph_library.dir/graph_node.cpp.o
../graph_library: CMakeFiles/graph_library.dir/graph.cpp.o
../graph_library: CMakeFiles/graph_library.dir/main.cpp.o
../graph_library: CMakeFiles/graph_library.dir/config_parser.cpp.o
../graph_library: CMakeFiles/graph_library.dir/build.make
../graph_library: CMakeFiles/graph_library.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=/home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_8) "Linking CXX executable ../graph_library"
	$(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/graph_library.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
CMakeFiles/graph_library.dir/build: ../graph_library
.PHONY : CMakeFiles/graph_library.dir/build

CMakeFiles/graph_library.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/graph_library.dir/cmake_clean.cmake
.PHONY : CMakeFiles/graph_library.dir/clean

CMakeFiles/graph_library.dir/depend:
	cd /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/cmake-build-debug && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/cmake-build-debug /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/cmake-build-debug /home/prodevmo/Desktop/MathematischeAlgorithmenSS2022/src/graph_library/cmake-build-debug/CMakeFiles/graph_library.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles/graph_library.dir/depend
