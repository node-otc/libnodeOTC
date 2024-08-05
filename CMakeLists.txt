cmake_minimum_required(VERSION 3.9)

project(ndbenadetta)

set(ndbenadetta_VERSION_MAJOR 0)
set(ndbenadetta_VERSION_MINOR 1)
set(ndbenadetta_VERSION_PATCH 0)
set(ndbenadetta_VERSION "${ndbenadetta_VERSION_MAJOR}.${ndbenadetta_VERSION_MINOR}.${ndbenadetta_VERSION_PATCH}")

set(PROJ_NAME "\"ndbenadetta\"") 
set(PROJECT_DESCRIPTION "\"BENADETTA OTC Overlay Trusted Tiny Coin Biblothek\"")


configure_file(include/config.hpp.in
    ${CMAKE_BINARY_DIR}/include/config.hpp
)

set(CMAKE_CXX_STANDARD 14)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_EXTENSIONS OFF)


set(LIBRARY_SOURCES
    src/ndbenadetta.cpp
)

add_library(ndbenadetta ${LIBRARY_SOURCES}) # A library
set_target_properties(ndbenadetta PROPERTIES PREFIX "") # Remove the lib prefix
target_include_directories(ndbenadetta PUBLIC ${CMAKE_SOURCE_DIR}/include ${CMAKE_BINARY_DIR}/include)


install(TARGETS ndbenadetta
    ARCHIVE DESTINATION lib
    LIBRARY DESTINATION lib
    RUNTIME DESTINATION bin
)

# Install the project header files into the appropriate directory
install(DIRECTORY include/ DESTINATION include PATTERN "config.hpp.in" EXCLUDE) # Install our main header files
install(FILES ${CMAKE_BINARY_DIR}/include/config.hpp DESTINATION include/benadetta/) # Install our configuration file

# Install the project's extra files
install(FILES README.md LICENSE DESTINATION share/benadetta/)