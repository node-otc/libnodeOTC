cmake_minimum_required(VERSION 3.16)

project(otc LANGUAGES C VERSION 0.0.1 DESCRIPTION "OTC Overlay Trusted Tiny Coin base libary")

include_directories(${CMAKE_CURRENT_SOURCE_DIR}/include)
add_library(otc src/main.c)

include(GNUInstallDirs)


install(TARGETS otc
    LIBRARY DESTINATION ${CMAKE_INSTALL_LIBDIR}
    PUBLIC_HEADER DESTINATION ${CMAKE_INSTALL_INCLUDEDIR})
install(FILES ${CMAKE_BINARY_DIR}/otc.pc
    DESTINATION ${CMAKE_INSTALL_DATAROOTDIR}/pkgconfig)
