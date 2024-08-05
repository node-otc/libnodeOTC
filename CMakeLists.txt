cmake_minimum_required(VERSION 3.9)
project(node-otc LANGUAGES C VERSION 0.0.1 DESCRIPTION "OTC Overlay Trusted Tiny Coin Biblothek")
include(GNUInstallDirs)
add_library(node-otc SHARED src/main.c)
set_target_properties(node-otc PROPERTIES
    VERSION ${PROJECT_VERSION}
    SOVERSION ${PROJECT_VERSION_MAJOR}
    PUBLIC_HEADER include/node-otc.h)
configure_file(node-otc.pc.in node-otc.pc @ONLY)
target_include_directories(node-otc PRIVATE .)
install(TARGETS node-otc
    LIBRARY DESTINATION ${CMAKE_INSTALL_LIBDIR}
    PUBLIC_HEADER DESTINATION ${CMAKE_INSTALL_INCLUDEDIR})
install(FILES ${CMAKE_BINARY_DIR}/node-otc.pc
    DESTINATION ${CMAKE_INSTALL_DATAROOTDIR}/pkgconfig)
