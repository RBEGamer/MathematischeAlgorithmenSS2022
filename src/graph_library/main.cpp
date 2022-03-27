#include <iostream>

#include <filesystem>
#include <string>
#include <iostream>
//---- 3RD_PARTY---------//
#include "3rd_party/loguru/loguru.hpp"

//---- LOCAL ----------//
#include "config_parser.h"



#ifndef VERSION
#define VERSION "42.42.42"
#endif

#define LOG_FILE_PATH "./graph_libaray.log"
#define LOG_FILE_PATH_ERROR "./graph_libaray_error.log"
#define CONFIG_FILE_PATH "./graph_libaray_config.ini"


volatile bool main_loop_running = false;



void signal_callback_handler(int signum) {
    main_loop_running = false;
    LOG_F(ERROR, "Caught signal %d\n", signum);
    loguru::flush();
}

bool cmdOptionExists(char **begin, char **end, const std::string &option) {
    return std::find(begin, end, option) != end;
}








int main(int argc, char *argv[]) {
    //REGISTER SIGNAL HANDLER
    signal(SIGINT, signal_callback_handler);

    //SETUP LOGGER
    loguru::init(argc, argv);
    loguru::add_file(LOG_FILE_PATH, loguru::Truncate, loguru::Verbosity_MAX);
    loguru::add_file(LOG_FILE_PATH_ERROR, loguru::Truncate, loguru::Verbosity_WARNING);

    //---- PRINT HELP MESSAGE ------------------------------------------------------ //
    if (cmdOptionExists(argv, argv + argc, "-help")) {
        std::cout << "---- HELP ----" << std::endl;
        std::cout << "-help                   | prints this message" << std::endl;
        std::cout << "-version                | print version of this tool" << std::endl;
        std::cout << "-writeconfig            | creates default config" << std::endl;
        std::cout << "---- END HELP ----" << std::endl;
        return 0;
    }

    //---- PRINT VERSION MESSAGE ------------------------------------------------------ //
    if (cmdOptionExists(argv, argv + argc, "-version")) {
        std::cout << "---- GRAPH_LIBRARY VERSION ----" << std::endl;
        std::cout << "version:" << VERSION << std::endl;
        std::cout << "build date:" << __DATE__ << std::endl;
        std::cout << "build time:" << __TIME__ << std::endl;
        return 0;
    }

    //LOAD CONFIG
    LOG_SCOPE_F(INFO, "LOADING CONFIG FILE %s", CONFIG_FILE_PATH);

    //OVERWRITE WITH EXISTSING CONFIG FILE SETTINGS
    if (!config_parser::getInstance()->loadConfigFile(CONFIG_FILE_PATH) ||
    cmdOptionExists(argv, argv + argc, "-writeconfig")) {
        LOG_F(WARNING, "--- CREATE LOCAL CONFIG FILE -----");
        //LOAD DEFAULTS
        config_parser::getInstance()->loadDefaults();
        //WRITE CONFIG FILE TO FILESYSTEM
        config_parser::getInstance()->createConfigFile(CONFIG_FILE_PATH, true);
        LOG_F(ERROR, "WRITE NEW CONFIGFILE DUE MISSING ONE");
    }
    LOG_F(INFO, "CONFIG FILE LOADED");





    //LOAD EXAMPLE GRAPHS
    if(config_parser::getInstance()->getBool_nocheck(config_parser::CFG_ENTRY::LOAD_EXAMPLE_GRAPHS)){
        std::string example_graph_path = config_parser::getInstance()->get(config_parser::CFG_ENTRY::GRAPH_STORAGE_PATH);
        for (const auto & entry : std::filesystem::directory_iterator(example_graph_path)){
            std::cout << entry.path() << std::endl;
        }
    }




    return 0;
}
